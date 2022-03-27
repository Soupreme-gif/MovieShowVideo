using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MovieShowVideo.Models;

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
            
            do
            {
                title = getTitle();
                acceptableTitle = IsUnique(file, title);
            } while (acceptableTitle == false);
        
            var genreList = CreateGenreList();
            var mediaID = CreateMediaId(file);
        
            var row = $"{mediaID},{title},{genreList}";
        
            StreamWriter writer = new StreamWriter(file, true);
        
            writer.WriteLine(row);
        
            writer.Close();

        }
        else if (mediaChoice == "show")
        {

            file = "shows.csv";

            var mediaID = CreateMediaId(file);
            
            do
            {
                title = getTitle();
                acceptableTitle = IsUnique(file, title);
            } while (acceptableTitle == false);

            ExclusiveShowInformation info = new ExclusiveShowInformation();
            
            var episode = info.getEpisode();
            var season = info.getSeason();
            var writers = info.CreateWriterList();
            
            var row = $"{mediaID},{title},{episode},{season},{writers}";
        
            StreamWriter writer = new StreamWriter(file, true);
        
            writer.WriteLine(row);
        
            writer.Close();


        }
        else if (mediaChoice == "video")
        {
            file = "video.csv";
            
            var mediaID = CreateMediaId(file);
            
            do
            {
                title = getTitle();
                acceptableTitle = IsUnique(file, title);
            } while (acceptableTitle == false);

            ExclusiveVideoInformation videoInformation = new ExclusiveVideoInformation();

            var formats = videoInformation.CreateFormatList();
            var length = videoInformation.getLength();
            var regions = videoInformation.getLength();
            
            var row = $"{mediaID},{title},{formats},{length},{regions}";
        
            StreamWriter writer = new StreamWriter(file, true);
        
            writer.WriteLine(row);
        
            writer.Close();

        }


    }

    public string getTitle()
    {
        var title = "";

        Console.Write("Title of media?: ");
        title = Console.ReadLine();
        title = title.IndexOf(",") != -1 ? $"\"{title}\"" : title;


        return title;
    }
    
    public bool IsUnique(string file, string title)
    {

        var mediaTitle = title;
        var isUniqueTitle = true;

        StreamReader reader = new StreamReader(file);
        var line = reader.ReadLine();

        do
        {

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                var entry = line.Split(",");

                if (mediaTitle.ToLower() == entry[1].ToLower())
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
    
    private string CreateGenreList()
    {

        List<string> genreList = new List<string>();
        var toContinue = "";

        do
        {

            Console.WriteLine("what genre is the movie?");
            var genre = Console.ReadLine();
            genre += "|";
            genreList.Add(genre);

            Console.WriteLine("Would you like to add more genres? type no to exit");
            toContinue = Console.ReadLine();

        } while (toContinue != "no");

        var lastEntry = genreList[genreList.Count() - 1];
        genreList.RemoveAt(genreList.Count - 1);

        lastEntry = lastEntry.Remove(lastEntry.Length - 1);

        genreList.Add(lastEntry);

        var listOfGenres = string.Join("|", genreList.ToArray());

        return listOfGenres;

    }
    
    public string CreateMediaId(string file)
    {
        StreamReader reader = new StreamReader(file);
        var line = reader.ReadLine();
        var mediaID = "";

        if (reader.EndOfStream)
        {
            mediaID = "1";
        }

        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();
            var entry = line.Split(",");
            mediaID = entry[0];
            //possibly remove the comma if it is in there
            var movieIDAsANumber = UInt64.Parse(mediaID);
            movieIDAsANumber += 1;
            movieIDAsANumber.ToString();
            mediaID = movieIDAsANumber.ToString();
        }

        reader.Close();

        return mediaID;
    }


    
    
    
}