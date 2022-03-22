using System.Collections.Generic;
using System.Linq;
using MovieShowVideo.Models;

namespace MovieShowVideo.Dao
{
    // While the below could use Generics to avoid "duplicate" repositories
    // (ie. MovieRepository, ShowRepository, VideoRepository) I've chosen
    // the simpler implementation for demonstration
    public class ShowRepository : IRepository
    {
        private readonly DataContext _context;

        public ShowRepository()
        {
            _context = new DataContext();
        }

        public List<Media> Get()
        {
            return new List<Media>(_context.Shows);
        }

        public Media Search(string searchString)
        {
            var results = _context.Shows.Where(x => x.ShowTitle.Contains(searchString));
            return results.FirstOrDefault();
        }
    }
}
