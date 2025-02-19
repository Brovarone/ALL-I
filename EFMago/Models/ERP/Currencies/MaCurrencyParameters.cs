using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCurrencyParameters
    {
        public int CurrencyParametersId { get; set; }
        public string Currency { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public short? NoOfDecimals { get; set; }
        public short? AmountRoundingDigit { get; set; }
        public int? AmountRoundingType { get; set; }
        public short? TaxAmountRoundingDigit { get; set; }
        public int? TaxAmountRoundingType { get; set; }
        public string EuroCurrency { get; set; }
        public string DomesticCurrency { get; set; }
        public string EuroCrossChange { get; set; }
        public DateTime? EuroConversionDate { get; set; }
        public string UseFixDecInCrossChange { get; set; }
        public short? CrossChangeFixDecimals { get; set; }
        public string UseCurrencyAccounts { get; set; }
        public string TimestampInFixingDate { get; set; }
        public string FixingEqualToDate { get; set; }
        public string FixingComboEqual { get; set; }
        public string FixingComboLess { get; set; }
        public int? FixingComboMaxItems { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
