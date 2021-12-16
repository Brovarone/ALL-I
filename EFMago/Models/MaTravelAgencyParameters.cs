using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaTravelAgencyParameters
    {
        public int TravelAgencyParametersId { get; set; }
        public string UseTravelAgencyVatregime { get; set; }
        public string ShiftAccrualDate { get; set; }
        public string TaxRegisterForSales { get; set; }
        public string TaxRegisterForPurchases { get; set; }
        public string TaxRegisterForRetailSales { get; set; }
        public string IncludeInTravelVatcalc { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
