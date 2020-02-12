using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DataAcquisitionTermProject.Models;
using DataAcquisitionTermProject.Models.Pages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace DataAcquisitionTermProject.Controllers
{

    public class HomeController : Controller
    {
        private IMovieRepository movieRepository;
        private IUserRepository userRepository;
        private IMovieRateRepository movieRateRepository;

        
        public HomeController(IMovieRepository repo,IUserRepository userRepo, IMovieRateRepository mRateRepo)
        {
            movieRepository = repo;
            userRepository = userRepo;
            movieRateRepository = mRateRepo;
        }
        

        public IActionResult Index(QueryOptions options)
        {
            
            //return View(movieRepository.Movies);
            if (HttpContext.Session.GetString("SessionUser") != null)
            {
                User user= JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
                ViewData["SessionUser"] = user.Username;
                ViewData["RateMovieCount"] = movieRateRepository.MovieRates.Count(u => u.UserId == user.UserId).ToString();
                return View(movieRepository.GetMovies(options));
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }
        [HttpPost]
        public IActionResult Index(int selectedRate, long MovieId)
        {

            QueryOptions options=new QueryOptions();
            
            MovieRate movie = new MovieRate();
            movie.MovieId = MovieId;
            movie.Rate = selectedRate;
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
            movie.UserId = user.UserId;
            if (movieRateRepository.MovieRates.Count(u => u.MovieId == MovieId && u.UserId == user.UserId) == 0)
            {
                movieRateRepository.AddMovieRate(movie);
            }
            else
            {
                var obj =movieRateRepository.MovieRates.First(u => u.UserId == user.UserId && u.MovieId == MovieId);
                obj.MovieId = MovieId;
                obj.UserId = user.UserId;
                obj.Rate = selectedRate;
                movieRateRepository.UpdateMovieRate(obj);
            }
                
            return RedirectToAction("Index",movieRepository.GetMovies(options));
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if((userRepository.Users.Count(u => u.Username == user.Username) != 0) && user.UserPassword == (userRepository.Users.First(u => u.Username == user.Username).UserPassword))
            {
                ViewData["NamePass"] = null;
                QueryOptions options= new QueryOptions();
                
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(userRepository.Users.First(u => u.Username == user.Username)));
               
                return RedirectToAction("Index",movieRepository.GetMovies(options));
            }
            else
            {
                ViewData["NamePass"] = " Username or password wrong.";
                return View();
            }  
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("SessionUser");

            return RedirectToAction("Login");
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string password,User user)
        {
            if (user.Username != null && user.UserPassword!=null)
            {
                if ((userRepository.Users.Count(u => u.Username == user.Username) == 0) && (password ==user.UserPassword))
                {
                ViewData["UserExist"] = null;
                ViewData["PassConfirm"] = null;
                userRepository.AddUser(user);
                return RedirectToAction("Login");
                }else if ((password != user.UserPassword) && (userRepository.Users.Count(u => u.Username == user.Username) == 0) )
                {   
                    ViewData["UserExist"] = null;
                    ViewData["PassConfirm"] = "Please control your password. Paswords are dismatch.";
                    
                    return View(nameof(SignIn));
                }
                else if ((password == user.UserPassword) && (userRepository.Users.Count(u => u.Username == user.Username) != 0))
                {   
                    ViewData["PassConfirm"] = null;
                    ViewData["UserExist"] = "Username is already taken. Please select another one.";
                    
                    return View(nameof(SignIn));
                }
                else
                {
                    ViewData["UserExist"] = "Username is already taken. Please select another one.";
                    ViewData["PassConfirm"] = "Please control your password. Paswords are dismatch.";
                    return View(nameof(SignIn));
                }
            }
            return View();


        }
        public IActionResult KnnPrediction(rate Rate)
        {
            if (Rate.userBasedPrediction != 0)
            {
                ViewData["userBasedPrediction"] = Rate.userBasedPrediction;
            }
            else
            {
                ViewData["userBasedPrediction"] = "Sorry, we can't calculate prediction for this movie.";
            }
            if (Rate.itemBasedPrediction != 0)
            {
                ViewData["itemBasedPrediction"] = Rate.itemBasedPrediction;
            }
            else
            {
                ViewData["itemBasedPrediction"] = "Sorry, we can't calculate prediction for this movie.";
            }
            
            
            return View(movieRepository.GetMovie(Rate.movieId));
        }

        [HttpPost]
        public IActionResult KnnPrediction(long key)
        {
            IEnumerable<MovieRate> movieRates = movieRateRepository.MovieRates;
            string[] lines = new string[movieRates.ToList().Count];
            int count = 0;
            foreach (var i in movieRates)
            {
                string s;
                s = i.UserId.ToString() + " " + i.MovieId.ToString() + " " + i.Rate.ToString();
                lines[count] = s;
                count++;

            }
            System.IO.File.WriteAllLines(@"C:\Users\nuria\source\repos\DataAcquisitionTermProject\DataAcquisitionTermProject\MatlabFiles\movieRates.txt", lines);

            MLApp.MLApp matlab = new MLApp.MLApp();
            matlab.Execute(@"cd C:\Users\nuria\source\repos\DataAcquisitionTermProject\DataAcquisitionTermProject\MatlabFiles\");
            object result = null;
            object result2 = null;
            User user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("SessionUser"));
            matlab.Feval("UserBasedKNN", 1, out result, "movieRates.txt", user.UserId, key);
            object[] res = result as object[];
            
            matlab.Feval("ItemBasedKNN", 1, out result2, "movieRates.txt", user.UserId, key);
            object[] res2 = result2 as object[];
            rate rate = new rate();
            Console.WriteLine(res[0]);
            if (res[0]!=System.Reflection.Missing.Value && res2[0]!= System.Reflection.Missing.Value)
            {
                int prediction = int.Parse(res[0].ToString());
                int prediction2 = int.Parse(res2[0].ToString());
                
                rate.movieId = key;
                rate.userBasedPrediction = prediction;
                rate.itemBasedPrediction = prediction2;
                return RedirectToAction("KnnPrediction", "Home", rate);
            }else if(res[0] != System.Reflection.Missing.Value && res2[0] == System.Reflection.Missing.Value)
            {
                int prediction = int.Parse(res[0].ToString());
                rate.movieId = key;
                rate.userBasedPrediction = prediction;
                rate.itemBasedPrediction = 0;
                return RedirectToAction("KnnPrediction", "Home", rate);

            }
            else if(res[0] == System.Reflection.Missing.Value && res2[0] != System.Reflection.Missing.Value)
            {
                int prediction2 = int.Parse(res2[0].ToString());
                rate.movieId = key;
                rate.itemBasedPrediction = prediction2;
                rate.userBasedPrediction = 0;
                return RedirectToAction("KnnPrediction", "Home", rate);
            }
            else
            {
                rate.movieId = key;
                rate.itemBasedPrediction = 0;
                rate.userBasedPrediction = 0;
                return RedirectToAction("KnnPrediction", "Home", rate);
            }




        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

       
    }
}

