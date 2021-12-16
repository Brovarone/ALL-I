using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInventoryParameters
    {
        public int InventoryParametersId { get; set; }
        public string EntryAutonumbering { get; set; }
        public string CustomDescription1 { get; set; }
        public string CustomDescription2 { get; set; }
        public string CustomDescription3 { get; set; }
        public string CustomDescription4 { get; set; }
        public string CustomDescription5 { get; set; }
        public int? Abccost { get; set; }
        public double? Abclimit { get; set; }
        public string PromptMinQty { get; set; }
        public string AccrualDateManagement { get; set; }
        public string WarningMaximumStock { get; set; }
        public string PunctualLastCostUpdate { get; set; }
        public string ShowCostInReports { get; set; }
        public string AskForCostInReports { get; set; }
        public string StorageValuationManage { get; set; }
        public string LinkStorageLocation { get; set; }
        public int? ActionOnLocation { get; set; }
        public string UseSepAccountForStorage { get; set; }
        public string ShowGoodsOwnedStorageOnly { get; set; }
        public string PickFromMultipleLocDe { get; set; }
        public int? InventoryShortageCheckType { get; set; }
        public int? InvEntryDateCheckType { get; set; }
        public string SearchFormerAverageCost { get; set; }
        public string StandardCostHistory { get; set; }
        public int? InventoryScarcityCheckType { get; set; }
        public string EnableInvValConsolidation { get; set; }
        public DateTime? LastInvValConsDate { get; set; }
        public int? ActionReopeningInvValCons { get; set; }
        public string UseInvAdjByLocation { get; set; }
        public string RoundOffNetPrice { get; set; }
        public int? ValueTypePurchase { get; set; }
        public int? ValueTypePurchaseNotPost { get; set; }
        public int? ValueTypeSemiFinished { get; set; }
        public int? ValueTypeFinished { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
