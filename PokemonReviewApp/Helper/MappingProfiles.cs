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
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Reviewer, ReviewerDto>();
            CreateMap<Owner, OwnerDto>();

            // you need to map the other way around for sending or recieving mapping properties??
            CreateMap<PokemonDto, Pokemon>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CountryDto, Country>();
            CreateMap<ReviewDto, Review>();
            CreateMap<ReviewerDto, Reviewer>();
            CreateMap<OwnerDto, Owner>();
        }
    }
}
