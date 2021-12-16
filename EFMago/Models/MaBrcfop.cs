using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrcfop
    {
        public string Cfop { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public DateTime ValidityStartingDate { get; set; }
        public DateTime? ValidityEndingDate { get; set; }
        public short? MovementType { get; set; }
        public short? TransactionType { get; set; }
        public string Cfopgroup { get; set; }
        public string OperationDescription { get; set; }
        public string ExcludeFromTot { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
