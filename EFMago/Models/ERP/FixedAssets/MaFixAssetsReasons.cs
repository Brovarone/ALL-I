using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaFixAssetsReasons
    {
        public string Reason { get; set; }
        public string Description { get; set; }
        public string PostDocumentData { get; set; }
        public string UserEditableQty { get; set; }
        public string UserEditablePerc { get; set; }
        public int? CustSuppType { get; set; }
        public string PurchaseDisposalEnabled { get; set; }
        public string FiscalEnabled { get; set; }
        public string BalanceEnabled { get; set; }
        public string FinancialEnabled { get; set; }
        public string Actions { get; set; }
        public string ExtendedActions { get; set; }
        public int? DisposalType { get; set; }
        public string Predefined { get; set; }
        public string Disabled { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
