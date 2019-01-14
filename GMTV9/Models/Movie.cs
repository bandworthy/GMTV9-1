using System;
using System.Collections.Generic;

namespace GMTV9.Models
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int? Rating { get; set; }
    }
}
