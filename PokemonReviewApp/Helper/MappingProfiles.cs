using AutoMapper;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;


// step 15: Add Model Mapping Profiles to Dto file.

namespace PokemonReviewApp.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            // need this for mapping properties for GET request sending data to client
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();
            CreateMap<Owner, OwnerDto>();

            // need this for updating and creating
            CreateMap<PokemonDto, Pokemon>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CountryDto, Country>();
            CreateMap<ReviewDto, Review>();
            CreateMap<ReviewerDto, Reviewer>();
            CreateMap<OwnerDto, Owner>();
        }
    }
}
