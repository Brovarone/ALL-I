using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrimportNfeRef
    {
        public int DocumentId { get; set; }
        public short Line { get; set; }
        public int? TypeCons { get; set; }
        public string RefKeySend { get; set; }
        public string SeriesSend { get; set; }
        public string NumberNfSend { get; set; }
        public string ModelNfSend { get; set; }
        public string UfSend { get; set; }
        public int? MonthSend { get; set; }
        public int? YearSend { get; set; }
        public string TaxIdNumberSend { get; set; }
        public string FedStateRegSend { get; set; }
        public string NumberEcfSend { get; set; }
        public string NumberCooSend { get; set; }
        public string ModelSend { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaBrimportNfe Document { get; set; }
    }
}
