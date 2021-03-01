using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    public class Video
    {
        public UInt64 id {get; set;}
        public string title { get; set;}
       public string format {get; set;}
        public int length {get; set;}
        public int[] regions {get; set;}

        public string Display()
        {
            return $"Id: {id}\nTitle: {title}\nRegions: {string.Join(", ", regions)} \nFormat: {format} \nLength: {length}\n";
        }
     }
}