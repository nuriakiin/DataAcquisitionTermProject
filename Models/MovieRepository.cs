using DataAcquisitionTermProject.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcquisitionTermProject.Models
{
    public class MovieRepository : IMovieRepository
    {
        private DataContext context;

        public MovieRepository(DataContext dataContext) => context = dataContext;

        public IEnumerable<Movie> Movies => context.Movies.ToArray();

        public void AddMovie(Movie movie)
        {
            context.Movies.Add(movie);
            context.SaveChanges();
        }

        public void AddMovieRange(IEnumerable<Movie> movies)
        {
            foreach( Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();
        }

        public void DeleteMovie(Movie movie)
        {
            context.Movies.Remove(movie);
            context.SaveChanges();
        }

        public Movie GetMovie(long key)
        {
           return(context.Movies.First(i=>i.MovieId == key));
        }

        public PagedList<Movie> GetMovies(QueryOptions options)
        {
            return new PagedList<Movie>(context.Movies, options);
        }

        public void UpdateMovie(Movie movie)
        {
           Movie m = context.Movies.Find(movie.MovieId);
            m.MovieTitle = movie.MovieTitle;
            m.IMDBUrl = movie.IMDBUrl;
            m.MovieRate = movie.MovieRate;
            context.SaveChanges();
        }

        
    }
}
