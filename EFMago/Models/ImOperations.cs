using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImOperations
    {
        public ImOperations()
        {
            ImOperationsDetails = new HashSet<ImOperationsDetails>();
            ImOperationsFilters = new HashSet<ImOperationsFilters>();
        }

        public string Operation { get; set; }
        public string Description { get; set; }
        public string TargetTable { get; set; }
        public string SourceTable { get; set; }
        public int? OperationType { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<ImOperationsDetails> ImOperationsDetails { get; set; }
        public virtual ICollection<ImOperationsFilters> ImOperationsFilters { get; set; }
    }
}
