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
        static HttpClient client = new HttpClient();
        public MovieAdapter movieAdapter = new MovieAdapter();

        public IEnumerable<DetailedMovie> GetDetailedMovieList()
        {
            List<DetailedMovie> movieList = new List<DetailedMovie>();
            var result = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/detailedMovies.json").Result;
            movieList = JsonSerializer.Deserialize<List<DetailedMovie>>(new StreamReader(result.Content.ReadAsStream()).ReadToEnd());
            return movieList;
        }

        public IEnumerable<Movie> GetToplist()
        {
            List<Movie> movieList = new List<Movie>();
            var result = client.GetAsync("https://ithstenta2020.s3.eu-north-1.amazonaws.com/topp100.json").Result;
            movieList = JsonSerializer.Deserialize<List<Movie>>(new StreamReader(result.Content.ReadAsStream()).ReadToEnd());
            return movieList;
        }

        public IEnumerable<Movie> GetAllMovies(bool orderbyAscending)
        {
            List<Movie> adaptedMovies = new List<Movie>();
            var top100Movies = GetToplist();
            var detailedMovies = GetDetailedMovieList();
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
