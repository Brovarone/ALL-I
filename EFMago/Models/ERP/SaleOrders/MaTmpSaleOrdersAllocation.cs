using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpSaleOrdersAllocation
    {
        public string UserName { get; set; }
        public string Computer { get; set; }
        public int LineSorted { get; set; }
        public int? SaleOrdId { get; set; }
        public short? Line { get; set; }
        public int? SubId { get; set; }
        public short? Position { get; set; }
        public short? Priority { get; set; }
        public string Item { get; set; }
        public string Customer { get; set; }
        public DateTime? OrderDate { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public string BaseUoM { get; set; }
        public double? BaseUoMqty { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ConfirmedDeliveryDate { get; set; }
        public double? AllocableQty { get; set; }
        public double? AllocatedQty { get; set; }
        public double? PreShippedQty { get; set; }
        public double? DeliveredQty { get; set; }
        public double? AllocatedBaseUoMqty { get; set; }
        public double? AvailableQty { get; set; }
        public double? ProgressiveAvailableQty { get; set; }
        public double? AreaQty { get; set; }
        public string AllocationArea { get; set; }
        public string Area { get; set; }
        public string InternalOrdNo { get; set; }
        public string IsSelected { get; set; }
        public string IsInGrid { get; set; }
        public string Allocated { get; set; }
        public string Carrier { get; set; }
        public string Storage { get; set; }
        public string Specificator { get; set; }
        public int? SpecificatorType { get; set; }
        public string Salesperson { get; set; }
        public string StubBook { get; set; }
        public string CustomerCategory { get; set; }
        public string CustomerBlocked { get; set; }
        public DateTime? AvailabilityDate { get; set; }
        public string SingleDelivery { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
