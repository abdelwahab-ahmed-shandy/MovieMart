namespace MovieMart.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        // One-to-Many: Movie <-> Category
        public ICollection<Models.Movie> Movies { get; set; } = new List<Movie>();
    }
}
