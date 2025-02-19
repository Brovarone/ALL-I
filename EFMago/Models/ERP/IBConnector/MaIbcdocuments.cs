using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaIbcdocuments
    {
        public string Configuration { get; set; }
        public int DocumentType { get; set; }
        public int? DocumentClass { get; set; }
        public int? DocumentCycle { get; set; }
        public int? ValueSign { get; set; }
        public int? CostSign { get; set; }
        public int? CommissionSign { get; set; }
        public int? QuantitySign { get; set; }
        public string CompanyName { get; set; }
        public int? SalesDocumentType { get; set; }
        public int? PurchasesDocumentType { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
