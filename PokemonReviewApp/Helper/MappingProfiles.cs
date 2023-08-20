using AutoMapper;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;


// step 15: 

namespace PokemonReviewApp.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
        }
    }
}
