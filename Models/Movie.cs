namespace MovieShowVideo.Models
{
    public class Movie : Media
    {
        public string MovieTitle { get; set; }

        public override string ToString()
        {
            return $"{Name}: {MovieTitle}";
        }
    }
}
