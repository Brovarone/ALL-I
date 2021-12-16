using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaMosteps
    {
        public MaMosteps()
        {
            MaMostepsDetailedQty = new HashSet<MaMostepsDetailedQty>();
        }

        public int Moid { get; set; }
        public short RtgStep { get; set; }
        public string Alternate { get; set; }
        public short AltRtgStep { get; set; }
        public string Simulation { get; set; }
        public string Mono { get; set; }
        public string Wc { get; set; }
        public string Operation { get; set; }
        public int? ProcessingTime { get; set; }
        public int? SetupTime { get; set; }
        public int? QueueTime { get; set; }
        public string PartialReceiptToEnd { get; set; }
        public string DataFromOperation { get; set; }
        public int? JobTicketId { get; set; }
        public short? JobTicketLineNumber { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public string ActualWc { get; set; }
        public int? ActualProcessingTime { get; set; }
        public int? ActualSetupTime { get; set; }
        public DateTime? StepRunDate { get; set; }
        public DateTime? StepDeliveryDate { get; set; }
        public int? Mostatus { get; set; }
        public string EstimatedWc { get; set; }
        public DateTime? SimStartDate { get; set; }
        public DateTime? SimEndDate { get; set; }
        public int? EstimatedProcessingTime { get; set; }
        public int? EstimatedSetupTime { get; set; }
        public int? EstimatedQueueTime { get; set; }
        public double? StartingTime { get; set; }
        public double? EndingTime { get; set; }
        public double? ProcessingBudgetCost { get; set; }
        public double? LabourBudgetCost { get; set; }
        public double? SetupBudgetCost { get; set; }
        public double? SetupActualCost { get; set; }
        public double? ProcessingActualCost { get; set; }
        public double? LabourActualCost { get; set; }
        public string Bom { get; set; }
        public string Variant { get; set; }
        public string UoM { get; set; }
        public double? ProductionQty { get; set; }
        public double? ProducedQty { get; set; }
        public double? PreviousStepQuantity { get; set; }
        public double? IssuedToProductionQuantity { get; set; }
        public double? NotProcessedQuantity { get; set; }
        public double? ReturnedMaterialQuantity { get; set; }
        public string SecondRate { get; set; }
        public string SecondRateVariant { get; set; }
        public string SecondRateUoM { get; set; }
        public double? SecondRateQuantity { get; set; }
        public double? ScrapQuantity { get; set; }
        public string Storage { get; set; }
        public string PostedToInventory { get; set; }
        public string Notes { get; set; }
        public double? SubcontractorOrderQuantity { get; set; }
        public double? Dnquantity { get; set; }
        public string NoDngeneration { get; set; }
        public double? HourlyCost { get; set; }
        public double? HourlySetUpCost { get; set; }
        public double? UnitCost { get; set; }
        public double? AdditionalCost { get; set; }
        public string ProcessEstimatedTeam { get; set; }
        public string SetupEstimatedTeam { get; set; }
        public string ProcessingActualTeam { get; set; }
        public string SetupActualTeam { get; set; }
        public short? ProcessEstimatedTeamMember { get; set; }
        public short? SetupEstimatedTeamMember { get; set; }
        public short? ProcessActualTeamElem { get; set; }
        public short? SetupActualTeamElem { get; set; }
        public double? ProcessEstimatedStaffingPerc { get; set; }
        public double? SetupEstimatedStaffingPerc { get; set; }
        public int? ProcessEstimatedLabourTime { get; set; }
        public int? SetupEstimatedLabourTime { get; set; }
        public int? ProcessingActualLabourTime { get; set; }
        public int? SetupActualLabourTime { get; set; }
        public string JobTicketNo { get; set; }
        public string ProductionRunNo { get; set; }
        public string PrintedJobTicket { get; set; }
        public DateTime? JtprintDate { get; set; }
        public string Outsourced { get; set; }
        public string Supplier { get; set; }
        public double? ProcessingQuantity { get; set; }
        public int? LineTypeInDn { get; set; }
        public string Scrap { get; set; }
        public string ScrapVariant { get; set; }
        public string ScrapUoM { get; set; }
        public string ScrapStorage { get; set; }
        public string SecondRateStorage { get; set; }
        public double? StepQuantity { get; set; }
        public string TotalTime { get; set; }
        public string Location { get; set; }
        public string ScrapLocation { get; set; }
        public string SecondRateLocation { get; set; }
        public string IsWc { get; set; }
        public short? ShiftNumber { get; set; }
        public short? LotsCounter { get; set; }
        public string AdditionalRtgStep { get; set; }
        public int? SubId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaMo Mo { get; set; }
        public virtual ICollection<MaMostepsDetailedQty> MaMostepsDetailedQty { get; set; }
    }
}
