using System;
using System.IO;

namespace MovieShowVideo.Utilities;

public class UtilityReader
{

    public void readMediaType(string choice)
    {

        var file = "";

        var mediaChoice = choice;

        if (mediaChoice == "movie")
        {
            file = "movies.csv";
            ReadMovies(file);
        }
        
        else if (mediaChoice == "show")
        {
            file = "shows.csv";
            ReadShows(file);
        }
        
        if (mediaChoice == "video")
        {
            file = "video.csv";
            ReadVideos(file);
        }

    }
    
    public void ReadMovies(string file)
    {
        
        StreamReader reader = new StreamReader(file);
        var line = reader.ReadLine();
       
        Console.WriteLine("What ID would you like to start at?");
        var mediaIDSelection = Console.ReadLine();

        try
        {
             

            while (!reader.EndOfStream)
            {
               
                line = reader.ReadLine();
                var row = line.Split(",");

               

                if (row[0].Contains(mediaIDSelection))
                {
                   
                    Console.WriteLine("{0}, {1}, {2}", row[0], row[1], row[2]);

                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        row = line.Split(",");

                        Console.WriteLine("{0}, {1}, {2}", row[0], row[1], row[2]);
                    }
                   

                }


            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
       
        reader.Close();
       
    }
    
    public void ReadShows(string file)
    {
        
        StreamReader reader = new StreamReader(file);
        var line = reader.ReadLine();
       
        Console.WriteLine("What ID would you like to start at?");
        var mediaIDSelection = Console.ReadLine();

        try
        {
             

            while (!reader.EndOfStream)
            {
               
                line = reader.ReadLine();
                var row = line.Split(",");

               

                if (row[0].Contains(mediaIDSelection))
                {
                   
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}", row[0], row[1], row[2], row[3], row[4]);

                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        row = line.Split(",");

                        Console.WriteLine("{0}, {1}, {2}, {3}, {4}", row[0], row[1], row[2], row[3], row[4]);
                    }
                   

                }


            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
       
        reader.Close();
       
    }
    
    public void ReadVideos(string file)
    {
        
        StreamReader reader = new StreamReader(file);
        var line = reader.ReadLine();
       
        Console.WriteLine("What ID would you like to start at?");
        var mediaIDSelection = Console.ReadLine();

        try
        {
             

            while (!reader.EndOfStream)
            {
               
                line = reader.ReadLine();
                var row = line.Split(",");

               

                if (row[0].Contains(mediaIDSelection))
                {
                   
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}", row[0], row[1], row[2], row[3], row[4]);

                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        row = line.Split(",");

                        Console.WriteLine("{0}, {1}, {2}, {3}, {4}", row[0], row[1], row[2], row[3], row[4]);
                    }
                   

                }


            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
       
        reader.Close();
       
    }
    
}