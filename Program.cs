using System;
using NLog.Web;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace MovieLibrary
{
    class Program
    {

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            // Dependency injection
            var serviceProvider = new ServiceCollection()
            .BuildServiceProvider();

            Console.WriteLine("Enter a genre");
            String searchGenre = Console.ReadLine();

            Console.WriteLine("Enter a title");
            String searchTitle = Console.ReadLine();

            Console.WriteLine("Which media type would you like to display? M - Movie, S -Show, V - Video");
            string mediaChoice = Console.ReadLine();

            string movieFilePath = Directory.GetCurrentDirectory() + "\\movies.csv";
            string showFilePath = Directory.GetCurrentDirectory() + "\\shows.csv";
            string videoFilePath = Directory.GetCurrentDirectory() + "\\videos.csv";

            logger.Info("Program started");

            MovieFile movieFile = new MovieFile(movieFilePath);
            ShowFile showFile = new ShowFile(showFilePath);
            VideoFile videoFile = new VideoFile(videoFilePath);

            do
            {

                if (mediaChoice == "M")
                {
                    foreach (Movie m in movieFile.Movies)
                    {
                        Console.WriteLine(m.Display());
                    }
                }
                else if (mediaChoice == "S")
                {
                    foreach (Show s in showFile.Shows)
                    {
                        Console.WriteLine(s.Display());
                    }
                }
                else if (mediaChoice == "V")
                {
                    foreach (Video v in videoFile.Videos)
                    {
                        Console.WriteLine(v.Display());
                    }
                }
            } while (mediaChoice == "M" || mediaChoice == "S" || mediaChoice == "V");

            logger.Info("Program ended");
        }
    }
}
