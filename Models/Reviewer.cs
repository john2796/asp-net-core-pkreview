namespace PokemonReviewApp.Models
{
    public class Reviewer
    {
        public int Id { get; set; }

        public int FirstName { get; set; }

        public int LastName { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
