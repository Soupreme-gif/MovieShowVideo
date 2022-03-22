using System.Collections.Generic;
using MovieShowVideo.Models;

namespace MovieShowVideo.Dao
{
    // all repositories use the context to retrieve data
    // just a couple of example methods are implemented below
    // This sort of interface and classes will remain after 
    // database generation.  It is the Context that will go away
    public interface IRepository
    {
        List<Media> Get();
        Media Search(string searchString);
    }
}
