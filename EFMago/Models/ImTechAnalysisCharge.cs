using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImTechAnalysisCharge
    {
        public string UserLogin { get; set; }
        public string Job { get; set; }
        public int DocumentSrcType { get; set; }
        public int DocumentId { get; set; }
        public int Line { get; set; }
        public string ProcessKey { get; set; }
        public int? JobType { get; set; }
        public string SrcType { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
        public string UoMbase { get; set; }
        public string UoM { get; set; }
        public double? QtyBase { get; set; }
        public double? Qty { get; set; }
        public double? UnitCostBase { get; set; }
        public double? UnitCost { get; set; }
        public double? TotalCost { get; set; }
        public string WorkingStep { get; set; }
        public string Employee { get; set; }
        public string EmployeeName { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string Note { get; set; }
        public string CostAction { get; set; }
        public DateTime? DocTbcreated { get; set; }
        public DateTime? DocTbmodified { get; set; }
        public int? DocTbcreatedId { get; set; }
        public int? DocTbmodifiedId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
