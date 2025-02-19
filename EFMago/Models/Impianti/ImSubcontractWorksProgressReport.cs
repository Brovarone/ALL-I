using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImSubcontractWorksProgressReport
    {
        public ImSubcontractWorksProgressReport()
        {
            ImSubcontractWprdetails = new HashSet<ImSubcontractWprdetails>();
            ImSubcontractWprdocuments = new HashSet<ImSubcontractWprdocuments>();
            ImSubcontractWprnotes = new HashSet<ImSubcontractWprnotes>();
            ImSubcontractWprpreviousWpr = new HashSet<ImSubcontractWprpreviousWpr>();
            ImSubcontractWprreferences = new HashSet<ImSubcontractWprreferences>();
            ImSubcontractWprwithholdingTax = new HashSet<ImSubcontractWprwithholdingTax>();
        }

        public int SubcontractWprid { get; set; }
        public string SubcontractWprno { get; set; }
        public string ExternalWprno { get; set; }
        public DateTime? SubcontractWprdate { get; set; }
        public int? SubcontractOrdId { get; set; }
        public string Supplier { get; set; }
        public string Job { get; set; }
        public int? SubcontractWprstatus { get; set; }
        public string Currency { get; set; }
        public DateTime? FixingDate { get; set; }
        public string FixingIsManual { get; set; }
        public double? Fixing { get; set; }
        public string Payment { get; set; }
        public string Paid { get; set; }
        public string AccTpl { get; set; }
        public string AccGroup { get; set; }
        public string CostCenter { get; set; }
        public string ContractCode { get; set; }
        public string ProjectCode { get; set; }
        public string SupplierBank { get; set; }
        public string CompanyBank { get; set; }
        public string SupplierCa { get; set; }
        public string CompanyCa { get; set; }
        public string Language { get; set; }
        public string PaymentAddress { get; set; }
        public string TaxJournal { get; set; }
        public string TaxCode { get; set; }
        public string Description { get; set; }
        public string ExternalDescription { get; set; }
        public string OurReference { get; set; }
        public string YourReference { get; set; }
        public string Notes { get; set; }
        public int? CrrefType { get; set; }
        public int? CrrefId { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public Guid? Tbguid { get; set; }

        public virtual ImSubcontractWprsummary ImSubcontractWprsummary { get; set; }
        public virtual ICollection<ImSubcontractWprdetails> ImSubcontractWprdetails { get; set; }
        public virtual ICollection<ImSubcontractWprdocuments> ImSubcontractWprdocuments { get; set; }
        public virtual ICollection<ImSubcontractWprnotes> ImSubcontractWprnotes { get; set; }
        public virtual ICollection<ImSubcontractWprpreviousWpr> ImSubcontractWprpreviousWpr { get; set; }
        public virtual ICollection<ImSubcontractWprreferences> ImSubcontractWprreferences { get; set; }
        public virtual ICollection<ImSubcontractWprwithholdingTax> ImSubcontractWprwithholdingTax { get; set; }
    }
}
