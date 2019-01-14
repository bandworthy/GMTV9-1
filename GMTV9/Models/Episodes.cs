using System;
using System.Collections.Generic;

namespace GMTV9.Models
{
    public partial class Episodes
    {
        public int EpisodeId { get; set; }
        public string Title { get; set; }
        public int EpisodeNum { get; set; }
        public int Season { get; set; }
        public int? ShowId { get; set; }

        public Tvshows Show { get; set; }
    }
}
