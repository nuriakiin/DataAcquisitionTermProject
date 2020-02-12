using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcquisitionTermProject.Models
{
    public class MovieRateRepository : IMovieRateRepository
    {
        private DataContext context;
        public MovieRateRepository(DataContext dataContext) => context = dataContext;

        public IEnumerable<MovieRate> MovieRates => context.MovieRates.ToArray();

        public void AddMovieRange(IEnumerable<MovieRate> movieRates)
        {
            context.MovieRates.AddRange(movieRates);
            context.SaveChanges();
        }

        public void AddMovieRate(MovieRate movieRate)
        {
            context.MovieRates.Add(movieRate);
            context.SaveChanges();
        }

        public void DeleteMovieRate(MovieRate movieRate)
        {
            context.MovieRates.Remove(movieRate);
            context.SaveChanges();
        }

        public MovieRate GetMovieRateByMovieId(long Moviekey)
        {
            return (context.MovieRates.First(u => u.MovieId == Moviekey));
        }

        public MovieRate GetMovieRateByUserId(long Userkey)
        {
            return (context.MovieRates.First(u => u.UserId == Userkey));
        }


        public void UpdateMovieRate(MovieRate movieRate)
        {
            context.MovieRates.Update(movieRate);
            context.SaveChanges();
        }
    }
}
