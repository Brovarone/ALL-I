using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBomparameters
    {
        public string RmclearingInvRsn { get; set; }
        public string FpissueToProdInvRsn { get; set; }
        public string RmclearingProdInvRsn { get; set; }
        public string WasteInvRsn { get; set; }
        public string RmreceiptInvRsn { get; set; }
        public short? MaxNoOfLines { get; set; }
        public string ProductionRunFileName { get; set; }
        public string ProductionEndFileName { get; set; }
        public int BomparametersId { get; set; }
        public int? RtgStepNumberingType { get; set; }
        public short? BomlevelsNo { get; set; }
        public int? UnloadValueType { get; set; }
        public string UseDefaultUnloadValue { get; set; }
        public int? LineTypeInDn { get; set; }
        public string PreferredAlternate { get; set; }
        public int? SfpickingValueType { get; set; }
        public string UseDefaultSfpickingValue { get; set; }
        public int? SlreceiptValueType { get; set; }
        public string UseDefaultSlreceiptValue { get; set; }
        public string ComponentReservation { get; set; }
        public string ComponentClearing { get; set; }
        public string ValidityDateMandatory { get; set; }
        public string WasteDifferentItemInvRsn { get; set; }
        public string BomcostsConstraint { get; set; }
        public short? OperationLength { get; set; }
        public string LotIsMandatory { get; set; }
        public string EnableLotOverload { get; set; }
        public string ExpandFirstLevelOnly { get; set; }
        public string GenerateShortInvEntriesSet { get; set; }
        public string CreateBomFromItems { get; set; }
        public string UseBomCostSimulations { get; set; }
        public string Ecomandatory { get; set; }
        public string BominProduction { get; set; }
        public string UseDocumentsParameters { get; set; }
        public string SubtractWasteCost { get; set; }
        public string SingleLevelKanban { get; set; }
        public string WmsbillOfMaterialsLink { get; set; }
        public string RevWasteInvRsn { get; set; }
        public string RevWasteDifferentItemInvRsn { get; set; }
        public string MandatoryRevisionEco { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
