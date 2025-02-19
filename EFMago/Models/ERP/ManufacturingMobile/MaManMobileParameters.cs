using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaManMobileParameters
    {
        public short ManMobileParametersId { get; set; }
        public string AllowEmptyItem { get; set; }
        public string AllowEmptyLot { get; set; }
        public string EditItem { get; set; }
        public string EditLot { get; set; }
        public short? MonitorRefresh { get; set; }
        public string CheckPickings { get; set; }
        public short? MoconfirmationSeconds { get; set; }
        public short? MoconfirmationRetries { get; set; }
        public short? RetryBeforeIdle { get; set; }
        public short? MaxThreads { get; set; }
        public string BlockMo { get; set; }
        public string EnableConfirmationByHandHeld { get; set; }
        public string ReorderUseAvailability { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
