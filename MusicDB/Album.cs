using System;
using System.Collections.Generic;

namespace MusicCollectionManager
{
    public class Album
    {
        public string Title { get; set; }
        public string Type { get; set; } 
        public TimeSpan Duration { get; set; }
        public List<Track> Tracks { get; set; }
        public List<string> Performers { get; set; }
        public int AlbumId { get; set; }

        public Album()
        {
            Tracks = new List<Track>();
            Performers = new List<string>();
        }
    }
}
