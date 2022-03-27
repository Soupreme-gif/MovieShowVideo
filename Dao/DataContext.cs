using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MovieShowVideo.Models;

namespace MovieShowVideo.Dao
{
    public class DataContext
    {
        // hardcoded here to simulate that it might come from the datasource (file/database)
        // when we generate our Context from the database this will be replaced
        // private readonly List<Movie> _getMovies = new()
        // {
        //     
        //     new()
        //         {Id = 1, MovieTitle = "My New Movie"}
        // };

        // private readonly List<Show> _getShows = new()
        // {
        //     
        //     
        //     
        //     new()
        //         {Id = 1, ShowTitle = "My Awesome Show"}
        // };
        //
        // private readonly List<Video> _getVideos = new()
        // {
        //     new()
        //         {Id = 1, VideoTitle = "My Cool Video"}
        // };

        public void AddMoviesToList(List<Movie> movies)
        {
            var file = "movies.csv";

            StreamReader reader = new StreamReader(file);
            
            var line = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                
                line = reader.ReadLine();
                var row = line.Split(",");

                Movie movie = new Movie()
                    {Id = row[0], MovieTitle = row[1], Genres = row[2]};
                
                movies.Add(movie);

            }
            
            reader.Close();
        }
        
        public void AddShowsToList(List<Show> shows)
        {
            var file = "shows.csv";

            StreamReader reader = new StreamReader(file);
            
            var line = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                
                line = reader.ReadLine();
                var row = line.Split(",");

                Show show = new Show()
                    {Id = row[0], ShowTitle = row[1], Episode = row[2], Season = row[3], Writers = row[4]};
                
                shows.Add(show);

            }
            
            reader.Close();
        }
        
        public void AddVideosToList(List<Video> videos)
        {
            var file = "video.csv";

            StreamReader reader = new StreamReader(file);
            
            var line = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                
                line = reader.ReadLine();
                var row = line.Split(",");

                Video video = new Video()
                    {Id = row[0], VideoTitle = row[1], Format = row[2], Length = row[3], Regions = row[4]};
                
                videos.Add(video);

            }
            
            reader.Close();
        }



        public List<Movie> Movies { get; set; }
        public List<Show> Shows { get; set; }
        public List<Video> Videos { get; set; }

        public DataContext()
        {

            Movies = new List<Movie>();
            Shows = new List<Show>();
            Videos = new List<Video>();
            
            AddMoviesToList(Movies);
            AddShowsToList(Shows);
            AddVideosToList(Videos);
           // Movies = _getMovies;
           // Shows = _getShows;
           // Videos = _getVideos;
        }
    }
}
