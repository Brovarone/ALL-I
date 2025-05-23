﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaProductLinesBalances
    {
        public string ProductLine { get; set; }
        public string Account { get; set; }
        public short FiscalYear { get; set; }
        public short BalanceYear { get; set; }
        public int Balance { get; set; }
        public short BalanceMonth { get; set; }
        public double? BudgetDebitQty { get; set; }
        public double? ActualDebitQty { get; set; }
        public double? BudgetCreditQty { get; set; }
        public double? ActualCreditQty { get; set; }
        public double? BudgetDebit { get; set; }
        public double? ActualDebit { get; set; }
        public double? BudgetCredit { get; set; }
        public double? ActualCredit { get; set; }
        public double? ForecastDebitQty { get; set; }
        public double? ForecastCreditQty { get; set; }
        public double? ForecastDebit { get; set; }
        public double? ForecastCredit { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual MaProductLines ProductLineNavigation { get; set; }
    }
}
