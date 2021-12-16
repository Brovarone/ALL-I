using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaMrpsimulations
    {
        public string Simulation { get; set; }
        public string Description { get; set; }
        public DateTime? RunDate { get; set; }
        public string FromProdPlan { get; set; }
        public string FromSaleOrd { get; set; }
        public string FromMoexisting { get; set; }
        public string FromReorderPoint { get; set; }
        public DateTime? ReorderPointDate { get; set; }
        public int? FinishedLeadTimeOrigin { get; set; }
        public int? PurchaseLeadTimeOrigin { get; set; }
        public short? Horizon { get; set; }
        public int? HrzType { get; set; }
        public DateTime? HrzEndDate { get; set; }
        public string Signature { get; set; }
        public string Notes { get; set; }
        public int? ProdPlanId { get; set; }
        public string IncludeSaleOrdExpired { get; set; }
        public string AllMo { get; set; }
        public string FromMo { get; set; }
        public string ToMo { get; set; }
        public string Mocreated { get; set; }
        public string Moreleased { get; set; }
        public string MoinProgress { get; set; }
        public string SaleOrdersOnly { get; set; }
        public string OpenOrdersOnly { get; set; }
        public string SaleForecastsOnly { get; set; }
        public int? SaleOrdSaleForeRelation { get; set; }
        public int? DayOfRequirement { get; set; }
        public int? WeekDayOfRequirement { get; set; }
        public string NetFirstLevelOnJobPolicy { get; set; }
        public string NetOtherLevelsOnJobPolicy { get; set; }
        public string NetFirstLevelOnLotPolicy { get; set; }
        public string NetOtherLevelsOnLotPolicy { get; set; }
        public string NetFirstLevelOnDayReqPolicy { get; set; }
        public string NetOtherLevelsOnDayReqPolicy { get; set; }
        public string NetByItemMaster { get; set; }
        public string NetByMo { get; set; }
        public string NetByMoEmptyJob { get; set; }
        public string NetByPurchOrd { get; set; }
        public string UseSimulatedEndDate { get; set; }
        public string UseAheadDepositMo { get; set; }
        public int? AheadDepositDaysMo { get; set; }
        public string UseAheadDepositPo { get; set; }
        public int? AheadDepositDaysPo { get; set; }
        public string UseDeliveryExpectedDatePo { get; set; }
        public string UseDeliveryConfirmedDatePo { get; set; }
        public string CreateMoonly { get; set; }
        public string CreatePronly { get; set; }
        public string GroupLotsByDate { get; set; }
        public string UseMinStock { get; set; }
        public string SkipNotWorkingDays { get; set; }
        public string ExplodeAllBomlevels { get; set; }
        public int? MaxLevelBomexplosion { get; set; }
        public string AllItems { get; set; }
        public string FromItem { get; set; }
        public string ToItem { get; set; }
        public string AllItmType { get; set; }
        public string ItmTypeList { get; set; }
        public string AllCommCtg { get; set; }
        public string CommCtgList { get; set; }
        public string AllHomogCtg { get; set; }
        public string HomogCtgList { get; set; }
        public string OrderReleaseDays { get; set; }
        public string AnticipationDays { get; set; }
        public string GroupByJob { get; set; }
        public string GroupByJobDate { get; set; }
        public string GroupByJobGroupSf { get; set; }
        public string UseCustOrdDeliveryDate { get; set; }
        public string OnlyPurchOrdWithMrpStorage { get; set; }
        public string NetByMoconfirmed { get; set; }
        public string MovePastDate { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string PunctualReorderPoint { get; set; }
        public string SkipSetupTime { get; set; }
    }
}
