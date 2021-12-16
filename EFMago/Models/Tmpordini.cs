using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class Tmpordini
    {
        public string IdOrdine { get; set; }
        public DateTime? DataOrdine { get; set; }
        public string CodClienteMago { get; set; }
        public string NoteOrdine { get; set; }
        public DateTime? DataRitiro { get; set; }
        public int IdRiga { get; set; }
        public string Articolo { get; set; }
        public double? Quantita { get; set; }
    }
}
