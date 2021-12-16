using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCustContractsRef
    {
        public string ContractNo { get; set; }
        public short Line { get; set; }
        public int? SaleOrdId { get; set; }
        public string SaleOrdNo { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCustContracts ContractNoNavigation { get; set; }
    }
}
