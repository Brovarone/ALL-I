using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCustContracts
    {
        public MaCustContracts()
        {
            MaCustContractsDetails = new HashSet<MaCustContractsDetails>();
            MaCustContractsLines = new HashSet<MaCustContractsLines>();
            MaCustContractsRef = new HashSet<MaCustContractsRef>();
        }

        public string ContractNo { get; set; }
        public string Description { get; set; }
        public string Customer { get; set; }
        public string Payment { get; set; }
        public string PaymentIsAuto { get; set; }
        public DateTime? StartValidityDate { get; set; }
        public string Validity { get; set; }
        public string Notes { get; set; }
        public string ModificationsHistory { get; set; }
        public string Disabled { get; set; }
        public int? ContractType { get; set; }
        public DateTime? EndValidityDate { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaCustContractsDetails> MaCustContractsDetails { get; set; }
        public virtual ICollection<MaCustContractsLines> MaCustContractsLines { get; set; }
        public virtual ICollection<MaCustContractsRef> MaCustContractsRef { get; set; }
    }
}
