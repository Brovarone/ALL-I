using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrnotaFiscalForCustRef
    {
        [ForeignKey(nameof(SaleDocId))]
        public int SaleDocId { get; set; }
        public short Line { get; set; }
        public int? Type { get; set; }
        public string RefKey { get; set; }
        public string Series { get; set; }
        public string NumberNf { get; set; }
        public string ModelNf { get; set; }
        public string Uf { get; set; }
        public DateTime? DocDate { get; set; }
        public string NaturalPerson { get; set; }
        public string TaxIdNumber { get; set; }
        public string FiscalCode { get; set; }
        public string FedStateReg { get; set; }
        public string NumberEcf { get; set; }
        public string NumberCoo { get; set; }
        public string Model { get; set; }
        public short? MovementType { get; set; }
        public string ThirdParties { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaSaleDoc SaleDoc { get; set; }
    }
}
