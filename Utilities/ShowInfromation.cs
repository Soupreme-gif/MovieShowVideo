using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieShowVideo.Utilities;

public class ShowInfromation
{

    public string getEpisode()
    {
        
        Console.WriteLine("Which episode?");
        var episode = Console.ReadLine();
        
        return episode;

    }

    public string getSeason()
    {
        
        Console.WriteLine("which season?");
        var season = Console.ReadLine();

        return season;

    }
    
    public string CreateWriterList()
    {

        List<string> writerList = new List<string>();
        var toContinue = "";

        do
        {

            Console.WriteLine("who wrote the show?");
            var writer = Console.ReadLine();
            writer += "|";
            writerList.Add(writer);

            Console.WriteLine("Would you like to add more writers? type no to exit");
            toContinue = Console.ReadLine();

        } while (toContinue != "no");

        var lastEntry = writerList[writerList.Count() - 1];
        writerList.RemoveAt(writerList.Count - 1);

        lastEntry = lastEntry.Remove(lastEntry.Length - 1);

        writerList.Add(lastEntry);

        var listOfWriters = string.Join("|", writerList.ToArray());

        return listOfWriters;

    }
    
}