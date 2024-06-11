using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDB
{
    public struct Author
    {
        public string Name { get; set; }

        public Author(string name = "")
        {
            Name = name ?? "";
        }
    }
}
