using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCrpsimulations
    {
        public string Simulation { get; set; }
        public string Description { get; set; }
        public DateTime? FromDate { get; set; }
        public int? SimulationType { get; set; }
        public string Signature { get; set; }
        public string Notes { get; set; }
        public int? UseCapacity { get; set; }
        public int? UseWaitTime { get; set; }
        public int? QueueTimeOrigin { get; set; }
        public string UseHierarchy { get; set; }
        public string ParentEarliness { get; set; }
        public string Materials { get; set; }
        public string TeamLoad { get; set; }
        public string ToolingLoad { get; set; }
        public string MaterialsReservation { get; set; }
        public int? EntryValueType { get; set; }
        public int? QueueHours { get; set; }
        public int? WaitHours { get; set; }
        public short? Horizon { get; set; }
        public DateTime? RunDate { get; set; }
        public int? AltRtgStepCriteria { get; set; }
        public string MachineDetail { get; set; }
        public string CustomAltStep { get; set; }
        public string UseOverflow { get; set; }
        public int? EarlinessTardiness { get; set; }
        public string IncludeSaleOrd { get; set; }
        public string PreferredRouting { get; set; }
        public string VersionSelect { get; set; }
        public string AltRtgStep { get; set; }
        public int? AltRoutingCriteria { get; set; }
        public string Mrpsimulation { get; set; }
        public string GetDurationsFromMo { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
