using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaCashParameters
    {
        public int CashParametersId { get; set; }
        public string CashModuleIsDisabled { get; set; }
        public string CashInPrefix { get; set; }
        public string CashOutPrefix { get; set; }
        public string CashAccTpl { get; set; }
        public string OneJeforCashEntry { get; set; }
        public string OneCurrencyForCash { get; set; }
        public string ExpenseAutonumbering { get; set; }
        public string CashFromSale { get; set; }
        public string CashReason { get; set; }
        public string CashFromPurchase { get; set; }
        public string PurchaseCashReason { get; set; }
        public string WorkOnMoreSessions { get; set; }
        public string CashFromSaleTotal { get; set; }
        public string CashFromPurchaseTotal { get; set; }
        public string CashTotalRounded { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
