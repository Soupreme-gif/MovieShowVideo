using System;
using MovieShowVideo.Services;

namespace MovieShowVideo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var orchestrator = new MediaOrchestrator();
            orchestrator.displayMenu();
        }
    }
}
