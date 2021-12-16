using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrromaneio
    {
        public int RomaneioId { get; set; }
        public int? LastSubId { get; set; }
        public int? LastSubIdRefuel { get; set; }
        public int? LastSubIdPauses { get; set; }
        public string RomaneioNo { get; set; }
        public int? Status { get; set; }
        public DateTime? RomaneioDate { get; set; }
        public int? Driver { get; set; }
        public string Tractor { get; set; }
        public string Trailer { get; set; }
        public DateTime? DepartureDate { get; set; }
        public int? DepartureKm { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public int? ArrivalKm { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
