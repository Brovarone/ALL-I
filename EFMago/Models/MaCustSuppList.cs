using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCustSuppList
    {
        public int CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public short BalanceYear { get; set; }
        public string IsManual { get; set; }
        public string CreditNotes { get; set; }
        public int? NumberOfInvoices { get; set; }
        public double? TaxableAmount { get; set; }
        public double? TaxAmount { get; set; }
        public double? NoTaxable { get; set; }
        public double? Exempt { get; set; }
        public double? TaxAmountNotInInvoice { get; set; }
        public double? TaxableAmountWithTax { get; set; }
        public string Grouping { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
