using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Services
{
    public class MovieAdapter
    {
        public Movie ConvertDetailedMovie(DetailedMovie detailedMovie)
        {
            Movie movie = new Movie()
            {
                id = detailedMovie.id,
                title = detailedMovie.title,
                rated = detailedMovie.imdbRating.ToString()
            };
            return movie;
        }
    }
}
