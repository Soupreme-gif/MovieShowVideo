using System.Collections.Generic;
using System.Linq;
using MovieShowVideo.Models;

namespace MovieShowVideo.Dao
{
    // While the below could use Generics to avoid "duplicate" repositories
    // (ie. MovieRepository, ShowRepository, VideoRepository) I've chosen
    // the simpler implementation for demonstration
    public class MovieRepository : IRepository
    {
        private readonly DataContext _context;

        public MovieRepository()
        {
            _context = new DataContext();
        }

        public List<Media> Get()
        {
            return new List<Media>(_context.Movies);
        }

        public Media Search(string searchString)
        {
            var results = _context.Movies.Where(x => x.MovieTitle.Contains(searchString));
            return results.FirstOrDefault();
        }
    }
}
