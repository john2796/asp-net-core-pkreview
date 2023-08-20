
/*
 step 12: Repository Pattern | Controller

- design pattern where you can put all your database calls , more reusable

- this file will handle creating endpoints and use Interfaces Repository method here
 
 
@Note: Add IMapper package
- you need automapper to automatically map properties values
- null values won't be returned to client
if you don't use auto mapper and manually do it like so:

var pokemon = new Pokemon()
 {
   Name = pokemons.Name
 }
 */

using AutoMapper; 
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
        private readonly IMapper _mapper;


        // bring repository
        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        // endpoints CRUD
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {

            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());
            // ModelState: form of validation
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId)) return NotFound();
            var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId)) return NotFound();
            var rating = _pokemonRepository.GetPokemonRating(pokeId);
            // validation on Dto , client value etc.
            if (!ModelState.IsValid) return BadRequest(ModelState);
    
            return Ok(rating);
        }
    }
}
