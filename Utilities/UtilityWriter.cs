using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieShowVideo.Context;
using MovieShowVideo.DataModels;


namespace MovieShowVideo.Utilities;

public class UtilityWriter
{

    public void Write()
    {
        using (var context = new MovieContext())
        {

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

            addGenresToMovie(movie);

        }


    }

    private void addGenresToMovie(Movie movie)
    {

        bool stopAddingGenres = false;

        using (var context = new MovieContext())
        {

            do
            {

                var theMovie = context.Movies.FirstOrDefault(m => m.Title == movie.Title);

                Console.WriteLine("Enter in a Genre id");
                var genreSelection = long.Parse(Console.ReadLine());


                var genre = context.Genres.FirstOrDefault(x => x.Id == genreSelection);

                var movieGenre = new MovieGenre();

                movieGenre.Genre = genre;
                movieGenre.Movie = theMovie;

                context.MovieGenres.Add(movieGenre);
                context.SaveChanges();

                Console.WriteLine("would you like to add more genres?");
                var choice = Console.ReadLine();

                if (choice.ToLower() == "yes")
                {
                    stopAddingGenres = false;
                }
                else
                {
                    stopAddingGenres = true;
                }


            } while (stopAddingGenres != true);
        }
    }

    public void DisplayMovies()
    {
        using (var context = new MovieContext())
        {

            Console.WriteLine("would you like to display all movies? yes or no");
            var decision = Console.ReadLine();

            if (decision.ToLower() == "yes")
            {
                var movies = context.Movies.Take(15);

                foreach (var movie in movies.ToList())
                {
                    Console.WriteLine($"Movie: {movie?.Title} {movie?.ReleaseDate:MM-dd-yyyy} ");
                    Console.WriteLine("\tGenres:");

                    foreach (var genre in movie?.MovieGenres ?? new List<MovieGenre>())
                    {
                        Console.WriteLine($"\t{genre?.Genre.Name}");
                    }

                    Console.WriteLine("");

                }
            }
            else if (decision.ToLower() == "no")
            {

                Console.WriteLine("Which movie would you like to look at?");
                var movieOfInterest = Console.ReadLine();

                // check to see if movie is in the database or not

                var movie = context.Movies.FirstOrDefault(mov => mov.Title.ToLower().Equals(movieOfInterest.ToLower()));

                Console.WriteLine($"Movie: {movie?.Title} {movie?.ReleaseDate:MM-dd-yyyy}");

                Console.WriteLine("\tGenres:");

                foreach (var genre in movie?.MovieGenres ?? new List<MovieGenre>())
                {
                    Console.WriteLine($"\t{genre?.Genre.Name}");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice please try again.");
            }

        }

    }

    public void UpdateMovie()
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

    public void DeleteMovie()
    {

        Console.WriteLine("Enter Movie title to Delete: ");
        var title = Console.ReadLine();

        using (var context = new MovieContext())
        {
            var deleteMovieTitle = context.Movies.FirstOrDefault(x => x.Title.ToLower().Equals(title.ToLower()));
            var correspondingMovieGenres = context.MovieGenres
                .FirstOrDefault(x => x.Movie == deleteMovieTitle);
            

            // verify exists first
            if (deleteMovieTitle == null)
            {
                Console.WriteLine("Invalid entry please try again.");
            }
            else
            {
                context.Movies.Remove(deleteMovieTitle);
                context.MovieGenres.Remove(correspondingMovieGenres);
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

                Console.WriteLine($"{result.Id}, {result.Title}, {result.ReleaseDate} ");
                Console.WriteLine("\tGenres");

                foreach (var genre in result?.MovieGenres ?? new List<MovieGenre>())
                {
                    Console.WriteLine($"\t{genre.Genre.Name} ");
                }

            }
        }

    }

    public void addUser()
    {

        using (var context = new MovieContext())
        {

            User newUser = new User();

            Console.WriteLine("What is the age of the user?");
            var age = Console.ReadLine();
            var ageAsANumber = long.Parse(age);

            Console.WriteLine("What is the gender of the user?");
            var gender = Console.ReadLine();


            Console.WriteLine("what is your zipcode?");
            var zipcode = Console.ReadLine();

            Console.WriteLine("Enter in occupation number.");
            var occupation = Console.ReadLine();
            var occupationNumber = long.Parse(occupation);


            newUser.Age = ageAsANumber;
            newUser.Gender = gender;
            newUser.ZipCode = zipcode;
            newUser.Occupation = context.Occupations.FirstOrDefault(x => x.Id == occupationNumber);

            context.Add(newUser);
            context.SaveChanges();

        }

    }

    public void displayUsers()
    {

        using (var context = new MovieContext())
        {

            Console.WriteLine("which user do you want to display");
            var id = Console.ReadLine();
            var idAsANumber = long.Parse(id);

            var users = context.Users.Include(x=>x.Occupation)
                                .Where(x=> x.Id == idAsANumber).ToList();
            foreach (var user in users) 
            { 
                Console.WriteLine($"Display user: ({user.Id}), {user.Gender}, ({user.Age}), {user.ZipCode}, {user.Occupation.Name}");
            }
            

        }

    }

}