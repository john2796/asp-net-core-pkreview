
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
    public class PokemonController : Controller
    {
        // access to Repository methods
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;


        // bring repository
        public PokemonController(IPokemonRepository pokemonRepository, IReviewRepository reviewRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
            _reviewRepository = reviewRepository;

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
        // IActionResult: lets us NotFound, BadRequest, basically action output result
        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId)) return NotFound();
            // _mapper: make properties of PokemonDto to returned result
            var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));
            // do validation
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemen([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonDto pokemonCreate)
        {
            if (pokemonCreate == null) return BadRequest(ModelState);

            var pokemons = _pokemonRepository.GetPokemonTrimToUpper(pokemonCreate);

            if (pokemons != null)
            {
                ModelState.AddModelError("", "Owner already exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<PokemonDto>(pokemonCreate);

            if (!_pokemonRepository.CreatePokemon(ownerId, catId, pokemonMap))
            {
                ModelState.AddModelError("", "Something when wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePokemon(int pokeId, [FromQuery] int ownerId, [FromBody] PokemonDto updatePokemon)
        {
            if (updatePokemon == null ) return BadRequest(ModelState);   
            if (pokeId !== updatePokemon.Id) return BadRequest(ModelState);
            if (!_pokemonRepository.PokemonExists(pokeId)) return NotFound();

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var pokemonMap = _mapper.Map<Pokemon>(updatedPokemon);
            if(!_pokemonRepository.UpdatePokemon(ownerId, catId, pokemonMap))
            {
                ModelState.AddModelError("", "something went wrong updating owner");
                return StatusCode(500, ModelState)
            }
            return NoContent();
        }

        [HttpDelete("{pokeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeletePokmeon(int pokeId)
        {
            if(!_pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }
           // var reviewsToDelete = _pokemonRepository.GetRev

           if(!_pokemonRepository.DeletePokemon(poke)
        }

    }
}
