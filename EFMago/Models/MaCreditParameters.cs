﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCreditParameters
    {
        public short Id { get; set; }
        public short? DaysOfOutstanding { get; set; }
        public double? MarginOnCredit { get; set; }
        public double? MaxOrderValue { get; set; }
        public double? MaxOrderedValue { get; set; }
        public double? MaximumCredit { get; set; }
        public double? TotalExposure { get; set; }
        public int? MaxOrderValueCheckType { get; set; }
        public int? MaxOrderedValueCheckType { get; set; }
        public int? MaximumCreditCheckType { get; set; }
        public int? TotalExposureCheckType { get; set; }
        public int? MaximumCreditCheckTypeDelDoc { get; set; }
        public int? MaximumCreditCheckTypeDefInv { get; set; }
        public int? MaximumCreditCheckTypeImmInv { get; set; }
        public int? TotalExposureCheckTypeDelDoc { get; set; }
        public int? TotalExposureCheckTypeDefInv { get; set; }
        public int? TotalExposureCheckTypeImmInv { get; set; }
        public string TotalCreditLimitnetofOrdered { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
