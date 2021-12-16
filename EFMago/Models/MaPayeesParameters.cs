using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaPayeesParameters
    {
        public int PayeesParametersId { get; set; }
        public string WithholdingTaxDebit { get; set; }
        public string Inpsdebit { get; set; }
        public string InpsdebitProfessional { get; set; }
        public string Enasarcoaccount { get; set; }
        public double? WithholdingTaxPerc { get; set; }
        public double? WithholdingTaxBasePerc { get; set; }
        public double? WithholdTaxExemptThreshold { get; set; }
        public short? Inpsnumerator { get; set; }
        public short? Inpsdenominator { get; set; }
        public double? InpsatypicalPerc { get; set; }
        public short? InpsnumeratorProfessional { get; set; }
        public short? InpsdenominatorProfessional { get; set; }
        public string PaymentAccTpl { get; set; }
        public string TransferAccTpl { get; set; }
        public string PaymentAccRsn { get; set; }
        public string TransferAccRsn { get; set; }
        public string ContributionsDebitTransfer { get; set; }
        public string Inpscost { get; set; }
        public string Enasarcocost { get; set; }
        public string PymtScheduleNetContribution { get; set; }
        public string Inpsoffice { get; set; }
        public short? WithholdingTaxPymtMonths { get; set; }
        public short? WithholdingTaxPymtDay { get; set; }
        public string ContributionTransferSplitted { get; set; }
        public string TransfBySuppFeeContrib { get; set; }
        public string TransfBySuppContrib { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
