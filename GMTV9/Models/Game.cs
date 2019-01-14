using System;
using System.Collections.Generic;

namespace GMTV9.Models
{
    public partial class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public bool? IsSeries { get; set; }
        public int? SeriesNumber { get; set; }
        public string Platform { get; set; }
        public short Year { get; set; }
        public string BarCodeNum { get; set; }
        public bool? HasPlatinum { get; set; }
        public bool? HasTrophies { get; set; }
        public bool? Platinumed { get; set; }
        public bool? AllDone { get; set; }
    }
}
