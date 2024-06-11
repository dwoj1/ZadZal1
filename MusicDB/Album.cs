using MusicDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MusicCollectionManager
{
    public struct Album
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public TimeSpan? Duration { get; set; }
        public List<Track> Tracks { get; set; }
        public List<Author> Performers { get; set; }
        public int AlbumId { get; set; }
        public List<Remix> Remixes { get; set; }

        public Album(string title = "0", string type = "CD", TimeSpan? duration = null, List<Track> tracks = null, List<Author> performers = null, int albumId = 0, List<Remix> remixes = null)
        {
            Title = title ?? "0";
            Type = type ?? "CD";
            Duration = duration ?? TimeSpan.Zero;
            Tracks = tracks ?? new List<Track>();
            Performers = performers ?? new List<Author>();
            AlbumId = albumId;
            Remixes = remixes ?? new List<Remix>();
        }

        public bool IsDefault()
        {
            return (Title == null || Title == "0") &&
                   (Type == null || Type == "CD") &&
                   (Duration == null || Duration == TimeSpan.Zero) &&
                   (Tracks == null || Tracks.Count == 0) &&
                   (Performers == null || Performers.Count == 0) &&
                   AlbumId == 0 &&
                   (Remixes == null || Remixes.Count == 0);
        }
    }
}
