namespace MovieMart.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public int EpisodeNumber { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }

        // One-to-Many: Season <-> Episode
        public int SeasonId { get; set; }
        public Season Season { get; set; } = null!;
    }
}
