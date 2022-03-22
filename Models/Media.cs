namespace MovieShowVideo.Models
{
    // notice the models do not contain any logic
    // all retrieval logic is placed in the repository
    // Also note that the concrete classes have an override but it is
    // not specified here. That is because it is an override of a system
    // method (ToString).
    public abstract class Media
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
