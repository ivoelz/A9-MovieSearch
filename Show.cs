using System;
using System.Collections.Generic;

namespace MovieLibrary
{

    public class Show
    {
        public UInt64 id {get; set;}
        public string title { get; set;}
        public int season {get; set;}
        public int episode {get; set;}
        public string[] writers {get; set;}

        public string Display()
        {
            return $"Id: {id}\nTitle: {title}\nSeason: {season} \nEpisode: {episode} \nWriters: {writers}\n";
        }
    }
}