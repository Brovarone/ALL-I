using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpAvailabilityForecast
    {
        public string Simulation { get; set; }
        public string Item { get; set; }
        public string Variant { get; set; }
        public DateTime SimulatedDate { get; set; }
        public int Line { get; set; }
        public int? ProductKind { get; set; }
        public int? DocumentId { get; set; }
        public string DocNo { get; set; }
        public int? DocumentType { get; set; }
        public double? Qty { get; set; }
        public double? Value { get; set; }
        public int? EventType { get; set; }
        public int? DocLine { get; set; }
        public string Delay { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public string GroupSf { get; set; }
        public string ProdPlanForShortage { get; set; }
        public string ConfirmationLevel { get; set; }
        public DateTime? DocumentDate { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
