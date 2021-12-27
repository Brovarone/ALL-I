using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class AllordCliAttivita
    {
        public int IdOrdCli { get; set; }
        public short Line { get; set; }
        public string Attivita { get; set; }
        public DateTime? DataInizio { get; set; }
        public DateTime? DataFine { get; set; }
        public string DaFatturare { get; set; }
        public DateTime? DataRifatturazione { get; set; }
        public string Fatturata { get; set; }
        public string Nota { get; set; }
        public string RifServizio { get; set; }
        public short? RifLinea { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public double? ValUnit { get; set; }


        // Creato da me
        [NotMapped]
        public double? CanoniRipresi { get; set; }
        public virtual MaSaleOrd SaleOrd { get; set; }
        public virtual Allattivita Allattivita { get; set; }
        public virtual AllordCliContratto AllordCliContratto { get; set; }

    }
}
