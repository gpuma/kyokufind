using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kyokuFind
{
    /// <summary>
    /// Class where we store retrieved objects, also used for presentation purposes
    /// </summary>
    class Result
    {
        public string Album { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Filename { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }
        public string Length { get; set; }
        public string nSongs { get; set; }
        public string URL { get; set; }
        public float Score { get; set; }

        public string DisplaySong { get { return String.Format("{0} - {1}", Title, Artist); } }
        //if local artist display number of songs, if receommended from last.fm, just display name
        public string DisplayArtist
        {
            get
            {
                return nSongs != null ? String.Format("{0} - {1} songs", Artist, nSongs) :
                    String.Format("{0}", Artist);
            }
        }
        public string DisplayAlbum { get { return String.Format("{0} - {1} songs", Album, nSongs); } }
        public string DisplayGenre { get { return String.Format("{0} - {1} songs", Genre, nSongs); } }
    }
}
