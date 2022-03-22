using System.Collections.Generic;
using MovieShowVideo.Models;

namespace MovieShowVideo.Dao
{
    public class DataContext
    {
        // hardcoded here to simulate that it might come from the datasource (file/database)
        // when we generate our Context from the database this will be replaced
        public List<Movie> GetMovies = new()
        {
            new()
                {Id = 1, Name = "Movie (2022)", MovieTitle = "My New Movie"}
        };

        public List<Show> GetShows = new()
        {
            new()
                {Id = 1, Name = "Show (1999)", ShowTitle = "My Awesome Show"}
        };

        public List<Video> GetVideos = new()
        {
            new()
                {Id = 1, Name = "Video (2002)", VideoTitle = "My Cool Video"}
        };

        public List<Movie> Movies { get; set; }
        public List<Show> Shows { get; set; }
        public List<Video> Videos { get; set; }

        public DataContext()
        {
            Movies = GetMovies;
            Shows = GetShows;
            Videos = GetVideos;
        }
    }
}
