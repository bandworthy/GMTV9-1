using System;
using System.Collections.Generic;

namespace GMTV9.Models
{
    public partial class Tvshows
    {
        public Tvshows()
        {
            Episodes = new HashSet<Episodes>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public ICollection<Episodes> Episodes { get; set; }
    }
}
