using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFees
    {
        public MaFees()
        {
            MaFeesDetails = new HashSet<MaFeesDetails>();
        }

        public DateTime? DocumentDate { get; set; }
        public DateTime? AccrualDate { get; set; }
        public string LogNo { get; set; }
        public string DocNo { get; set; }
        public int? CustSuppType { get; set; }
        public string CustSupp { get; set; }
        public string Template { get; set; }
        public string Duty { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? WithholdingTaxDate { get; set; }
        public string WithholdingTaxPaid { get; set; }
        public string Inpspaid { get; set; }
        public double? TaxPerc { get; set; }
        public double? Tax { get; set; }
        public double? WithholdingTaxPerc { get; set; }
        public double? WithholdingTaxBasePerc { get; set; }
        public double? WithholdingTax { get; set; }
        public short? InpscalculationType { get; set; }
        public double? Inpsemployees { get; set; }
        public double? Inps { get; set; }
        public string OneFirmOnly { get; set; }
        public double? Enasarcoperc { get; set; }
        public double? EnasarcopercSalesPerson { get; set; }
        public double? EnasarcotaxableAmount { get; set; }
        public double? Enasarco { get; set; }
        public double? Enasarcosalesperson { get; set; }
        public double? Enasarcoass { get; set; }
        public double? EnasarcoassPerc { get; set; }
        public string Payment { get; set; }
        public double? PayableAmount { get; set; }
        public string FeePaid { get; set; }
        public double? Paid { get; set; }
        public string WithholdingTaxTransfer { get; set; }
        public string Inpstransfer { get; set; }
        public string Enasarcotransfer { get; set; }
        public string Currency { get; set; }
        public double? Fixing { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public string Form770Frame { get; set; }
        public string Form770Letter { get; set; }
        public string StandardLetter { get; set; }
        public string WithholdingTaxSuspended { get; set; }
        public DateTime? WithholdingTaxPymtDate { get; set; }
        public DateTime? InpspymtDate { get; set; }
        public DateTime? EnasarcopymtDate { get; set; }
        public int? ProgrNumber { get; set; }
        public string Series { get; set; }
        public int? PymtNumber { get; set; }
        public string WithholdingTaxPymMethod { get; set; }
        public string InpspymtMethod { get; set; }
        public string EnasarcopymtMethod { get; set; }
        public string Description { get; set; }
        public string ProForma { get; set; }
        public int? TransferJournalEntryId { get; set; }
        public int? JournalEntryId { get; set; }
        public int? ClosingJournalEntryId { get; set; }
        public int? PymtSchedId { get; set; }
        public int FeeId { get; set; }
        public short? PymtMethod { get; set; }
        public int? DutyType { get; set; }
        public string DirectorRemuneration { get; set; }
        public Guid? Tbguid { get; set; }
        public double? EnasarcoassPercSp { get; set; }
        public double? EnasarcoassSp { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public short? WithholdingTaxAccrualYear { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ICollection<MaFeesDetails> MaFeesDetails { get; set; }
    }
}
