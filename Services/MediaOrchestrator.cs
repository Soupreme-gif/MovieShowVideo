using System;
using System.Collections.Generic;
using MovieShowVideo.Dao;
using MovieShowVideo.Models;
using MovieShowVideo.Utilities;

namespace MovieShowVideo.Services
{
    // This would also usually use dependency injection to avoid all the hardcoding
    // but for our purposes we need something to "orchestrate" (or bring together)
    // the various pieces we have and to pull the logic away from the main program.
    // Note this also keeps the repository and the context "clean" for reuse.
    // This is not a typical implementation and will go away when we generate our
    // database for the single Movie database
    public class MediaOrchestrator
    {
        private readonly List<Media> _mediaList = new();
        private readonly MovieRepository _movieRepository;
        private readonly ShowRepository _showRepository;
        private readonly VideoRepository _videoRepository;

        public MediaOrchestrator()
        {
            _movieRepository = new MovieRepository();
            _videoRepository = new VideoRepository();
            _showRepository = new ShowRepository();
            
            displayMenu();
        }

        public List<Media> SearchAllMedia(string searchString)
        {
            _mediaList.Add(_movieRepository.Search(searchString));
            _mediaList.Add(_videoRepository.Search(searchString));
            _mediaList.Add(_showRepository.Search(searchString));

            return _mediaList;
        }
        
        public void displayMenu()
    {
        
        
        for (int i = 0; i < Int32.MaxValue; i++)
        {

            Console.WriteLine("Choose an option.");
            Console.WriteLine("1: add media.");
            Console.WriteLine("2: display list of media.");
            Console.WriteLine("3: search for media.");
            Console.WriteLine("4: exit");
            Console.WriteLine("Your choice?: ");

            var response = Console.ReadLine();

            if (response == "1")
            {

                var choice = "";

                for (int j = 0; j < Int32.MaxValue; j++)
                {
                    Console.WriteLine("What type of media is it?");
                    Console.WriteLine("Movie");
                    Console.WriteLine("Show");
                    Console.WriteLine("Video");
                    
                    choice = Console.ReadLine();

                    choice = choice.ToLower();

                    if (choice == "movie" || choice == "show" || choice == "video")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice please try again");
                    }
                    
                }

                UtilityWriter writer = new UtilityWriter();
                writer.Write(choice);

            }
            
            else if (response == "2")
            {
                var choice = "";

                for (int j = 0; j < Int32.MaxValue; j++)
                {
                    Console.WriteLine("What type of media is it?");
                    Console.WriteLine("Movie");
                    Console.WriteLine("Show");
                    Console.WriteLine("Video");
                    
                    choice = Console.ReadLine();

                    choice = choice.ToLower();

                    if (choice == "movie" || choice == "show" || choice == "video")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice please try again");
                    }

                    UtilityReader reader = new UtilityReader();
                    
                    reader.readMediaType(choice);


                }

                UtilityWriter writer = new UtilityWriter();
                writer.Write(choice);
                

            }
            
            else if (response == "3")
            {
                Console.Write("Enter search string: ");
                var searchString = Console.ReadLine();
                var results = SearchAllMedia(searchString);

                Console.WriteLine("Your results are:");
                results.ForEach(Console.WriteLine);
            }
            
            else if (response == "4")
            {
                break;
            }
            
            else
            {
                Console.WriteLine("invalid entry please try again.");
            }
        }
        
    }
    }
}
