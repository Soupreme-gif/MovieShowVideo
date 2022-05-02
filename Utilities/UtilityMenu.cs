using System;

namespace MovieShowVideo.Utilities;

public class UtilityMenu
{
   public void displayMenu()
        {
            
            for (int i = 0; i < Int32.MaxValue; i++)
            {

                UtilityWriter writer = new UtilityWriter();

                Console.WriteLine("Choose an option.");
                Console.WriteLine("1: add movie.");
                Console.WriteLine("2: update a movie");
                Console.WriteLine("3: search for movie.");
                Console.WriteLine("4: display movies");
                Console.WriteLine("5: delete a movie");
                Console.WriteLine("6: add a User");
                Console.WriteLine("7: Display user");
                Console.WriteLine("8: Rate a movie");
                Console.WriteLine("9: Display user ratings");
                Console.WriteLine("10: exit");
                Console.Write("Your choice?: ");

                var response = Console.ReadLine();

                if (response == "1")
                {
                    
                    writer.Write();

                }

                else if (response == "2")
                {
                   
                   writer.UpdateMovie();

                }

                else if (response == "3")
                {
                    Console.Write("Enter search string: ");
                    var searchString = Console.ReadLine();

                    writer.Search(searchString);
                    
                }
                
                else if (response == "4")
                {
                    
                    writer.DisplayMovies();
                    
                }
                
                else if (response == "5")
                {
                    
                    writer.DeleteMovie();
                    
                }

                else if (response == "6")
                {
                    writer.addUser();
                }

                else if (response == "7")
                {
                     writer.displayUsers();
                }
                
                else if (response == "8")
                {
                    writer.RateAMovie();
                }
                
                else if (response == "9")
                {
                    writer.ViewMoviesRatedByUsers();
                }

                else if (response == "10")
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