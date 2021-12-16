using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaVtaxDocSendings
    {
        public int TaxDocSendingId { get; set; }
        public string TaxDocSendingNo { get; set; }
        public int? SendingType { get; set; }
        public int? SendingStatus { get; set; }
        public DateTime? SetupDate { get; set; }
        public string Retails { get; set; }
        public int JournalEntryId { get; set; }
        public DateTime? TaxAccrualDate { get; set; }
        public string BlackListCustSupp { get; set; }
        public int? CustSuppType { get; set; }
        public string DocNo { get; set; }
        public string LogNo { get; set; }
        public string AccTpl { get; set; }
        public string TaxJournal { get; set; }
        public int? TaxSign { get; set; }
        public double? TotalAmount { get; set; }
        public string CompanyName { get; set; }
        public string TaxIdNumber { get; set; }
        public string FiscalCode { get; set; }
        public string IsCustoms { get; set; }
        public string IsoCountryCode { get; set; }
        public string UsedForSummaryDocuments { get; set; }
        public short Line { get; set; }
    }
}
