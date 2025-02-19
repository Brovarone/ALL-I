using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImDashboardFilter
    {
        public string UserName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Crpyear { get; set; }
        public string NewQuotaReq { get; set; }
        public string AcceptedQuotaReq { get; set; }
        public string EscapedQuotaReq { get; set; }
        public string RefusedQuotaReq { get; set; }
        public string NewJobQuota { get; set; }
        public string InDraftingJobQuota { get; set; }
        public string DeliveredJobQuota { get; set; }
        public string InNegotiationJobQuota { get; set; }
        public string ClosedWonJobQuota { get; set; }
        public string ClosedLostJobQuota { get; set; }
        public string NewSvjob { get; set; }
        public string InProgressSvjob { get; set; }
        public string SuspendedSvjob { get; set; }
        public string ClosedSvjob { get; set; }
        public string InDisputeSvjob { get; set; }
        public string NewEcoJob { get; set; }
        public string InProgressEcoJob { get; set; }
        public string SuspendedEcoJob { get; set; }
        public string ClosedEcoJob { get; set; }
        public string InDisputeEcoJob { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
