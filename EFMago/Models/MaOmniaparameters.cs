using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaOmniaparameters
    {
        public int ParameterId { get; set; }
        public string FilePathImportMaster { get; set; }
        public string FileNameImportMaster { get; set; }
        public DateTime? LastDateImportMaster { get; set; }
        public string FilePathExport { get; set; }
        public string FileNameExport { get; set; }
        public DateTime? LastDateExport { get; set; }
        public short? LastExportNo { get; set; }
        public string CompanyCode { get; set; }
        public string TaxActivityCode { get; set; }
        public string PurchaseIntraDefault { get; set; }
        public string SaleIntraDefault { get; set; }
        public string FilePathImportCodes { get; set; }
        public string FileNameImportCodes { get; set; }
        public DateTime? LastDateImportCodes { get; set; }
        public string IntraGoodsLawDefault { get; set; }
        public string IntraServiceLawDefault { get; set; }
        public string SanMarinoLawDefault { get; set; }
        public string OtherReverseLawDefault { get; set; }
        public string ExportAdjustment { get; set; }
        public string ExportClosing { get; set; }
        public string ExportOpening { get; set; }
        public string ReverseChargeSubAccount { get; set; }
        public DateTime? LastDateImportCoA { get; set; }
        public string UseOmniacoA { get; set; }
        public string SaleSuspendedLawDefault { get; set; }
        public string MixedRetails { get; set; }
        public string ExportAccReasonDescri { get; set; }
        public string ExportJegldetailNotes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string SplitPaymentLawDefault { get; set; }
        public string ExportDeductibleTax { get; set; }
    }
}
