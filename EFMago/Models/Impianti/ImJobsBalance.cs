using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobsBalance
    {
        public string Job { get; set; }
        public short Line { get; set; }
        public string Customer { get; set; }
        public string UserName { get; set; }
        public DateTime? ProcessingDate { get; set; }
        public DateTime? BeginningDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public int? AverageCostType { get; set; }
        public int? BalanceType { get; set; }
        public double? BudgetGoodsTotAmount { get; set; }
        public double? BudgetServicesTotAmount { get; set; }
        public double? BudgetLabourTotAmount { get; set; }
        public double? BudgetAddChargesTotAmount { get; set; }
        public double? BudgetOtherTotAmount { get; set; }
        public double? BudgetGeneralExpensesTotAmount { get; set; }
        public double? BudgetTotalAmount { get; set; }
        public double? WorkDonePerc { get; set; }
        public double? ActualGoodsTotAmount { get; set; }
        public double? ActualServicesTotAmount { get; set; }
        public double? ActualLabourTotAmount { get; set; }
        public double? ActualAddChargesTotAmount { get; set; }
        public double? ActualOtherTotAmount { get; set; }
        public double? ActualTotalAmount { get; set; }
        public double? OrderedGoodsTotalAmount { get; set; }
        public double? OrderedServicesTotalAmount { get; set; }
        public double? OrderedTotalAmount { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaJobs JobNavigation { get; set; }
    }
}
