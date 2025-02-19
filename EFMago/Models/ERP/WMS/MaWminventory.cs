using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaWminventory
    {
        public MaWminventory()
        {
            MaWminventoryDetail = new HashSet<MaWminventoryDetail>();
        }

        public int InventoryId { get; set; }
        public string InventoryNumber { get; set; }
        public DateTime? InventoryDate { get; set; }
        public int? InventoryType { get; set; }
        public int? OperationType { get; set; }
        public DateTime? PostingDate { get; set; }
        public DateTime? BalancesDate { get; set; }
        public string AdjPositiveReason { get; set; }
        public string AdjNegativeReason { get; set; }
        public string InitialReason { get; set; }
        public string Storage { get; set; }
        public string Zone { get; set; }
        public int? ProposedValue { get; set; }
        public string DisplayItemsAvailable { get; set; }
        public string BlockExtractedBins { get; set; }
        public string InventoryDescription { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaWminventoryDetail> MaWminventoryDetail { get; set; }
    }
}
