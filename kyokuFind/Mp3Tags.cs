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
        public static string musicPath;
        /// <summary>
        /// Returns a List of Results for every song in the specified folder.
        /// </summary>
        /// <param name="bgWorker">Used for reporting progress.</param>
        /// <returns></returns>
        public static IEnumerable<Result> CollectTags(System.ComponentModel.BackgroundWorker bgWorker)
        {
            UltraID3 u = new UltraID3();
            IList<Result> lstTags = new List<Result>();
            string[] files = Directory.GetFiles(musicPath, "*.mp3", SearchOption.AllDirectories);
            var sw = new Stopwatch();
            sw.Start();
            foreach (var f in files)
            {
                u.Read(f);
                lstTags.Add(new Result { Artist = u.Artist, Title = u.Title, Album = u.Album, Filename = u.FileName, Genre = u.Genre, Year = u.Year.ToString(), Length = u.Duration.ToString() });

                //progress goes from 0 to 100 so we have to normalize
                //also progress needs to be an integer, if not, the progress bar doesn't show anything
                var percentage = (int)(lstTags.Count / (float)files.Length * 100);
                
                //apart from percentage we send the number of processed files for relating to the user
                bgWorker.ReportProgress(percentage, (new int[] { lstTags.Count, files.Length }));
                
                Debug.WriteLine(String.Format("Processed {0} of {1}", lstTags.Count, files.Length));
            }
            lstTags.RemoveAt(0);
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds / 1000 + " seconds");
            Debug.WriteLine(lstTags.Count);
            return lstTags;
        }
    }
}
