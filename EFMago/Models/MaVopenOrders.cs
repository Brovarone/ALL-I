using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaVopenOrders
    {
        public int SaleOrdId { get; set; }
        public string Customer { get; set; }
        public string ContractNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OpenOrder { get; set; }
        public short Line { get; set; }
        public short Position { get; set; }
        public string Item { get; set; }
        public double? Qty { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public double? DeliveredQty { get; set; }
        public string ConfirmationLevel { get; set; }
        public string Cancelled { get; set; }
        public string UoM { get; set; }
        public string InternalOrdNo { get; set; }
        public string Notes { get; set; }
    }
}
