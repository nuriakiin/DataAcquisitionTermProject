using DataAcquisitionTermProject.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcquisitionTermProject.Models
{
     public interface IMovieRepository
    {
        IEnumerable<Movie> Movies { get; }
        PagedList<Movie> GetMovies(QueryOptions options);
        Movie GetMovie(long key);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(Movie movie);
        void AddMovieRange(IEnumerable<Movie> movies);

       
    }
}
