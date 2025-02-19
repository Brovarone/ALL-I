using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCurrencies
    {
        public MaCurrencies()
        {
            MaCurrenciesFixing = new HashSet<MaCurrenciesFixing>();
        }

        public string Currency { get; set; }
        public string Description { get; set; }
        public string InternationalCode { get; set; }
        public string Symbol { get; set; }
        public short? AmountRoundingDigit { get; set; }
        public int? AmountRoundingType { get; set; }
        public string Notes { get; set; }
        public string Disabled { get; set; }
        public short? TaxAmountRoundingDigit { get; set; }
        public int? TaxAmountRoundingType { get; set; }
        public short? NoOfDecimals { get; set; }
        public string IsEucurrency { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaCurrenciesFixing> MaCurrenciesFixing { get; set; }
    }
}
