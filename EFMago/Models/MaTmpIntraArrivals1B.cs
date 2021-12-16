using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpIntraArrivals1B
    {
        public Guid SessionGuid { get; set; }
        public int Line { get; set; }
        public int? Progressive { get; set; }
        public short? BalanceMonth { get; set; }
        public string Quarter { get; set; }
        public short? BalanceYear { get; set; }
        public string Isocode { get; set; }
        public string TaxId { get; set; }
        public string DebitCreditSign { get; set; }
        public double? Amount { get; set; }
        public double? AmountDocCurr { get; set; }
        public string NatureOfTransaction { get; set; }
        public string CombinedNomenclature { get; set; }
        public double? StatisticalValue { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
