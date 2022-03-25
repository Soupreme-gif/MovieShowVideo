namespace MovieShowVideo.Models
{
    public class Movie : Media
    {
        public string MovieTitle { get; set; }
        
        public string Genres { get; set; }

        public override string ToString()
        {
            return $"{Id}: {MovieTitle}: {Genres}";
        }
    }
}
