using System;
using System.Collections.Generic;

namespace MovieLibrary
{
    public class SearchModel : UserSearch
    {
        public List<string> genres {get; set;}
        public string title {get; set;}
    }
}