namespace MovieMart.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? Author { get; set; }
        public string? ImgUrl { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ReleaseYear { get; set; }
        public double? Rating { get; set; }

        // One-to-Many: Movie <-> Category
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // Many-to-Many: Character <-> Movie
        public ICollection<CharacterMovie> CharacterMovies { get; set; } = new List<CharacterMovie>();
    }
}
