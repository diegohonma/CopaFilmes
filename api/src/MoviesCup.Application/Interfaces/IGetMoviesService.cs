using MoviesCup.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesCup.Application.Interfaces
{
    public interface IGetMoviesService
    {
        Task<IEnumerable<MovieModel>> GetMovies();
    }
}
