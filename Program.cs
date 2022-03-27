using System;
using MovieShowVideo.Services;

namespace MovieShowVideo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var orchestrator = new MediaOrchestrator();

            Console.Write("Enter search string: ");
            var searchString = Console.ReadLine();
            var results = orchestrator.SearchAllMedia(searchString);

            Console.WriteLine("Your results are:");
            results.ForEach(Console.WriteLine);
        }
    }
}
