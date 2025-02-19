using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpProdPlanGenerationRef
    {
        public int SaleOrdId { get; set; }
        public short SaleOrdLine { get; set; }
        public string Item { get; set; }
        public DateTime? RefDocDate { get; set; }
        public string ReferenceDocNo { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
