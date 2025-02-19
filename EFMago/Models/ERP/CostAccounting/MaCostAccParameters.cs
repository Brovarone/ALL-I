using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCostAccParameters
    {
        public int CostAccParametersId { get; set; }
        public string EntryAutonumbering { get; set; }
        public string RevenuesFromInventoryEntry { get; set; }
        public string CostsFromInventoryEntry { get; set; }
        public string SkipJobsOnPurchases { get; set; }
        public string CostCentersJobsMandatory { get; set; }
        public short? AccountsGroupLength { get; set; }
        public string CostCentersDescription1 { get; set; }
        public string CostCentersDescription2 { get; set; }
        public short? CostCentersGroupLength { get; set; }
        public string JobsGroupDescription1 { get; set; }
        public string JobsGroupDescpition2 { get; set; }
        public short? JobsGroupLength { get; set; }
        public string NotesFromAccountingEntry { get; set; }
        public string GroupAutoGenLines { get; set; }
        public string SalesCheckSpreading { get; set; }
        public string PurchCheckSpreading { get; set; }
        public string GenEntryFromIssuedDoc { get; set; }
        public string GenEntryFromReceivedDoc { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
