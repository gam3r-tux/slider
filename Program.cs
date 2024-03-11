using System;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace slider
{
    class Program
    {
        private static string GIF = ".gif";
        private static string MP4 = ".mp4";   

        static void Main(string[] args)
        {
             string sourceDirectory = @"C:\projects\img";

                string [] fileEntries = Directory.GetFiles(sourceDirectory);
                ArrayList aVideos = new ArrayList();

                foreach (string fileName in fileEntries) {
                    //Console.WriteLine(fileName);
                     if (Path.GetExtension(fileName).Equals(GIF)
                     || Path.GetExtension(fileName).Equals(MP4))
                    {
                        aVideos.Add(Path.Combine(sourceDirectory, fileName));
                    }
                }

                string listVideos = @"C:\projects\img\list_videos.txt";
                string strFile = string.Join(Environment.NewLine, aVideos.ToArray());
                // guardar lista de videos
                using(StreamWriter writetext = new StreamWriter(listVideos))
                {
                    writetext.WriteLine(strFile);
                } 

                 string procPath = "mpv";
                string procParams = "--fs=yes --loop-playlist=inf --playlist=";

                Process proc = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(); 
                startInfo.FileName = procPath; 
                startInfo.Arguments = procParams + listVideos; 
                proc.StartInfo = startInfo; 
                proc.Start();
                proc.WaitForExit();
        }
    }
}
