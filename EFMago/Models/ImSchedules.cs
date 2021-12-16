using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSchedules
    {
        public ImSchedules()
        {
            ImSchedulesDetails = new HashSet<ImSchedulesDetails>();
            ImSchedulesEmployees = new HashSet<ImSchedulesEmployees>();
            ImSchedulesRequirements = new HashSet<ImSchedulesRequirements>();
        }

        public int ScheduleId { get; set; }
        public string ScheduleNo { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Customer { get; set; }
        public string Closed { get; set; }
        public string Note { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public DateTime? ExpectedStartingDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public int? ExpectedTime { get; set; }
        public int? ActualTime { get; set; }
        public int? AssignedTime { get; set; }
        public int? SaleDocId { get; set; }
        public string Printed { get; set; }
        public string SaleDocGenerated { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public Guid? Tbguid { get; set; }

        public virtual ICollection<ImSchedulesDetails> ImSchedulesDetails { get; set; }
        public virtual ICollection<ImSchedulesEmployees> ImSchedulesEmployees { get; set; }
        public virtual ICollection<ImSchedulesRequirements> ImSchedulesRequirements { get; set; }
    }
}
