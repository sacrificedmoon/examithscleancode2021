using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieLibrary.Models
{
    public class DetailedMovie
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string id { get; set; }
        public string title { get; set; }
        public double imdbRating { get; set; }
    }
}
