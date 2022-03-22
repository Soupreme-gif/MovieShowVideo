using System.Collections.Generic;
using MovieShowVideo.Dao;
using MovieShowVideo.Models;

namespace MovieShowVideo.Services
{
    // This would also usually use dependency injection to avoid all the hardcoding
    // but for our purposes we need something to "orchestrate" (or bring together)
    // the various pieces we have and to pull the logic away from the main program.
    // Note this also keeps the repository and the context "clean" for reuse.
    // This is not a typical implementation and will go away when we generate our
    // database for the single Movie database
    public class MediaOrchestrator
    {
        private readonly List<Media> _mediaList = new();
        private readonly MovieRepository _movieRepository;
        private readonly ShowRepository _showRepository;
        private readonly VideoRepository _videoRepository;

        public MediaOrchestrator()
        {
            _movieRepository = new MovieRepository();
            _videoRepository = new VideoRepository();
            _showRepository = new ShowRepository();
        }

        public List<Media> SearchAllMedia(string searchString)
        {
            _mediaList.Add(_movieRepository.Search(searchString));
            _mediaList.Add(_videoRepository.Search(searchString));
            _mediaList.Add(_showRepository.Search(searchString));

            return _mediaList;
        }
    }
}
