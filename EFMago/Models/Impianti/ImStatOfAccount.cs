using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImStatOfAccount
    {
        public ImStatOfAccount()
        {
            ImStatOfAccountDetails = new HashSet<ImStatOfAccountDetails>();
            ImStatOfAccountReferences = new HashSet<ImStatOfAccountReferences>();
        }

        public int StatOfAccountId { get; set; }
        public string Job { get; set; }
        public string StatOfAccountNo { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string Issued { get; set; }
        public string Invoiced { get; set; }
        public string Customer { get; set; }
        public double? TotalAmount { get; set; }
        public double? GoodsTotalAmount { get; set; }
        public double? ServicesTotalAmount { get; set; }
        public double? LabourTotalAmount { get; set; }
        public double? OtherTotalAmount { get; set; }
        public double? GoodsMarkupAmount { get; set; }
        public double? ServicesMarkupAmount { get; set; }
        public double? LabourMarkupAmount { get; set; }
        public double? OtherMarkupAmount { get; set; }
        public double? GoodsDiscountsAmount { get; set; }
        public double? ServicesDiscountsAmount { get; set; }
        public double? LabourDiscountsAmount { get; set; }
        public double? OtherDiscountsAmount { get; set; }
        public double? GoodsNetAmount { get; set; }
        public double? ServicesNetAmount { get; set; }
        public double? LabourNetAmount { get; set; }
        public double? OtherNetAmount { get; set; }
        public double? FurtherDiscount { get; set; }
        public double? FurtherDiscountAmount { get; set; }
        public double? AllowancesAmount { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public double? TotalAmountBaseCurr { get; set; }
        public string InvoicingGroupCode { get; set; }
        public string Printed { get; set; }
        public double? TotalCost { get; set; }
        public double? GoodsTotalCost { get; set; }
        public double? ServicesTotalCost { get; set; }
        public double? LabourTotalCost { get; set; }
        public double? OtherTotalCost { get; set; }
        public double? TotalMargin { get; set; }
        public double? GoodsTotalMargin { get; set; }
        public double? ServicesTotalMargin { get; set; }
        public double? LabourTotalMargin { get; set; }
        public double? OtherTotalMargin { get; set; }
        public double? TotalPercMargin { get; set; }
        public double? GoodsTotalPercMargin { get; set; }
        public double? ServicesTotalPercMargin { get; set; }
        public double? LabourTotalPercMargin { get; set; }
        public double? OtherTotalPercMargin { get; set; }
        public double? TotalAmountOriginal { get; set; }
        public double? TotalCostOriginal { get; set; }
        public double? TotalMarginOriginal { get; set; }
        public double? AddAmount { get; set; }
        public double? DeltaMargin { get; set; }
        public string ChkGoods { get; set; }
        public string ChkLabour { get; set; }
        public string ChkServices { get; set; }
        public string ChkOther { get; set; }
        public string RipAll { get; set; }
        public string ChkUseRip { get; set; }
        public DateTime? InvoicePreviewDate { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public Guid? Tbguid { get; set; }
        public string SentByEmail { get; set; }

        public virtual ICollection<ImStatOfAccountDetails> ImStatOfAccountDetails { get; set; }
        public virtual ICollection<ImStatOfAccountReferences> ImStatOfAccountReferences { get; set; }
    }
}
