using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieShowVideo.Utilities;

public class ExclusiveVideoInformation
{
    public string CreateFormatList()
    {

        List<string> formatList = new List<string>();
        var toContinue = "";

        do
        {

            Console.WriteLine("What format is this video?");
            var format = Console.ReadLine();
            format += "|";
            formatList.Add(format);

            Console.WriteLine("Would you like to add more writers? type no to exit");
            toContinue = Console.ReadLine();

        } while (toContinue != "no");

        var lastEntry = formatList[formatList.Count() - 1];
        formatList.RemoveAt(formatList.Count - 1);

        lastEntry = lastEntry.Remove(lastEntry.Length - 1);

        formatList.Add(lastEntry);

        var listOfFormats = string.Join("|", formatList.ToArray());

        return listOfFormats;

    }
    
    public string getLength()
    {
        
        Console.WriteLine("How long is it? (in minutes)");
        var length = Console.ReadLine();
        
        return length;

    }
    
    public string CreateRegionList()
    {

        List<string> regionList = new List<string>();
        var toContinue = "";

        do
        {

            Console.WriteLine("What is the region for this video?");
            var region = Console.ReadLine();
            region += "|";
            regionList.Add(region);

            Console.WriteLine("Would you like to add more regions? type no to exit");
            toContinue = Console.ReadLine();

        } while (toContinue != "no");

        var lastEntry = regionList[regionList.Count() - 1];
        regionList.RemoveAt(regionList.Count - 1);

        lastEntry = lastEntry.Remove(lastEntry.Length - 1);

        regionList.Add(lastEntry);

        var listOfRegions = string.Join("|", regionList.ToArray());

        return listOfRegions;

    }


}