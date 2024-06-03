using System;
using System.Collections.Generic;

namespace MusicCollectionManager
{
    public struct Track
    {
        public string Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public List<string> Performers { get; set; }
        public string Composer { get; set; }
        public int TrackNumber { get; set; }


        public Track(string title = "0", TimeSpan? duration = null, List<string> performers = null, string composer = "", int trackNumber = 0)
        {
            Title = title ?? "0";
            Duration = duration ?? TimeSpan.Zero;
            Performers = performers ?? new List<string>();
            Composer = composer ?? "";
            TrackNumber = trackNumber;
        }

        public bool IsDefault()
        {
            return (Title == null || Title == "0") &&
            (Duration == null || Duration == TimeSpan.Zero) &&
            (Performers == null || Performers.Count == 0) &&
            (Composer == null || Composer == "") &&
            TrackNumber == 0;
        }
    }
}
