using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImTmpJobEconomicAnalysis
    {
        public string ComputerName { get; set; }
        public string UserName { get; set; }
        public string DocumentName { get; set; }
        public string ParentJob { get; set; }
        public string Job { get; set; }
        public int ComponentType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public string Producer { get; set; }
        public string ProductCtg { get; set; }
        public string ProductSubCtg { get; set; }
        public string HomogeneousCtg { get; set; }
        public double? BudgetQty { get; set; }
        public int? BudgetTime { get; set; }
        public double? BudgetCost { get; set; }
        public double? ActualQty { get; set; }
        public int? ActualTime { get; set; }
        public double? ActualCost { get; set; }
        public double? UnfilledPurchOrdersQty { get; set; }
        public double? UnfilledPurchOrdersCost { get; set; }
        public int SubcontractOrdId { get; set; }
        public int? SubcontractOriginCosts { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
