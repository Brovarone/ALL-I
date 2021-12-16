using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpMrpproposals
    {
        public int Line { get; set; }
        public string Simulation { get; set; }
        public int? DocumentType { get; set; }
        public int? DocumentId { get; set; }
        public string DocNo { get; set; }
        public string Product { get; set; }
        public int? ProductKind { get; set; }
        public string Bom { get; set; }
        public string Variant { get; set; }
        public double? ProposedQty { get; set; }
        public string Job { get; set; }
        public string SaleOrdNo { get; set; }
        public short? SaleOrdLine { get; set; }
        public string Customer { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? IssueDate { get; set; }
        public double? OrderQty { get; set; }
        public int? Feasibility { get; set; }
        public string DescriptiveText { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
