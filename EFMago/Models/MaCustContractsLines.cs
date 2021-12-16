using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCustContractsLines
    {
        public string ContractNo { get; set; }
        public short Line { get; set; }
        public int? LineType { get; set; }
        public string Category { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string UoM { get; set; }
        public double? Quantity { get; set; }
        public double? UnitValue { get; set; }
        public string UnitValueIsAuto { get; set; }
        public double? Price { get; set; }
        public string DiscountFormula { get; set; }
        public string DiscountIsAuto { get; set; }
        public double? MinimumQty { get; set; }
        public double? BudgetQty { get; set; }
        public double? BudgetValue { get; set; }
        public string Notes { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCustContracts ContractNoNavigation { get; set; }
    }
}
