using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaXgateParameters
    {
        public int XgateParametersId { get; set; }
        public short? UkcustSuppTaxIdNo { get; set; }
        public short? UkcustSuppFiscalCode { get; set; }
        public short? UkcustSuppExternalCode { get; set; }
        public short? UkcontProspSuppTaxIdNo { get; set; }
        public short? UkcontProspSuppFiscalCode { get; set; }
        public short? UkitemsBarCode { get; set; }
        public string PostPymtSchedImportingJe { get; set; }
        public string PostCostAccImportingJe { get; set; }
        public string SkipCustSuppWithoutUk { get; set; }
        public string SkipContProspSuppWithoutUk { get; set; }
        public string SkipItemsWithoutUk { get; set; }
        public string SkipExistingJe { get; set; }
        public string SkipExistingTaxExigibility { get; set; }
        public string SkipExistingPymtSched { get; set; }
        public string SkipExistingFixAssetsEntry { get; set; }
        public string SkipExistingCostAccEntry { get; set; }
        public string SkipExistingIntrastatEntry { get; set; }
        public string SkipExistingFees { get; set; }
        public string SkipExistingPurchaseDoc { get; set; }
        public string SkipExistingSaleDoc { get; set; }
        public string SkipExistingInvEntry { get; set; }
        public string SkipExistingCommEntry { get; set; }
        public string SkipExistingCustQuota { get; set; }
        public string SkipExistingSuppQuota { get; set; }
        public string SkipExistingSaleOrd { get; set; }
        public string SkipExistingPurchaseOrd { get; set; }
        public string SkipExistingCustSupp { get; set; }
        public string SkipExistingContProspSupp { get; set; }
        public string SkipExistingItem { get; set; }
        public string DisableCustSuppAutonum { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
