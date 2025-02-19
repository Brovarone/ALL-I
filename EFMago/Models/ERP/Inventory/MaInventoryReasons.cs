using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFMago.Models
{
    public partial class MaInventoryReasons
    {
        public MaInventoryReasons()
        {
            ImInventoryReasonsValues = new HashSet<ImInventoryReasonsValues>();
            MaInventoryReasonsLang = new HashSet<MaInventoryReasonsLang>();
        }

        public string Reason { get; set; }
        public string Description { get; set; }
        public string ShippingReason { get; set; }
        public string FiscalNumbering { get; set; }
        public string StubBook { get; set; }
        public int? ProposedValue { get; set; }
        public string FiscalEnabled { get; set; }
        public string UseGoodsData { get; set; }
        public string UseItemCustomers { get; set; }
        public string UseItemSuppliers { get; set; }
        public string UseCommCtgCustomers { get; set; }
        public string UseCommCtgSuppliers { get; set; }
        public string UseCustom { get; set; }
        public string UseLots { get; set; }
        public string Action { get; set; }
        public string CustomAction { get; set; }
        public string LotAction { get; set; }
        public string UseStorage1 { get; set; }
        public string StoragePhase1 { get; set; }
        public string UseSpecificator1 { get; set; }
        public int? Specificator1Type { get; set; }
        public string SpecificatorPhase1 { get; set; }
        public string Specificator1IsMand { get; set; }
        public string UsePhase2 { get; set; }
        public string UseStorage2 { get; set; }
        public string StoragePhase2 { get; set; }
        public string UseSpecificator2 { get; set; }
        public int? Specificator2Type { get; set; }
        public string SpecificatorPhase2 { get; set; }
        public string Specificator2IsMand { get; set; }
        public string Predefined { get; set; }
        public string NonFiscal { get; set; }
        public string DocInfoIsOpt { get; set; }
        public string DocNoIsOpt { get; set; }
        public string QtyIsOpt { get; set; }
        public string ValueIsOpt { get; set; }
        public int? CustSuppType { get; set; }
        public string Disabled { get; set; }
        public string GenerateLot { get; set; }
        public int? CostAccounting { get; set; }
        public int? DebitCreditSign { get; set; }
        public string GenerateSerialNo { get; set; }
        public string InvoiceFollows { get; set; }
        public string SearchForBarCode { get; set; }
        public string AlignSpecificator { get; set; }
        public string NoChangeExigibility { get; set; }
        public string UseLocations { get; set; }
        public string LocationsAction { get; set; }
        public string CancelReason { get; set; }
        public int? LineCostOrigin { get; set; }
        public string NeedCigcorrection { get; set; }
        public string CigcorrInvReason { get; set; }
        public string UseFifoaction { get; set; }
        public string UseLifoaction { get; set; }
        public string Fifoaction { get; set; }
        public string Lifoaction { get; set; }
        public Guid? Tbguid { get; set; }
        public string InBaseCurrency { get; set; }
        public string IsInventoryAdjustement { get; set; }
        public string IsStorageTransfer { get; set; }
        public string ActionsFiscalDataPhase1 { get; set; }
        public string ActionsFiscalDataPhase2 { get; set; }
        public string FiscalPhase1Enabled { get; set; }
        public string FiscalPhase2Enabled { get; set; }
        public string EditableUnitValue { get; set; }
        public string EditableStubBook { get; set; }
        public string UsedEverywhere { get; set; }
        public string UsedInSales { get; set; }
        public string UsedInPurchases { get; set; }
        public string UsedInInventory { get; set; }
        public string UsedInManufacturing { get; set; }
        public string DefaultReason { get; set; }
        public int? ActionOnLifoFifo { get; set; }
        public int? LifoFifoLineSource { get; set; }
        public int? CostAccSign { get; set; }
        public string ExtAccountingTemplate { get; set; }
        public DateTime Tbcreated { get; set; }
        public DateTime Tbmodified { get; set; }
        public int TbcreatedId { get; set; }
        public int TbmodifiedId { get; set; }
        public int? ImPromptInMagoNetSchedule { get; set; }

        public virtual ImInvRsnPolicies ImInvRsnPolicies { get; set; }
        public virtual ICollection<ImInventoryReasonsValues> ImInventoryReasonsValues { get; set; }
        public virtual ICollection<MaInventoryReasonsLang> MaInventoryReasonsLang { get; set; }
    }
}
