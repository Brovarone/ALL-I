using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaOperations
    {
        public MaOperations()
        {
            MaOperationsLabour = new HashSet<MaOperationsLabour>();
        }

        public string Operation { get; set; }
        public string Description { get; set; }
        public string Wc { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public string OperationDescriptionFile { get; set; }
        public string Notes { get; set; }
        public string Item { get; set; }
        public string ProcessingTeam { get; set; }
        public int? ProcessingTime { get; set; }
        public double? ProcessingAttendancePerc { get; set; }
        public int? ProcessingWorkingTime { get; set; }
        public short? NoOfProcessingWorkers { get; set; }
        public string SetupTeam { get; set; }
        public int? SetupTime { get; set; }
        public double? SetupAttendancePerc { get; set; }
        public int? SetupWorkingTime { get; set; }
        public short? NoOfSetupWorkers { get; set; }
        public int? QueueTime { get; set; }
        public double? HourlyCost { get; set; }
        public double? UnitCost { get; set; }
        public double? AdditionalCost { get; set; }
        public string CostsOnQty { get; set; }
        public Guid? Tbguid { get; set; }
        public string TotalTime { get; set; }
        public string IsWc { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaOperationsLabour> MaOperationsLabour { get; set; }
    }
}
