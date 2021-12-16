using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobsStatOfAccount
    {
        public string Job { get; set; }
        public short Line { get; set; }
        public int? DocId { get; set; }
        public int? DocType { get; set; }
        public DateTime? DocDate { get; set; }
        public string DocNo { get; set; }
        public double? Amount { get; set; }
        public string InvoiceIsIssued { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public double? AmountInBaseCurr { get; set; }
        public double? GoodsTotalAmount { get; set; }
        public double? GoodsMarkupAmount { get; set; }
        public double? GoodsDiscountsAmount { get; set; }
        public double? GoodsNetAmount { get; set; }
        public double? LabourTotalAmount { get; set; }
        public double? LabourMarkupAmount { get; set; }
        public double? LabourDiscountsAmount { get; set; }
        public double? LabourNetAmount { get; set; }
        public double? ServicesTotalAmount { get; set; }
        public double? ServicesMarkupAmount { get; set; }
        public double? ServicesDiscountsAmount { get; set; }
        public double? ServicesNetAmount { get; set; }
        public double? OtherTotalAmount { get; set; }
        public double? OtherMarkupAmount { get; set; }
        public double? OtherDiscountsAmount { get; set; }
        public double? OtherNetAmount { get; set; }
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
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaJobs JobNavigation { get; set; }
    }
}
