using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class ImGeneralSettings
    {
        public ImGeneralSettings()
        {
            ImCostsSchedule = new HashSet<ImCostsSchedule>();
            ImValuesDiscountsSchedule = new HashSet<ImValuesDiscountsSchedule>();
        }

        public short SettingId { get; set; }
        public double? HourlyRate { get; set; }
        public double? MarkupPerc { get; set; }
        public int? ItemValorization { get; set; }
        public int? UseImpiantiSchedule { get; set; }
        public string GoodsMarkupFormula { get; set; }
        public string LabourMarkupFormula { get; set; }
        public string ServicesMarkupFormula { get; set; }
        public string ChargesMarkupFormula { get; set; }
        public string OtherMarkupFormula { get; set; }
        public int? DefaultPurReqValueType { get; set; }
        public int? DefaultPurReqDiscountType { get; set; }
        public string DefaultPurReqStorage { get; set; }
        public int? DefaultPurReqSpecType { get; set; }
        public string DefaultPurReqSpec { get; set; }
        public int? DefaultProgressConfirmMode { get; set; }
        public string IgnoreWrgoodsOnEconAnal { get; set; }
        public int? DefaultLineTypePastingSpec { get; set; }
        public string DefaultInvRsnInStandardJob { get; set; }
        public string DefaultInvRsnInVariantJob { get; set; }
        public string DefaultInvRsnInOatambjob { get; set; }
        public string DefaultInvRsnInPurchInvStdJob { get; set; }
        public string DefaultInvRsnInPurchInvVarJob { get; set; }
        public string DefaultInvRsnInPurchInvOatambjob { get; set; }
        public int? DefaultOriginCostsSubcontract { get; set; }
        public string DefaultServiceSubcontract { get; set; }
        public short? DataCheckerVersion { get; set; }
        public string DataCheckerOwner { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }

        public virtual ImWrsettings ImWrsettings { get; set; }
        public virtual ICollection<ImCostsSchedule> ImCostsSchedule { get; set; }
        public virtual ICollection<ImValuesDiscountsSchedule> ImValuesDiscountsSchedule { get; set; }
    }
}
