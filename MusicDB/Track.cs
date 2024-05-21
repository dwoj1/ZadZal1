using System;
using System.Collections.Generic;

namespace MusicCollectionManager
{
    public class Track
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public List<string> Performers { get; set; }
        public string Composer { get; set; }
        public int TrackNumber { get; set; }
    }
}
