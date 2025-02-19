using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaEiItcompany
    {
        public int CompanyId { get; set; }
        public string SenderIsocountryCode { get; set; }
        public string SenderFiscalCodeId { get; set; }
        public string LastSentNo { get; set; }
        public string FiscalRegime { get; set; }
        public string PermanentBranchCode { get; set; }
        public int? IssuerSubject { get; set; }
        public string FdisocountryCode { get; set; }
        public string FdfiscalCodeId { get; set; }
        public string FdfiscalCode { get; set; }
        public string FdnaturalPerson { get; set; }
        public string FdcompanyName { get; set; }
        public string Fdname { get; set; }
        public string FdlastName { get; set; }
        public string FdtitleCode { get; set; }
        public string Fdeoricode { get; set; }
        public string TiisocountryCode { get; set; }
        public string TifiscalCodeId { get; set; }
        public string TifiscalCode { get; set; }
        public string TinaturalPerson { get; set; }
        public string TicompanyName { get; set; }
        public string Tiname { get; set; }
        public string TilastName { get; set; }
        public string TititleCode { get; set; }
        public string Tieoricode { get; set; }
        public string SenderTelephone { get; set; }
        public string Email { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
