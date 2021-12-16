using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaUserDefaultByDocType
    {
        public string Branch { get; set; }
        public int WorkerId { get; set; }
        public int DocumentType { get; set; }
        public string Issue { get; set; }
        public string PostAccounting { get; set; }
        public string PostInventory { get; set; }
        public string PostInventoryReturn { get; set; }
        public string Printer { get; set; }
        public string PrintPreview { get; set; }
        public string PostIntrastat { get; set; }
        public string PostPymntSched { get; set; }
        public string PostInspectionOrder { get; set; }
        public string NetOfTax { get; set; }
        public int? IssueCheckType { get; set; }
        public int? PostAccountingCheckType { get; set; }
        public int? PostInventoryCheckType { get; set; }
        public int? PrintCheckType { get; set; }
        public int? PostIntrastatCheckType { get; set; }
        public int? PostPymtSchedCheckType { get; set; }
        public int? InvoicedDncheckType { get; set; }
        public string UpdateAccounting { get; set; }
        public string UpdateInventory { get; set; }
        public string NoRollback { get; set; }
        public string BelowCostCheck { get; set; }
        public string DisableRollBack { get; set; }
        public int? DeletingCheckType { get; set; }
        public string AutomaticRoundingTotPayable { get; set; }
        public double? RoundingTo { get; set; }
        public int? ReferencesPrintType { get; set; }
        public int? CheckNegativeValues { get; set; }
        public int? LineType { get; set; }
        public string DisableUpdIssue { get; set; }
        public string DisableUpdPostAccounting { get; set; }
        public string DisableUpdPostInventory { get; set; }
        public string DisableUpdPostInvReturn { get; set; }
        public string DisableUpdPrinter { get; set; }
        public string DisableUpdPostIntrastat { get; set; }
        public string DisableUpdPostPymntSched { get; set; }
        public string DisableUpdPostInspOrder { get; set; }
        public string SendEmail { get; set; }
        public string DisableUpdSendEmail { get; set; }
        public int? EmailCheckType { get; set; }
        public string Archive { get; set; }
        public string DisableUpdArchive { get; set; }
        public string RoundOffNetPrice { get; set; }
        public string SendPostaLite { get; set; }
        public string DisableUpdSendPostaLite { get; set; }
        public int? PostaLiteCheckType { get; set; }
        public int? PostaLiteDeliveryType { get; set; }
        public int? PostaLitePrintType { get; set; }
        public int? ArchiveCheckType { get; set; }
        public int? SoscheckType { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string ImPost { get; set; }
        public string ImDisableUpdPost { get; set; }
        public string ImPostDn { get; set; }
        public string ImDisableUpdPostDn { get; set; }
        public string ImMergeItems { get; set; }
        public string ImDisableUpdMergeItems { get; set; }
    }
}
