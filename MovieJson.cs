using System.Collections.Generic;

namespace MovieLibrary
{
    public class MovieJson
    {
        public int movieId { get; set; }
        public string title { get; set; }
        public List<string> genres { get; set; }

        public MovieJson()
        {
            this.movieId = 1;
            this.title = "Toy Story (1995)";
            this.genres = new List<string>() 
            {
                "Adventure", "Animation", "Children", "Comedy", "Fantasy"
            };
        }
    }
}