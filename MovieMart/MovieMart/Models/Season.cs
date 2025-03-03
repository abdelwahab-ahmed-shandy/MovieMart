namespace MovieMart.Models
{
    public class Season
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int SeasonNumber { get; set; }

        // One-to-Many: TvSeries <-> Season
        public int TvSeriesId { get; set; }
        public TvSeries TvSeries { get; set; } = null!;

        // One-to-Many: Season <-> Episode
        public ICollection<Models.Episode> Episodes { get; set; } = new List<Episode>();

    }
}
