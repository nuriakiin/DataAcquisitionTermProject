using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcquisitionTermProject.Models
{
    public interface IMovieRateRepository
    {
        IEnumerable<MovieRate> MovieRates { get; }
        MovieRate GetMovieRateByUserId(long Userkey);
        MovieRate GetMovieRateByMovieId(long Moviekey);
        void AddMovieRate(MovieRate movieRate);
        void UpdateMovieRate(MovieRate movieRate);
        void DeleteMovieRate(MovieRate movieRate);
        void AddMovieRange(IEnumerable<MovieRate> movieRates);
    }
}
