namespace MovieShowVideo.Models
{
    public class Video : Media
    {
        public string VideoTitle { get; set; }
        
        public string Format {get; set;}
        public string Length { get; set; }
        public string Regions { get; set; }
        
        
        

        public override string ToString()
        {
            return $"{Id}: {VideoTitle}: {Format}: {Length}: {Regions}";
        }
    }
}
