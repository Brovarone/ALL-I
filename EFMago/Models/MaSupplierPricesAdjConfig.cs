using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaSupplierPricesAdjConfig
    {
        public int SupplierPricesAdjConfigId { get; set; }
        public string ActivateInPurchaseOrder { get; set; }
        public string ActivateInBillOfLading { get; set; }
        public string ActivateInPurchaseInvoice { get; set; }
        public string NewPriceListEdition { get; set; }
        public string UseFirstValid { get; set; }
        public string UseFirst { get; set; }
        public Guid? Tbguid { get; set; }
        public string ActivateInSubcontractorOrd { get; set; }
        public string ActivateInSubcontractorBoL { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
