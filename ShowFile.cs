using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace MovieLibrary
{
    public class ShowFile
    {
        public string filePath { get; set; }
        public List<Show> Shows { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public ShowFile(string showFilePath)
        {
            filePath = showFilePath;
            Shows = new List<Show>();
            try
            {
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Show show = new Show();
                    string line = sr.ReadLine();
                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        string[] showDetails = line.Split(',');
                        show.id = UInt64.Parse(showDetails[0]);
                        show.title = showDetails[1];
                        int[] showDetails2 = new int[]{};
                        show.season = showDetails2[0];
                        show.episode = showDetails2[1];
                        show.writers = showDetails[2].Split('|');
                    }
                    else
                    {
                        show.id = UInt64.Parse(line.Substring(0, idx - 1));
                        line = line.Substring(idx + 1);
                        idx = line.IndexOf('"');
                        show.title = line.Substring(0, idx);
                        line = line.Substring(idx + 2);
                    }
                }
                sr.Close();
                logger.Info("Shows in file {Count}", Shows.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}