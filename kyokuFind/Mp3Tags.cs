using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HundredMilesSoftware.UltraID3Lib;
using System.Diagnostics;
using System.IO;

namespace kyokuFind
{
    /// <summary>
    /// Goes through the directory specified by musicPath colleting music files metadata. It returns a collection
    /// ready for indexing by Lucene.
    /// </summary>
    static class Mp3Tags
    {
        public static string musicPath = @"D:\music";
        public static IEnumerable<Result> CollectTags()
        {
            UltraID3 u = new UltraID3();
            var lstTags = new List<Result>();
            string[] files = Directory.GetFiles(musicPath, "*.mp3", SearchOption.AllDirectories);
            var sw = new Stopwatch();
            sw.Start();
            foreach (var f in files)
            {
                u.Read(f);
                lstTags.Add(new Result { Artist = u.Artist, Title = u.Title, Album = u.Album, Filename = u.FileName, Genre = u.Genre, Year = u.Year.ToString(), Length = u.Duration.ToString() });
                Debug.WriteLine(lstTags.Count + " items processed");
            }
            lstTags.RemoveAt(0);
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds / 1000 + " seconds");
            Debug.WriteLine(lstTags.Count);
            return lstTags;
        }
    }
}
