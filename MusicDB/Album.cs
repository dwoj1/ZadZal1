using System;
using System.Collections.Generic;

namespace MusicCollectionManager
{
    public struct Album
    {
        public string Title { get; set; }
        public string Type { get; set; } // CD or DVD
        public TimeSpan? Duration { get; set; }
        public List<Track> Tracks { get; set; }
        public List<string> Performers { get; set; }
        public int AlbumId { get; set; }

        public Album(string title = "0", string type = "CD", TimeSpan? duration = null, List<Track> tracks = null, List<string> performers = null, int albumId = 0)
        {
            Title = title ?? "0";
            Type = type ?? "CD";
            Duration = duration ?? TimeSpan.Zero;
            Tracks = tracks ?? new List<Track>();
            Performers = performers ?? new List<string>();
            AlbumId = albumId;
        }

        public bool IsDefault()
        {
            return (Title == null || Title == "0") &&
            (Type == null || Type == "CD") &&
            (Duration == null || Duration == TimeSpan.Zero) &&
            (Tracks == null || Tracks.Count == 0) &&
            (Performers == null || Performers.Count == 0) &&
            AlbumId == 0;
        }
    }
}
