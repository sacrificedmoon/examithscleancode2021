using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieLibrary.Services
{
    public class MovieFetcher
    {
        static HttpClient client = new HttpClient();
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
    }
}
