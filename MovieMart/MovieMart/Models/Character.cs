namespace MovieMart.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        // Many-to-Many relationship with Movie via CharacterMovie
        public ICollection<CharacterMovie> CharacterMovies { get; set; } = new List<CharacterMovie>();

        public ICollection<CharacterTvSeries> CharacterTvSeries { get; set; } = new List<CharacterTvSeries>();


    }
}
