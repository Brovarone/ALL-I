using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrnfeParameters
    {
        public int BrnfeParameterId { get; set; }
        public int? LastSubId { get; set; }
        public string CertificateName { get; set; }
        public short? Environment { get; set; }
        public string FileHomologation { get; set; }
        public string FileProduction { get; set; }
        public string DirXmlconsignee { get; set; }
        public string DirLog { get; set; }
        public string DirXmlschema { get; set; }
        public string DirReportTemplate { get; set; }
        public string ProxyUser { get; set; }
        public string ProxyPassword { get; set; }
        public string ProxyName { get; set; }
        public int? ProxyTimeOut { get; set; }
        public int? MaxSizeLotSend { get; set; }
        public int? NoAttempts { get; set; }
        public string IgnoreInvalidCertificate { get; set; }
        public string AppendDanfePdf { get; set; }
        public string ValidateSchemaBeforeShipping { get; set; }
        public string Version { get; set; }
        public string DanfePhraseContingency { get; set; }
        public string DanfePhraseHomologation { get; set; }
        public int? DanfeCopy { get; set; }
        public string DanfeLineDelimiter { get; set; }
        public string DanfeModelNormal { get; set; }
        public string DanfeModelLandscape { get; set; }
        public string DanfeLogo { get; set; }
        public string DanfePdf { get; set; }
        public string EmailServer { get; set; }
        public int? EmailPort { get; set; }
        public string EmailAutentication { get; set; }
        public string EmailUser { get; set; }
        public string EmailPassword { get; set; }
        public int? EmailTimeOut { get; set; }
        public string HomologationCustomerName { get; set; }
        public string DirXmltoBeElabForSupp { get; set; }
        public string DirXmlelabForSupp { get; set; }
        public string DirXmlelabErrForSupp { get; set; }
        public string DirXmltoBeElabForCust { get; set; }
        public string DirXmlelabForCust { get; set; }
        public string DirXmlelabErrForCust { get; set; }
        public string DirElabInutiliz { get; set; }
        public string DefaultTaxRuleCode { get; set; }
        public string DirXmlcontingencyFsda { get; set; }
        public string EditXmltoBeElabPath { get; set; }
        public string CheckAlwaysServiceStatus { get; set; }
        public string Timezone { get; set; }
        public string NotaFiscalCodeDefCust { get; set; }
        public string NotaFiscalCodeDefSupp { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
