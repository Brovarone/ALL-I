using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImWorkingReportsActualities
    {
        public int WorkingReportId { get; set; }
        public short Line { get; set; }
        public string Job { get; set; }
        public int? JobLineId { get; set; }
        public int? ComponentType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public double? Quantity { get; set; }
        public int? Time { get; set; }
        public double? Cost { get; set; }
        public string Note { get; set; }
        public DateTime? WorkingReportDate { get; set; }
        public string InvoiceFollows { get; set; }
        public double? UnitValue { get; set; }
        public double? Discount1 { get; set; }
        public double? Discount2 { get; set; }
        public string DiscountFormula { get; set; }
        public double? DiscountAmount { get; set; }
        public double? TaxableAmount { get; set; }
        public string TaxCode { get; set; }
        public double? TotalAmount { get; set; }
        public string IsOnJobEconomicAnalysis { get; set; }
        public string NotOnDn { get; set; }
        public string NotOnInvEntry { get; set; }
        public string Employee { get; set; }
        public string WorkingStep { get; set; }
        public string PostedToAccounting { get; set; }
        public string Lot { get; set; }
        public double? LotUnitValue { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public short? CrrefLine { get; set; }

        public virtual ImWorkingReports WorkingReport { get; set; }
    }
}
