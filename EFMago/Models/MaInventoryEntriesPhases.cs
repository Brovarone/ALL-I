using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInventoryEntriesPhases
    {
        public int EntryId { get; set; }
        public string Receipted { get; set; }
        public string Cancel { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public DateTime? PostingDate { get; set; }
        public string Storage { get; set; }
        public int? SpecificatorType { get; set; }
        public string Specificator { get; set; }
        public short Line { get; set; }
        public string Item { get; set; }
        public string Department { get; set; }
        public int Phase { get; set; }
        public DateTime? DepartureDate { get; set; }
    }
}
