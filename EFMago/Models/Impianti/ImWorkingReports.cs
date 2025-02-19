using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImWorkingReports
    {
        public ImWorkingReports()
        {
            ImWorkingReportsActualities = new HashSet<ImWorkingReportsActualities>();
            ImWorkingReportsDetails = new HashSet<ImWorkingReportsDetails>();
            ImWorkingReportsDocuments = new HashSet<ImWorkingReportsDocuments>();
            ImWorkingReportsReferences = new HashSet<ImWorkingReportsReferences>();
            ImWorkingReportsStat = new HashSet<ImWorkingReportsStat>();
        }

        public int WorkingReportId { get; set; }
        public string WorkingReportNo { get; set; }
        public DateTime? WorkingReportDate { get; set; }
        public DateTime? PostingDate { get; set; }
        public string Customer { get; set; }
        public string Payment { get; set; }
        public string PostedToAccounting { get; set; }
        public string Issued { get; set; }
        public string Posted { get; set; }
        public string Printed { get; set; }
        public string InvoiceFollows { get; set; }
        public string Wrreason { get; set; }
        public string StubBook { get; set; }
        public string Job { get; set; }
        public string PostedToCostAccounting { get; set; }
        public int? WorkingReportType { get; set; }
        public double? LabourHourlyRate { get; set; }
        public double? CallServiceCost { get; set; }
        public int? Dnid { get; set; }
        public string Dnno { get; set; }
        public string PriceList { get; set; }
        public string CustomerBank { get; set; }
        public string CompanyBank { get; set; }
        public string AccTpl { get; set; }
        public string TaxJournal { get; set; }
        public string CallService { get; set; }
        public string Labour { get; set; }
        public string Description { get; set; }
        public string InvRsn { get; set; }
        public string StorageStubBook { get; set; }
        public string StoragePhase1 { get; set; }
        public string StoragePhase2 { get; set; }
        public string SpecificatorPhase1 { get; set; }
        public string SpecificatorPhase2 { get; set; }
        public string SaleDocGenerated { get; set; }
        public string PostedToInventory { get; set; }
        public int? EntryId { get; set; }
        public string BalanceFromEmployeesTab { get; set; }
        public string BalanceFromActualitiesTab { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public double? Fixing { get; set; }
        public string FixingIsManual { get; set; }
        public int? WorkingReportTypology { get; set; }
        public string Employee { get; set; }
        public string Qualification { get; set; }
        public string ExternalReference { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public int? Status { get; set; }
        public int? SourceCreated { get; set; }
        public int? SourceModified { get; set; }
        public string SentByEmail { get; set; }

        public virtual ImWorkingReportsSummary ImWorkingReportsSummary { get; set; }
        public virtual ICollection<ImWorkingReportsActualities> ImWorkingReportsActualities { get; set; }
        public virtual ICollection<ImWorkingReportsDetails> ImWorkingReportsDetails { get; set; }
        public virtual ICollection<ImWorkingReportsDocuments> ImWorkingReportsDocuments { get; set; }
        public virtual ICollection<ImWorkingReportsReferences> ImWorkingReportsReferences { get; set; }
        public virtual ICollection<ImWorkingReportsStat> ImWorkingReportsStat { get; set; }
    }
}
