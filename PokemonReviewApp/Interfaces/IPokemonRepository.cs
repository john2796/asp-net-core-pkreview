
/*
 step 10: Repository Pattern | Repository 

- design pattern where you can put all your database calls , more reusable
- aims to make your code less tightly coupled (means all in one place)

- this file you will expose the methods you can use to perform action on database
 */

using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IPokemonRepository
    {
        // ICollection same as list but cannot be editable
        ICollection<Pokemon> GetPokemons(); 
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        Pokemon GetPokemonTrimToUpper(PokemonDto pokemonCreate);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);
        bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);
        bool UpdatePokemon(int owerId, int categoryId, Pokemon pokemon);
        bool DeletePokemon(Pokemon pokemon);
        bool Save();
        
    }
}
