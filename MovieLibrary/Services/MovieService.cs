using MovieLibrary.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace MovieLibrary.Services
{
    public class MovieService
    {
        public MovieAdapter movieAdapter = new MovieAdapter();
        public MovieFetcher movieFetcher = new MovieFetcher();

        public IEnumerable<Movie> GetAllMovies(bool orderbyAscending)
        {
            List<Movie> adaptedMovies = new List<Movie>();
            var top100Movies = movieFetcher.GetToplist();
            var detailedMovies = movieFetcher.GetDetailedMovieList();
            foreach (var movie in detailedMovies)
            {
                adaptedMovies.Add(movieAdapter.ConvertDetailedMovie(movie));
            }
            IEnumerable<Movie> allMovies = top100Movies.Concat(adaptedMovies);
            return GetSortedList(allMovies, orderbyAscending);
        }

        public IEnumerable<Movie> GetSortedList(IEnumerable<Movie> unsortedList, bool orderByAscending)
        {
            var orderedList = new List<Movie>();
            if (orderByAscending)
            {
                orderedList = unsortedList.OrderBy(e => e.rated).ToList();
            }
            else
            {
                orderedList = unsortedList.OrderByDescending(e => e.rated).ToList();
            }
            return GetListWithoutDuplicates(orderedList);
        }

        public IEnumerable<Movie> GetListWithoutDuplicates(IEnumerable<Movie> sortedList)
        {
            IEnumerable<Movie> checkedList = sortedList
                .GroupBy(m => m.title)
                .Select(g => g.First());
            return checkedList;
        }

        public IEnumerable<string> GetListOfTitles(IEnumerable<Movie> movieList)
        {
            List<string> titleList = new List<string>();
            foreach (var movie in movieList)
            {
                titleList.Add(movie.title);
            }
            return titleList;
        }

        public Movie GetMovieById(string Id)
        {
            var allMovies = GetAllMovies(true);
            var movie = allMovies.FirstOrDefault(m => m.id == Id);
            if (movie == null)
            {
                throw new KeyNotFoundException("There is no such movie in this list");
            }
            return movie;
        }
    }
}
