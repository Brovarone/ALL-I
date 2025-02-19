using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaBrvehicle
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string LicensePlate { get; set; }
        public string RegFederalState { get; set; }
        public short? RegYear { get; set; }
        public string EngineSize { get; set; }
        public string Color { get; set; }
        public string FrameNumber { get; set; }
        public double? TareWeightKg { get; set; }
        public double? CapacityKg { get; set; }
        public double? CapacityM3 { get; set; }
        public int? VehicleType { get; set; }
        public int? Property { get; set; }
        public string Rntc { get; set; }
        public int? FuelType { get; set; }
        public Guid? Tbguid { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
    }
}
