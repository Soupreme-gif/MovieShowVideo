namespace MovieShowVideo.Models
{
    public class Video : Media
    {
        public string VideoTitle { get; set; }

        public override string ToString()
        {
            return $"{Name}: {VideoTitle}";
        }
    }
}
