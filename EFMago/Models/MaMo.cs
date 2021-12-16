using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaMo
    {
        public MaMo()
        {
            MaMocomponents = new HashSet<MaMocomponents>();
            MaMosteps = new HashSet<MaMosteps>();
        }

        public string Mono { get; set; }
        public string Simulation { get; set; }
        public string Job { get; set; }
        public string InternalOrdNo { get; set; }
        public int? SaleOrdId { get; set; }
        public short? Position { get; set; }
        public string Customer { get; set; }
        public int? Feasibility { get; set; }
        public int? ProductionPlanId { get; set; }
        public short? ProductionPlanLine { get; set; }
        public int? ProductKind { get; set; }
        public string FromExplosion { get; set; }
        public string Bom { get; set; }
        public string Variant { get; set; }
        public string UoM { get; set; }
        public double? ProductionQty { get; set; }
        public double? ProducedQty { get; set; }
        public string SecondRateUoM { get; set; }
        public double? SecondRateQuantity { get; set; }
        public double? ScrapQuantity { get; set; }
        public string ProductionLotNumber { get; set; }
        public int? Mostatus { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public DateTime? RunDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? SimStartDate { get; set; }
        public DateTime? SimEndDate { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public int? SimulatedProcessingTime { get; set; }
        public int? SimulatedSetupTime { get; set; }
        public int? ActualProcessingTime { get; set; }
        public int? ActualSetupTime { get; set; }
        public double? StartingTime { get; set; }
        public double? EndingTime { get; set; }
        public double? MaterialsBudgetCost { get; set; }
        public double? SetupBudgetCost { get; set; }
        public double? ProcessingBudgetCost { get; set; }
        public double? LabourBudgetCost { get; set; }
        public double? MaterialsActualCost { get; set; }
        public double? SetupActualCost { get; set; }
        public double? ProcessingActualCost { get; set; }
        public double? LabourActualCost { get; set; }
        public int? EstimatedProcessingTime { get; set; }
        public int? EstimatedSetupTime { get; set; }
        public short? EstimatedDuration { get; set; }
        public string Notes { get; set; }
        public int Moid { get; set; }
        public double? ProposedQuantity { get; set; }
        public string CostCenter { get; set; }
        public Guid? Tbguid { get; set; }
        public string ConfirmationLevel { get; set; }
        public DateTime? CostsCalculationLastDate { get; set; }
        public string Drawing { get; set; }
        public string MoreadOnly { get; set; }
        public short? MrpconfirmationRank { get; set; }
        public int? EstimatedTimeKanban { get; set; }
        public double? EstimatedProcCostKanban { get; set; }
        public double? EstimatedMaterialCostKanban { get; set; }
        public int? ActualTimeKanban { get; set; }
        public double? ActualProcCostKanban { get; set; }
        public double? ActualMaterialCostKanban { get; set; }
        public string Printed { get; set; }
        public DateTime? PrintDate { get; set; }
        public string GroupSf { get; set; }
        public string BarcodeSegment { get; set; }
        public int? LastSubId { get; set; }
        public DateTime? Ecodate { get; set; }
        public string Ecorevision { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaMocomponents> MaMocomponents { get; set; }
        public virtual ICollection<MaMosteps> MaMosteps { get; set; }
    }
}
