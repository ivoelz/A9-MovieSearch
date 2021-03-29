using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary
{
    public class UserSearch
    {
        public List<object> media = new List<object>();
        public List<string> genres;
        public string title;

        public void readData()
        {
            ShowFile sf = new ShowFile("shows.csv");
            MovieFile mf = new MovieFile("movies.csv");
            VideoFile vf = new VideoFile("videos.csv");

            media.Add(sf.Shows);
            media.Add(mf.Movies);
            media.Add(vf.Videos);
        }

        public void searchGenre(string userGenre)
        {
            readData();
            for (int i = 0; i < media.Count; i++)
            {
                var genres2 = genres.Contains(userGenre);
            }
        }

        public void searchTitle(string userTitle)
        {
            readData();
            for (int i = 0; i < media.Count; i++)
            {
                var titles2 = title.Contains(userTitle);
            } 
        }
    }
}