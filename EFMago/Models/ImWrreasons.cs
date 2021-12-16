using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImWrreasons
    {
        public string Reason { get; set; }
        public string Description { get; set; }
        public string InvoiceFollows { get; set; }
        public string StubBook { get; set; }
        public string CallService { get; set; }
        public string LabourService { get; set; }
        public int? WorkingReportType { get; set; }
        public string DescriptionForInvoice { get; set; }
        public string GenerateDn { get; set; }
        public string GenerateInvEntry { get; set; }
        public string Dnreason { get; set; }
        public string InvEntryReason { get; set; }
        public int? UseImpiantiSchedule { get; set; }
        public string BalanceFromEmployeesTab { get; set; }
        public string BalanceFromActualitiesTab { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
