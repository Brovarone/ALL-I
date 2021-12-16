using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImJobQuotasSummByCompTypeByWorkingStep
    {
        public int JobQuotationId { get; set; }
        public string WorkingStep { get; set; }
        public double? CostTotalAmountGoods { get; set; }
        public double? CostTotalAmountLabor { get; set; }
        public double? CostTotalAmountServices { get; set; }
        public double? CostTotalAmountCharges { get; set; }
        public double? CostTotalAmountOther { get; set; }
        public double? CostTotalAmountSubcontract { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImJobQuotations JobQuotation { get; set; }
    }
}
