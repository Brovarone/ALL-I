using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaJournalEntriesForecast
    {
        public string AccTpl { get; set; }
        public int? TransactionType { get; set; }
        public DateTime? PostingDate { get; set; }
        public string FinalPosting { get; set; }
        public DateTime? FinalExpectedDate { get; set; }
        public string Automatic { get; set; }
        public string FinalPosted { get; set; }
        public DateTime? FinalPostingDate { get; set; }
        public string Notes { get; set; }
        public string Simulation { get; set; }
        public DateTime? SimulationDate { get; set; }
        public int JournalEntryId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
