using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInvAccTransParameters
    {
        public int Id { get; set; }
        public string PurchaseInvoiceExtAccTemp { get; set; }
        public string PurcInvExtAccTempIntegrated { get; set; }
        public string CorrPurchaseInvExtAccTemp { get; set; }
        public string CorrPurcInvExtAccTempInt { get; set; }
        public string SaleInvoiceExtAccTemp { get; set; }
        public string SaleInvExtAccTempIntegrated { get; set; }
        public string CorrSaleInvoiceExtAccTem { get; set; }
        public string CorrSaleInvExtAccTempIntegra { get; set; }
        public string IsRetailOnly { get; set; }
        public string IsRetailAndWholesale { get; set; }
        public string PurCrNoteInvExtAcc { get; set; }
        public string PurCrNoteInvExtAccInt { get; set; }
        public string SaleCrNoteInvExtAcc { get; set; }
        public string SaleCrNoteInvExtAccInt { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string UseSpecAccForExcDiff { get; set; }
    }
}
