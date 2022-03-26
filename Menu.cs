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

                IUtility writer = new UtilityWriter();

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