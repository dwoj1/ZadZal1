using MusicDB;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MusicCollectionManager
{
    public class Track
    {
        public string Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public List<Author> Performers { get; set; }
        public Author? Composer { get; set; }
        public int TrackNumber { get; set; }


        public Track(string title = "0", TimeSpan? duration = null, List<Author> performers = null, Author? composer = null, int trackNumber = 0)
        {
            Title = title ?? "0";
            Duration = duration ?? TimeSpan.Zero;
            Performers = performers ?? new List<Author>();
            Composer = composer ?? new Author();
            TrackNumber = trackNumber;
        }
    }
}
