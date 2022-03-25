namespace MovieShowVideo.Models
{
    public class Show : Media
    {
        public string ShowTitle { get; set; }
        
        public string Episode { get; set; }
        
        public string Season { get; set; }
        
        public string Writers { get; set; }
        
        public override string ToString()
        {
            return $"{Id}: {ShowTitle}: {Episode}: {Season}: {Writers} ";
        }
    }
}
