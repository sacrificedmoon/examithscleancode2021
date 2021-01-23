using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models;
using MovieLibrary.Services;

namespace MovieLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController
    {
        private MovieService movieService = new MovieService();

        [HttpGet]
        [Route("/toplist")]
        public IEnumerable<string> Toplist(bool orderByAscending = true)
        {
            var result = movieService.GetAllMovies(orderByAscending);
            return movieService.GetListOfTitles(result);
        }

        [HttpGet]
        [Route("/movie")]
        public Movie GetMovieById(string id)
        {
            var movie = movieService.GetMovieById(id);
            return movie;
        }
    }
}