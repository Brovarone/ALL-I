using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class Lteletture
    {
        public int IdRiga { get; set; }
        public string CodClienteMago { get; set; }
        public string CodiceUtente { get; set; }
        public string Matricola { get; set; }
        public DateTime? DataInizio { get; set; }
        public DateTime? DataFine { get; set; }
        public double? QtaInizio { get; set; }
        public double? QtaFine { get; set; }
        public double? QtaConsumo { get; set; }
        public double? QtaStorno { get; set; }
        public double? QtaConsumoNetto { get; set; }
        public double? QtaForfait { get; set; }
        public double? QtaConsumoFinale { get; set; }
        public double? Tariffa { get; set; }
        public double? Agevolazione { get; set; }
        public double? InteressiStorni { get; set; }
        public int? Idfattura { get; set; }
        public string Descrizione { get; set; }
        public string CodIva { get; set; }
    }
}
