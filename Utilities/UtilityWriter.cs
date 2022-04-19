using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MovieShowVideo.Context;
using MovieShowVideo.DataModels;


namespace MovieShowVideo.Utilities;

public class UtilityWriter
{

    public void Write()
    {
        using (var context = new MovieContext())
        {

            bool stopAddingGenres = false;

            var movie = new Movie();
            
            Console.WriteLine("Enter in the title of the movie?");
            var movieTitle = Console.ReadLine();

            Console.WriteLine("When did the move come out? please format the release date in Year-month-day format.");
            var date = Console.ReadLine();
            var parsedDate = DateTime.Parse(date);


            movie.Title = movieTitle;
            movie.ReleaseDate = parsedDate;

            context.Movies.Add(movie);
            context.SaveChanges();

            // move into its own method and finish it up
            
            // do
            // {
            //     
            //     var theMovie = context.Movies.FirstOrDefault(m => m.Title == movie.Title);
            //
            //     Console.WriteLine("Enter in a Genre id");
            //     var genreSelection = long.Parse(Console.ReadLine());
            //     
            //
            //     var genre = context.Genres.FirstOrDefault(x => x.Id == genreSelection);
            //
            //     var movieGenre = new MovieGenre();
            //
            //     movieGenre.Genre = genre;
            //     movieGenre.Movie = theMovie;
            //
            //     context.MovieGenres.Add(movieGenre);
            //     context.SaveChanges();
            //
            //
            // }while (stopAddingGenres != true);
            //

        }


    }

    public void DisplayMovies()
    {
        using (var context = new MovieContext())
        {
            
            Console.WriteLine("would you like to display all movies?");
            var decision = Console.ReadLine();

            if (decision.ToLower() == "yes")
            {
                var movies = context.Movies;

                // add a way to limit the amount of printed results
                foreach (var movie in movies)
                {
                    Console.Write($"Movie: {movie?.Title} {movie?.ReleaseDate:MM-dd-yyyy}");
                    
                    foreach (var genre in movie?.MovieGenres ?? new List<MovieGenre>())
                    {
                        Console.Write($"\t{genre.Genre.Name} ");
                    }
                    
                    Console.WriteLine("");
                    
                }
            }
            else
            {
                
                Console.WriteLine("Which movie would you like to look at?");
                var movieOfInterest = Console.ReadLine();
                
                // check to see if movie is in the database or not
                
                var movie = context.Movies.FirstOrDefault(mov => mov.Title.ToLower().Equals(movieOfInterest.ToLower()));

                Console.WriteLine($"Movie: {movie?.Title} {movie?.ReleaseDate:MM-dd-yyyy}");

                Console.WriteLine("Genres:");

                foreach (var genre in movie?.MovieGenres ?? new List<MovieGenre>())
                {
                    Console.WriteLine($"\t{genre.Genre.Name}");
                }
            }
          
        }
        
    }

    public void Update()
    {
        
        Console.WriteLine("Movie title to update?");
        var title = Console.ReadLine();
        
        Console.WriteLine("Enter updated movie title.");
        var updatedTitle = Console.ReadLine();

        using (var context = new MovieContext())
        {
            var updateMovieTitle = context.Movies.FirstOrDefault(x => x.Title.ToLower().Equals(title.ToLower()));

            updateMovieTitle.Title = updatedTitle;

            context.Movies.Update(updateMovieTitle);
            context.SaveChanges();

        }

    }

    public void Delete()
    {
        
        Console.WriteLine("Enter Movie title to Delete: ");
        var title = Console.ReadLine();

        using (var context = new MovieContext())
        {
            var deleteMovieTitle = context.Movies.FirstOrDefault(x => x.Title.ToLower().Equals(title.ToLower()));

            // verify exists first
            if (deleteMovieTitle == null)
            {
                Console.WriteLine("Invalid entry please try again.");
            }
            else
            {
                context.Movies.Remove(deleteMovieTitle);
                context.SaveChanges();
            }
            
        }
        
    }

    public void Search(string searchString)
    {

        using (var context = new MovieContext())
        {
            var results = context.Movies.Where(x => x.Title.Equals(searchString.ToLower()));

            foreach (var result in results.ToList())
            {
                
                Console.WriteLine($"{result.Id}, {result.Title}, {result.ReleaseDate}");
                
            }
        }

    }

    //  public string getTitle()
    //  {
    //      var title = "";
    //
    //      Console.Write("Title of media?: ");
    //      title = Console.ReadLine();
    //      title = title.IndexOf(",") != -1 ? $"\"{title}\"" : title;
    //
    //
    //      return title;
    //  }
    //
    //  public bool IsUnique(string file, string title)
    //  {
    //
    //      var mediaTitle = title;
    //      var isUniqueTitle = true;
    //
    //      StreamReader reader = new StreamReader(file);
    //      var line = reader.ReadLine();
    //
    //      do
    //      {
    //
    //          while (!reader.EndOfStream)
    //          {
    //              line = reader.ReadLine();
    //              var entry = line.Split(",");
    //
    //              if (mediaTitle.ToLower() == entry[1].ToLower())
    //              {
    //                  Console.WriteLine("Sorry this is already in the database. Please try again");
    //                  isUniqueTitle = false;
    //                  break;
    //
    //              }
    //
    //          }
    //
    //      } while (isUniqueTitle == false);
    //
    //      reader.Close();
    //
    //      return isUniqueTitle;
    //  }
    //
    //  private List<string> CreateGenreList()
    //  {
    //
    //      List<string> genreList = new List<string>();
    //      var toContinue = "";
    //
    //      using (var context = new MovieContext())
    //      {
    //          
    //          do
    //          {
    //
    //              Console.WriteLine("what genre is the movie?");
    //              var genre = Console.ReadLine();
    //              genreList.Add(genre);
    //
    //              Console.WriteLine("Would you like to add more genres? type no to exit");
    //              toContinue = Console.ReadLine();
    //
    //          } while (toContinue != "no");
    //          
    //      }
    //
    //     
    //     
    //      return genreList;
    //
    // }
    //
    // public string CreateMediaId(string file)
    // {
    //     StreamReader reader = new StreamReader(file);
    //     var line = reader.ReadLine();
    //     var mediaID = "";
    //
    //     if (reader.EndOfStream)
    //     {
    //         mediaID = "1";
    //     }
    //
    //     while (!reader.EndOfStream)
    //     {
    //         line = reader.ReadLine();
    //         var entry = line.Split(",");
    //         mediaID = entry[0];
    //         //possibly remove the comma if it is in there
    //         var movieIDAsANumber = UInt64.Parse(mediaID);
    //         movieIDAsANumber += 1;
    //         movieIDAsANumber.ToString();
    //         mediaID = movieIDAsANumber.ToString();
    //     }
    //
    //     reader.Close();
    //
    //     return mediaID;
    // }
    //
    //
    //
    //
    //
}