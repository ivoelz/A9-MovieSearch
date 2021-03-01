using System;
using System.Collections.Generic;

namespace Media 
{
    public abstract class Media 
    {
        public UInt64 id {get; set;}
        public string title { get; set;}
        public List<string> genres {get; set;}

        public Media()
        {
            genres = new List<string>();
        }
        public string Display()
        {
            return $"Id: {id}\nTitle: {title}\nGenres: {string.Join(", ", genres)}\n";
        }
    }
}