using MoviesCup.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesCup.Application.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAll();
    }
}
