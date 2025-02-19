using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWtparametersInProgrSet
    {
        public string AllMovementType { get; set; }
        public int MovementType { get; set; }
        public string WorkerIsMandatory { get; set; }
        public string TosWithWorkerInProgress { get; set; }
        public string TosNoWorkerAutoassign { get; set; }
        public string TosNoWorkerAssToWorkerOfTeam { get; set; }
        public short? MaxNoOfTos { get; set; }
        public string TosNoWorkerNoInProgress { get; set; }
        public string TosNoWorkerNoTeamAutoassign { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
