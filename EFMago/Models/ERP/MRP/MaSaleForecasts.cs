using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSaleForecasts
    {
        public string Item { get; set; }
        public short Year { get; set; }
        public short Month { get; set; }
        public short Week { get; set; }
        public double? Quantity { get; set; }
        public double? SaleQuantity { get; set; }
        public string Job { get; set; }
        public string CostCenter { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
