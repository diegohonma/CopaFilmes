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
    public class ChampionshipsController : ControllerBase
    {
        private readonly ICreateChampionshipService _createChampionshipService;

        public ChampionshipsController(ICreateChampionshipService createChampionshipService)
        {
            _createChampionshipService = createChampionshipService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ChampionshipModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ChampionshipModel>> CreateChampionship([FromBody] List<MovieModel> moviesModel)
        {
            var response = await
                _createChampionshipService.CreateChampionship(moviesModel)
                    .ConfigureAwait(false);

            if (response?.Classification == null)
                return BadRequest("Não foi possível criar o campeonato.");

            return Ok(response);
        }
    }
}