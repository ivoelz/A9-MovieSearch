using System;
using NLog.Web;
using System.IO;
using System.Collections.Generic;

namespace MovieLibrary
{
    class Program
    {
        // create static instance of Logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            string movieFilePath = Directory.GetCurrentDirectory() + "\\movies.csv";

            logger.Info("Program started");

            MovieFile movieFile = new MovieFile(movieFilePath);

            logger.Info("Program ended");
        }
    }
}
