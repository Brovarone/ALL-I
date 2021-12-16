using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSalesPeopleParameters
    {
        public int SalesPeopleParametersId { get; set; }
        public int? AreaManagerManagement { get; set; }
        public string BracketSkipCurrentDoc { get; set; }
        public string SalespersTurnNetDiscount { get; set; }
        public string AcceptNegativeComm { get; set; }
        public string CommPercIsManual { get; set; }
        public string CommAmountIsManual { get; set; }
        public string DiscountsDetail { get; set; }
        public string WarnIfNoSalesperson { get; set; }
        public double? Enasarcoperc { get; set; }
        public double? EnasarcopercSalesPerson { get; set; }
        public double? EnasarcopercCompany { get; set; }
        public double? EnasarcooneFirmMin { get; set; }
        public double? EnasarcomultiFirmMin { get; set; }
        public double? EnasarcooneFirmMax { get; set; }
        public double? EnasarcomultiFirmMax { get; set; }
        public double? AllowancePerc { get; set; }
        public string EnasarcouponSalespersons { get; set; }
        public string WarnIfZeroComm { get; set; }
        public string EnasarcouponAcquiredComm { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
