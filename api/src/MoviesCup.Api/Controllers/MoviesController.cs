using Microsoft.AspNetCore.Mvc;
using MoviesCup.Application.Interfaces;
using MoviesCup.Application.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MoviesCup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IGetMoviesService _getMoviesService;

        public MoviesController(IGetMoviesService getMoviesService)
        {
            _getMoviesService = getMoviesService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MovieModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<MovieModel>>> Get()
        {
            var response = await _getMoviesService.GetMovies().ConfigureAwait(false);

            if (response == null)
                return BadRequest("Não foi possível localizar os filmes.");

            return Ok(response);
        }
    }
}