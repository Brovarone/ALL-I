using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCorrectionDocParameters
    {
        public int IdcorrectionDocParameters { get; set; }
        public string NegativeValueInAccTrans { get; set; }
        public string ModifyOriginalPymtSched { get; set; }
        public int? DenyToInsertQtyGreater { get; set; }
        public int? DenyToDeleteCorrectedLine { get; set; }
        public int? PurchasePriceToPropose { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
