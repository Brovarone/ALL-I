using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImDataJobItemWorkingSteps
    {
        public string Component { get; set; }
        public string Job { get; set; }
        public string WorkingSteps { get; set; }
        public double? JobComponentQty { get; set; }
        public double? JobComponentTaxableAmount { get; set; }
        public double? CorrectionsQty { get; set; }
        public double? CorrectionsTaxableAmount { get; set; }
        public double? PurchaseOrdQty { get; set; }
        public double? PurchaseOrdQtaxableAmount { get; set; }
        public double? PickingListQty { get; set; }
        public double? PickingListTaxableAmount { get; set; }
        public double? InventoryQty { get; set; }
        public double? InventoryTaxableAmount { get; set; }
        public double? PurchaseDocQty { get; set; }
        public double? PurchaseDocTaxableAmount { get; set; }
        public double? WorkingReportQty { get; set; }
        public double? WorkingReportTaxableAmount { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string Currency { get; set; }
        public string ParentJob { get; set; }
        public string JobTypeOrder { get; set; }
    }
}
