
/*
 step 12: Repository Pattern | Controller

- design pattern where you can put all your database calls , more reusable

- this file will handle creating endpoints and use Interfaces Repository method here
 */

using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{   
    // these are attributes to turn them to controller
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController: Controller
    {
        // access to Repository methods
        private readonly IPokemonRepository _pokemonRepository;

        // bring repository
        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        // endpoints CRUD
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            // var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());
            var pokemons = _pokemonRepository.GetPokemons();
            // ModelState: form of validation
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }
    }
}
