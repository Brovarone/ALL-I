using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImPolicies
    {
        public ImPolicies()
        {
            ImPoliciesGoodsCosts = new HashSet<ImPoliciesGoodsCosts>();
            ImPoliciesGoodsValues = new HashSet<ImPoliciesGoodsValues>();
            ImPoliciesProducers = new HashSet<ImPoliciesProducers>();
            ImPoliciesQualification = new HashSet<ImPoliciesQualification>();
            ImPoliciesServicesCosts = new HashSet<ImPoliciesServicesCosts>();
            ImPoliciesServicesValues = new HashSet<ImPoliciesServicesValues>();
        }

        public string Policy { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int? LabourDataOrigin { get; set; }
        public int? GoodsDiscountType { get; set; }
        public double? GoodsDiscount { get; set; }
        public string ReverseLabourDiscountOrder { get; set; }
        public double? GoodsMarkup { get; set; }
        public string PoliciesByProducersEnabled { get; set; }
        public int? LabourValueType { get; set; }
        public string LabourValuesFromSoa { get; set; }
        public string GenericQualification { get; set; }
        public string GroupQualifications { get; set; }
        public double? GenericLabourPrice { get; set; }
        public double? OvertimePrice { get; set; }
        public double? TravelPrice { get; set; }
        public double? VacationLeavePrice { get; set; }
        public double? SickLeavePrice { get; set; }
        public double? CustomPrice1 { get; set; }
        public double? CustomPrice2 { get; set; }
        public double? CustomPrice3 { get; set; }
        public double? CustomPrice4 { get; set; }
        public double? LabourDiscount { get; set; }
        public double? LabourMarkup { get; set; }
        public int? ServicesDiscountType { get; set; }
        public double? ServicesDiscount { get; set; }
        public string ReverseServicesDiscountOrder { get; set; }
        public double? ServicesMarkup { get; set; }
        public string LabourTimeFromCl { get; set; }
        public string ListEmployees { get; set; }
        public int? Clmanagement { get; set; }
        public string GoodsPurcDocValNetDiscount { get; set; }
        public string ServicesPurcDocValNetDiscount { get; set; }
        public string GoodsSaleDocShowDiscount { get; set; }
        public string ServicesSaleDocShowDiscount { get; set; }
        public string GoodsPurcDocCostNetDiscount { get; set; }
        public string ServicesPurcDocCostNetDiscount { get; set; }
        public int? CostValueType { get; set; }
        public string CostGenericQualification { get; set; }
        public int? LabourCostDataOrigin { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public string Disabled { get; set; }

        public virtual ICollection<ImPoliciesGoodsCosts> ImPoliciesGoodsCosts { get; set; }
        public virtual ICollection<ImPoliciesGoodsValues> ImPoliciesGoodsValues { get; set; }
        public virtual ICollection<ImPoliciesProducers> ImPoliciesProducers { get; set; }
        public virtual ICollection<ImPoliciesQualification> ImPoliciesQualification { get; set; }
        public virtual ICollection<ImPoliciesServicesCosts> ImPoliciesServicesCosts { get; set; }
        public virtual ICollection<ImPoliciesServicesValues> ImPoliciesServicesValues { get; set; }
    }
}
