using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTmpOnHandDetailItems
    {
        public Guid SessionGuid { get; set; }
        public int LineType { get; set; }
        public string Item { get; set; }
        public int DocumentId { get; set; }
        public short Line { get; set; }
        public string DocNo { get; set; }
        public string BaseUoM { get; set; }
        public string UoMdoc { get; set; }
        public double? MinStock { get; set; }
        public double? FiscalDataOnHand { get; set; }
        public double? UnfulfilledCust { get; set; }
        public double? UnfulfilledSupp { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public double? ActualOnHand { get; set; }
        public double? IssuedQty { get; set; }
        public double? ReceiptedQty { get; set; }
        public double? ToOrder { get; set; }
        public double? Price { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public double? OnHandToToday { get; set; }
        public double? OnHandToDueDate1 { get; set; }
        public double? OnHandToDueDate2 { get; set; }
        public double? OnHandToDueDate3 { get; set; }
        public double? OnHandToDueDate4 { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
