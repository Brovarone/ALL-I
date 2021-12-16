using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaIbcconfigurations
    {
        public string Configuration { get; set; }
        public int? DateType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Days { get; set; }
        public string Masters { get; set; }
        public string Orders { get; set; }
        public string DeliveryNotes { get; set; }
        public string Invoices { get; set; }
        public string CompanyName { get; set; }
        public string Accounting { get; set; }
        public string CostAccounting { get; set; }
        public string Inventory { get; set; }
        public string Quotations { get; set; }
        public string PaymentSchedule { get; set; }
        public string InventoryAnalysis { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
