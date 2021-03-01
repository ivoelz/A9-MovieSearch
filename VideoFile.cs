using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace MovieLibrary
{
    public class VideoFile
    {
        public string filePath { get; set; }
        public List<Video> Videos { get; set; }
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        public VideoFile(string videoFilePath)
        {
            filePath = videoFilePath;
            Videos = new List<Video>();
            try
            {
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    Video video = new Video();
                    string line = sr.ReadLine();
                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        string[] videoDetails = line.Split(',');
                        video.id = UInt64.Parse(videoDetails[0]);
                        video.title = videoDetails[1];
                        video.format = videoDetails[2];
                        int[] videoDetails2 = new int[]{};
                        video.length = videoDetails2[0];
                        videoDetails2[1] = Convert.ToInt32(video.regions);
                    }
                    else
                    {
                        video.id = UInt64.Parse(line.Substring(0, idx - 1));
                        line = line.Substring(idx + 1);
                        idx = line.IndexOf('"');
                        video.title = line.Substring(0, idx);
                        line = line.Substring(idx + 2);
                        video.format = line.Substring(1, idx);
                    }
                }
                sr.Close();
                logger.Info("Videos in file {Count}", Videos.Count);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}