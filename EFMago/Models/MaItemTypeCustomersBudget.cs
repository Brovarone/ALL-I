using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaItemTypeCustomersBudget
    {
        public string ItemType { get; set; }
        public string Customer { get; set; }
        public short BudgetYear { get; set; }
        public short BudgetMonth { get; set; }
        public double? SaleQty { get; set; }
        public double? SaleValue { get; set; }
        public short FiscalYear { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaItemTypeCustomers MaItemTypeCustomers { get; set; }
    }
}
