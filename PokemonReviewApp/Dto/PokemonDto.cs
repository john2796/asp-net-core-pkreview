

/*
 step 13: Repository Pattern | Dto

- design pattern where you can put all your database calls , more reusable

- What is this file for ??
 Are these properties to expose to client??
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
