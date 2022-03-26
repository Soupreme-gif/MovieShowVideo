using System;
using System.IO;

namespace MovieShowVideo.Utilities;

public class UtilityWriter
{

    public void Write(string choice)
    {

        var mediaChoice = choice;
        var file = "";
        var title = "";
        var acceptableTitle = false;

        if (mediaChoice == "movie")
        {
            file = "movies.csv";
        }
        else if (mediaChoice == "show")
        {

            file = "shows.csv";

        }
        else if (mediaChoice == "video")
        {
            file = "video.csv";
        }

        do
        {
            title = getTitle();
            acceptableTitle = IsUnique(file, title);
        } while (acceptableTitle == false);

    }

    public string getTitle()
    {
        var title = "";

        Console.Write("Title of movie?: ");
        title = Console.ReadLine();
        title = title.IndexOf(",") != -1 ? $"\"{title}\"" : title;


        return title;
    }
    
    public bool IsUnique(string file, string title)
    {

        var movieTitle = title;
        var isUniqueTitle = true;

        StreamReader reader = new StreamReader(file);
        var line = reader.ReadLine();

        do
        {

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                var entry = line.Split(",");

                if (movieTitle.ToLower() == entry[1].ToLower())
                {
                    Console.WriteLine("Sorry this is already in the database. Please try again");
                    isUniqueTitle = false;
                    break;

                }

            }

        } while (isUniqueTitle == false);

        reader.Close();

        return isUniqueTitle;
    }
    
    
    
}