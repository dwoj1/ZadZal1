using MusicCollectionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDB
{
    public class Remix : Track
    {
        public string? RemixTitle { get; set; }
        public Author? Remixer { get; set; }

        public Remix(string title = "0", TimeSpan? duration = null, List<Author> performers = null, Author? composer = null, int trackNumber = 0, Author? remixer = null, string remixTitle = "0")
            : base(title, duration, performers, composer, trackNumber)
        {
            Remixer = remixer ?? new Author();
            RemixTitle = remixTitle ?? "0";
        }
    }
}
