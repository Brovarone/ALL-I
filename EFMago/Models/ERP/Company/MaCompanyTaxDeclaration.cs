using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCompanyTaxDeclaration
    {
        public int CompanyId { get; set; }
        public short? SupplierType { get; set; }
        public string FiscalCode { get; set; }
        public string NaturalPerson { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CityOfBirth { get; set; }
        public string CountyOfBirth { get; set; }
        public string FiscalDomicileCity { get; set; }
        public string FiscalDomicileCounty { get; set; }
        public string FiscalDomicileAddress { get; set; }
        public string FiscalDomicileZip { get; set; }
        public string RegisteredOfficeCity { get; set; }
        public string RegisteredOfficeCounty { get; set; }
        public string RegisteredOfficeAddress { get; set; }
        public string RegisteredOfficeZip { get; set; }
        public string ExtactData { get; set; }
        public string CafregistrationNo { get; set; }
        public string CustSuppListsExe { get; set; }
        public string CustSuppListsFolder { get; set; }
        public string TaxIdNumber { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaCompany Company { get; set; }
    }
}
