using System;
using MovieShowVideo.Utilities;

namespace MovieShowVideo;

public class Menu
{
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

                    if (choice.ToLower() == "movie" || choice.ToLower() == "show" || choice.ToLower() == "video")
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

                

            }
            
            else if (response == "3")
            {
                
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