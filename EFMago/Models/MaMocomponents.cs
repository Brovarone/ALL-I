using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaMocomponents
    {
        public MaMocomponents()
        {
            MaMocomponentsStepsQty = new HashSet<MaMocomponentsStepsQty>();
        }

        public int Moid { get; set; }
        public short Line { get; set; }
        public short? Position { get; set; }
        public short? ReferredPosition { get; set; }
        public string Component { get; set; }
        public string Simulation { get; set; }
        public string Variant { get; set; }
        public string Mono { get; set; }
        public string Job { get; set; }
        public string SaleOrdNo { get; set; }
        public int? SaleOrdId { get; set; }
        public short? SaleOrdPos { get; set; }
        public string Customer { get; set; }
        public string PickingListNo { get; set; }
        public string UoM { get; set; }
        public double? NeededQty { get; set; }
        public double? AssignedQuantity { get; set; }
        public double? PickedQuantity { get; set; }
        public double? WasteQuantity { get; set; }
        public string Storage { get; set; }
        public string Lot { get; set; }
        public string FixedComponent { get; set; }
        public DateTime? EstimatedUseDate { get; set; }
        public DateTime? PickingListDate { get; set; }
        public string Wc { get; set; }
        public string SplitPick { get; set; }
        public string Closed { get; set; }
        public string PostedToInventory { get; set; }
        public string OutsourcedWc { get; set; }
        public int? DeliveryNoteId { get; set; }
        public double? EnteredQuantity { get; set; }
        public string NotEnter { get; set; }
        public double? ActualCost { get; set; }
        public string NotConfirm { get; set; }
        public double? BudgetCost { get; set; }
        public string JobTicketNo { get; set; }
        public short? InitialPosition { get; set; }
        public short? DnrtgStep { get; set; }
        public int? SpecificatorType { get; set; }
        public string Specificator { get; set; }
        public string Notes { get; set; }
        public string ReplacedComponent { get; set; }
        public int? SubId { get; set; }
        public double? Dnquantity { get; set; }
        public string TechnicalData { get; set; }
        public DateTime? PickDate { get; set; }
        public string IsAoverPick { get; set; }
        public string IsAreplacement { get; set; }
        public string AutomaticallyConfirmation { get; set; }
        public string ReplacedVariant { get; set; }
        public string Waste { get; set; }
        public string WasteUoM { get; set; }
        public string Location { get; set; }
        public string Drawing { get; set; }
        public string FromKanban { get; set; }
        public string ParentBom { get; set; }
        public string ParentVar { get; set; }
        public string FixedQty { get; set; }
        public double? NotRoundedPickedQuantity { get; set; }
        public string IsTool { get; set; }
        public short? EndUseRtgStep { get; set; }
        public int? BoLid { get; set; }
        public short? BoLline { get; set; }
        public double? AdjustmentQty { get; set; }
        public string Valorize { get; set; }
        public int? Trid { get; set; }
        public string ReplacedLot { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaMo Mo { get; set; }
        public virtual ICollection<MaMocomponentsStepsQty> MaMocomponentsStepsQty { get; set; }
    }
}
