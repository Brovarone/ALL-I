using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaAvailabilityAnalysis
    {
        public int CodeType { get; set; }
        public int DocumentId { get; set; }
        public string DocumentNumber { get; set; }
        public int Line { get; set; }
        public string Item { get; set; }
        public string UoM { get; set; }
        public string Job { get; set; }
        public double? IssuedQuantity { get; set; }
        public double? PickedQuantity { get; set; }
        public DateTime? FromDate { get; set; }
        public int Sequence { get; set; }
    }
}
