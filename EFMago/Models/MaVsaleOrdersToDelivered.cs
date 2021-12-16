using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaVsaleOrdersToDelivered
    {
        public string StubBook { get; set; }
        public string StoragePhase1 { get; set; }
        public int? Specificator1Type { get; set; }
        public string SpecificatorPhase1 { get; set; }
        public string Salesperson { get; set; }
        public short? Priority { get; set; }
        public string AllocationArea { get; set; }
        public string Area { get; set; }
        public string InternalOrdNo { get; set; }
        public string Carrier1 { get; set; }
        public string IsBlocked { get; set; }
        public string ShipToAddress { get; set; }
        public string Port { get; set; }
        public string Package { get; set; }
        public string Transport { get; set; }
        public string SingleDelivery { get; set; }
        public DateTime? AvailabilityDate { get; set; }
        public string Blocked { get; set; }
        public string Category { get; set; }
        public int SaleOrdId { get; set; }
        public short Line { get; set; }
        public int? SubId { get; set; }
        public short Position { get; set; }
        public string Item { get; set; }
        public string UoM { get; set; }
        public double? Qty { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ConfirmedDeliveryDate { get; set; }
        public string Cancelled { get; set; }
        public string Customer { get; set; }
        public string Allocated { get; set; }
        public double? AllocatedQty { get; set; }
        public string PreShipped { get; set; }
        public double? PreShippedQty { get; set; }
        public double? PickedAndDeliveredQty { get; set; }
        public string Delivered { get; set; }
        public double? DeliveredQty { get; set; }
        public int? LineType { get; set; }
        public string Bomitem { get; set; }
        public string CrossDocking { get; set; }
        public string ConsignmentStock { get; set; }
    }
}
