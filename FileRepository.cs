using System;
using System.IO;

namespace MovieLibrary
{
    public class FileRepository
    {
        private readonly string _filename = Path.Combine(Environment.CurrentDirectory, "Files", "movies.csv");
        public FileRepository()
        {
            if (!File.Exists(_filename)) throw new FileNotFoundException($"Unable to locate {_filename}");
        }
    }
}