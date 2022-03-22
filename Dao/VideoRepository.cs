﻿using System.Collections.Generic;
using System.Linq;
using MovieShowVideo.Models;

namespace MovieShowVideo.Dao
{
    // While the below could use Generics to avoid "duplicate" repositories
    // (ie. MovieRepository, ShowRepository, VideoRepository) I've chosen
    // the simpler implementation for demonstration
    public class VideoRepository : IRepository
    {
        private readonly DataContext _context;

        public VideoRepository()
        {
            _context = new DataContext();
        }

        public List<Media> Get()
        {
            return new List<Media>(_context.GetVideos);
        }

        public Media Search(string searchString)
        {
            var results = _context.GetVideos.Where(x => x.VideoTitle.Contains(searchString));
            return results.FirstOrDefault();
        }
    }
}
