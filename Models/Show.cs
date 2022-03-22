namespace MovieShowVideo.Models
{
    public class Show : Media
    {
        public string ShowTitle { get; set; }

        public override string ToString()
        {
            return $"{Name}: {ShowTitle}";
        }
    }
}
