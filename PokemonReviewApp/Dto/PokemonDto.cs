

/*
 step 13: Repository Pattern | Dto

- design pattern where you can put all your database calls , more reusable

- This file is for:
- Dto are way making sure you're not returning all data.
- properties to expose to client
- limit data people can send and recieve to api
 */


namespace PokemonReviewApp.Dto
{
    public class PokemonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
