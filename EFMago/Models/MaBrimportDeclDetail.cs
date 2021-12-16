using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrimportDeclDetail
    {
        public int Id { get; set; }
        public int SubId { get; set; }
        public int? AdditionNumber { get; set; }
        public int? SeqAdditionNumber { get; set; }
        public string Item { get; set; }
        public string Ncm { get; set; }
        public double? Qty { get; set; }
        public string UoM { get; set; }
        public double? CustomsValue { get; set; }
        public double? UnitValue { get; set; }
        public string Drawback { get; set; }
        public double? IiTaxable { get; set; }
        public double? IiValue { get; set; }
        public double? IiPerc { get; set; }
        public double? IpiTaxable { get; set; }
        public double? IpiValue { get; set; }
        public double? IpiPerc { get; set; }
        public double? SiscomexValue { get; set; }
        public double? IofValue { get; set; }
        public double? PisTaxable { get; set; }
        public double? PisValue { get; set; }
        public double? PisPerc { get; set; }
        public double? CofinsTaxable { get; set; }
        public double? CofinsValue { get; set; }
        public double? CofinsPerc { get; set; }
        public double? IcmsTaxable { get; set; }
        public double? IcmsValue { get; set; }
        public double? IcmsPerc { get; set; }
        public double? IcmsReductionPerc { get; set; }
        public double? Afrmm { get; set; }
        public double? ImportCharges { get; set; }
        public string InNotaFiscal { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public int? CrrefSubId { get; set; }
        public double? AdditionalCharges { get; set; }
        public double? TotalAmount { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
