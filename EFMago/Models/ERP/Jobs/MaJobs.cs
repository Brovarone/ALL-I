using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaJobs
    {
        public MaJobs()
        {
            ImJobsBalance = new HashSet<ImJobsBalance>();
            ImJobsDetails = new HashSet<ImJobsDetails>();
            ImJobsDetailsVcl = new HashSet<ImJobsDetailsVcl>();
            ImJobsDocuments = new HashSet<ImJobsDocuments>();
            ImJobsNotes = new HashSet<ImJobsNotes>();
            ImJobsPeriodsEnjoyment = new HashSet<ImJobsPeriodsEnjoyment>();
            ImJobsReferences = new HashSet<ImJobsReferences>();
            ImJobsSections = new HashSet<ImJobsSections>();
            ImJobsStatOfAccount = new HashSet<ImJobsStatOfAccount>();
            ImJobsSummaryByCompType = new HashSet<ImJobsSummaryByCompType>();
            ImJobsSummaryByCompTypeByWorkingStep = new HashSet<ImJobsSummaryByCompTypeByWorkingStep>();
            ImJobsTaxSummary = new HashSet<ImJobsTaxSummary>();
            ImJobsWithholdingTax = new HashSet<ImJobsWithholdingTax>();
            ImJobsWorkingStep = new HashSet<ImJobsWorkingStep>();
            ImJobsWpr = new HashSet<ImJobsWpr>();
            MaJobsBalances = new HashSet<MaJobsBalances>();
            MaJobsLang = new HashSet<MaJobsLang>();
        }

        public string Job { get; set; }
        public string Description { get; set; }
        public string GroupCode { get; set; }
        public string Customer { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ExpectedStartingDate { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Contract { get; set; }
        public string ContactPerson { get; set; }
        public double? Price { get; set; }
        public double? Collected { get; set; }
        public double? ExpectedCost { get; set; }
        public double? MachineHours { get; set; }
        public double? DepreciationPerc { get; set; }
        public string Inhouse { get; set; }
        public string Disabled { get; set; }
        public string Notes { get; set; }
        public int? JobType { get; set; }
        public string ParentJob { get; set; }
        public Guid? Tbguid { get; set; }
        public string ContractCode { get; set; }
        public string ProjectCode { get; set; }
        public string EijobCode { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public int? ImJobStatus { get; set; }
        public string ImJobSubStatus { get; set; }
        public int ImJobId { get; set; }
        public int ImCrrefType { get; set; }
        public int ImCrrefId { get; set; }

        public virtual ImJobsSummary ImJobsSummary { get; set; }
        public virtual ICollection<ImJobsBalance> ImJobsBalance { get; set; }
        public virtual ICollection<ImJobsDetails> ImJobsDetails { get; set; }
        public virtual ICollection<ImJobsDetailsVcl> ImJobsDetailsVcl { get; set; }
        public virtual ICollection<ImJobsDocuments> ImJobsDocuments { get; set; }
        public virtual ICollection<ImJobsNotes> ImJobsNotes { get; set; }
        public virtual ICollection<ImJobsPeriodsEnjoyment> ImJobsPeriodsEnjoyment { get; set; }
        public virtual ICollection<ImJobsReferences> ImJobsReferences { get; set; }
        public virtual ICollection<ImJobsSections> ImJobsSections { get; set; }
        public virtual ICollection<ImJobsStatOfAccount> ImJobsStatOfAccount { get; set; }
        public virtual ICollection<ImJobsSummaryByCompType> ImJobsSummaryByCompType { get; set; }
        public virtual ICollection<ImJobsSummaryByCompTypeByWorkingStep> ImJobsSummaryByCompTypeByWorkingStep { get; set; }
        public virtual ICollection<ImJobsTaxSummary> ImJobsTaxSummary { get; set; }
        public virtual ICollection<ImJobsWithholdingTax> ImJobsWithholdingTax { get; set; }
        public virtual ICollection<ImJobsWorkingStep> ImJobsWorkingStep { get; set; }
        public virtual ICollection<ImJobsWpr> ImJobsWpr { get; set; }
        public virtual ICollection<MaJobsBalances> MaJobsBalances { get; set; }
        public virtual ICollection<MaJobsLang> MaJobsLang { get; set; }
    }
}
