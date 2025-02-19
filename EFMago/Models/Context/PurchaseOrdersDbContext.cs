using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class PurchaseOrdersDbContext : DbContext
    {
        public PurchaseOrdersDbContext()
        {
        }
        public PurchaseOrdersDbContext(DbContextOptions<PurchaseOrdersDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaPurchaseOrd> MaPurchaseOrd { get; set; }
        public virtual DbSet<MaPurchaseOrdDefaults> MaPurchaseOrdDefaults { get; set; }
        public virtual DbSet<MaPurchaseOrdDetails> MaPurchaseOrdDetails { get; set; }
        public virtual DbSet<MaPurchaseOrdNotes> MaPurchaseOrdNotes { get; set; }
        public virtual DbSet<MaPurchaseOrdParameters> MaPurchaseOrdParameters { get; set; }
        public virtual DbSet<MaPurchaseOrdPymtSched> MaPurchaseOrdPymtSched { get; set; }
        public virtual DbSet<MaPurchaseOrdReferences> MaPurchaseOrdReferences { get; set; }
        public virtual DbSet<MaPurchaseOrdShipping> MaPurchaseOrdShipping { get; set; }
        public virtual DbSet<MaPurchaseOrdSummary> MaPurchaseOrdSummary { get; set; }
        public virtual DbSet<MaPurchaseOrdTaxSummay> MaPurchaseOrdTaxSummay { get; set; }
        public virtual DbSet<MaTmpReorderingFromSupp> MaTmpReorderingFromSupp { get; set; }
        public virtual DbSet<MaTmpReorderingFromSuppRef> MaTmpReorderingFromSuppRef { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaPurchaseOrd>(entity =>
{
                entity.HasKey(e => e.PurchaseOrdId)
                    .HasName("PK_PurchaseOrd")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseOrd");

                entity.HasIndex(e => e.Delivered)
                    .HasName("MA_PurchaseOrd5");

                entity.HasIndex(e => e.InternalOrdNo)
                    .HasName("MA_PurchaseOrd2");

                entity.HasIndex(e => e.Paid)
                    .HasName("MA_PurchaseOrd6");

                entity.HasIndex(e => e.SubcontractorOrder)
                    .HasName("MA_PurchaseOrd7");

                entity.HasIndex(e => new { e.OrderDate, e.InternalOrdNo })
                    .HasName("MA_PurchaseOrd4");

                entity.HasIndex(e => new { e.Supplier, e.OrderDate })
                    .HasName("MA_PurchaseOrd3");

                entity.Property(e => e.PurchaseOrdId).ValueGeneratedNever();

                entity.Property(e => e.AccGroup)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Archived)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BarcodeSegment)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CompanyBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyCa)
                    .HasColumnName("CompanyCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfirmedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ContractCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211265))");

                entity.Property(e => e.Delivered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ExternalOrdNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fixing).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FixingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FixingIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InternalOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.NetOfTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NonStandardPayment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.OurReference)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Paid)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Receipt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SendDocumentsTo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SentByEmail)
                    .HasColumnName("SentByEMail")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SentByPostaLite)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Specificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.Specificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.SpecificatorPhase1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StubBook)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubcontractorOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierCa)
                    .HasColumnName("SupplierCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxCommunicationGroup)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxJournal)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbguid)
                    .HasColumnName("TBGuid")
                    .HasDefaultValueSql("(0x00)");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.UseBusinessYear)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.YourReference)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaPurchaseOrdDefaults>(entity =>
{
                entity.HasKey(e => e.MaPurchaseOrdDefaultsId)
                    .HasName("PK_PurchaseOrdDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseOrdDefaults");

                entity.Property(e => e.MaPurchaseOrdDefaultsId)
                    .HasColumnName("MA_PurchaseOrdDefaultsId")
                    .ValueGeneratedNever();

                entity.Property(e => e.BillofLadingPostingRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EupurchaseOrderAccTpl)
                    .HasColumnName("EUPurchaseOrderAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtraEupurchaseOrderAccTpl)
                    .HasColumnName("ExtraEUPurchaseOrderAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseOrderAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseOrderInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuspTaxPurchaseOrderAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaPurchaseOrdDetails>(entity =>
{
                entity.HasKey(e => new { e.PurchaseOrdId, e.Line })
                    .HasName("PK_PurchaseOrdDetails")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseOrdDetails");

                entity.HasIndex(e => e.Job)
                    .HasName("MA_PurchaseOrdDetails7");

                entity.HasIndex(e => new { e.Item, e.ExpectedDeliveryDate })
                    .HasName("MA_PurchaseOrdDetails3");

                entity.HasIndex(e => new { e.Supplier, e.LineType })
                    .HasName("MA_PurchaseOrdDetails8");

                entity.HasIndex(e => new { e.Delivered, e.ExpectedDeliveryDate, e.Item })
                    .HasName("MA_PurchaseOrdDetails2");

                entity.HasIndex(e => new { e.ExpectedDeliveryDate, e.Item, e.LineType, e.Delivered, e.Cancelled })
                    .HasName("MA_PurchaseOrdDetails5");

                entity.HasIndex(e => new { e.Item, e.ExpectedDeliveryDate, e.LineType, e.Delivered, e.Cancelled })
                    .HasName("MA_PurchaseOrdDetails4");

                entity.HasIndex(e => new { e.Moid, e.RtgStep, e.Alternate, e.AltRtgStep, e.PurchaseOrdId })
                    .HasName("MA_PurchaseOrdDetails6");

                entity.Property(e => e.AdditionalQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalQty1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalQty2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalQty3).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AltRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfirmationNum)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfirmedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefSubId)
                    .HasColumnName("CRRefSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.DefaultValueType).HasDefaultValueSql("((9437191))");

                entity.Property(e => e.Delivered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeliveredQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Department)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountDefaultType).HasDefaultValueSql("((9568262))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ExtendedNotes)
                    .HasColumnType("ntext")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExternalLineReference).HasDefaultValueSql("((0))");

                entity.Property(e => e.FixedCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ImDelReqLine)
                    .HasColumnName("IM_DelReqLine")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ImDeliveryRequestId)
                    .HasColumnName("IM_DeliveryRequestId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ImJobWorkingStep)
                    .HasColumnName("IM_JobWorkingStep")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KitNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.KitQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.LineType).HasDefaultValueSql("((3538947))");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Moid)
                    .HasColumnName("MOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NetWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NoDn)
                    .HasColumnName("NoDN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoOfPacks).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoPrint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Offset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PacksUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Paid)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PaidQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Position).HasDefaultValueSql("((0))");

                entity.Property(e => e.PreviousConfirmedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseReqId).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseReqNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseReqPos).HasDefaultValueSql("((0))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Receipt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReceiptAndDeliveredQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ReceiptQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceDocId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOrdPos).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleType).HasDefaultValueSql("((3670020))");

                entity.Property(e => e.SpecificatorPhase1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppQuotaId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppQuotaLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.PurchaseOrd)
                    .WithMany(p => p.MaPurchaseOrdDetails)
                    .HasForeignKey(d => d.PurchaseOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOr_PurchaseOr_02");
            });
            modelBuilder.Entity<MaPurchaseOrdNotes>(entity =>
{
                entity.HasKey(e => e.PurchaseOrdId)
                    .HasName("PK_PurchaseOrdNotes")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseOrdNotes");

                entity.Property(e => e.PurchaseOrdId).ValueGeneratedNever();

                entity.Property(e => e.Notes)
                    .HasMaxLength(251)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.HasOne(d => d.PurchaseOrd)
                    .WithOne(p => p.MaPurchaseOrdNotes)
                    .HasForeignKey<MaPurchaseOrdNotes>(d => d.PurchaseOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOr_PurchaseOr_04");
            });
            modelBuilder.Entity<MaPurchaseOrdParameters>(entity =>
{
                entity.HasKey(e => e.PurchaseOrdParametersId)
                    .HasName("PK_PurchaseOrdParameters")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseOrdParameters");

                entity.Property(e => e.PurchaseOrdParametersId).ValueGeneratedNever();

                entity.Property(e => e.DefaultEmptyConfDelivDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DefaultSupplExpDelivDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.WarningMaximumStock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaPurchaseOrdPymtSched>(entity =>
{
                entity.HasKey(e => new { e.PurchaseOrdId, e.InstallmentNo })
                    .HasName("PK_PurchaseOrdPymtSched")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseOrdPymtSched");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DueDateDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.InstallmStartDate).HasDefaultValueSql("((7602177))");

                entity.Property(e => e.InstallmentType).HasDefaultValueSql("((5505024))");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.HasOne(d => d.PurchaseOrd)
                    .WithMany(p => p.MaPurchaseOrdPymtSched)
                    .HasForeignKey(d => d.PurchaseOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOr_PurchaseOr_01");
            });
            modelBuilder.Entity<MaPurchaseOrdReferences>(entity =>
{
                entity.HasKey(e => new { e.PurchaseOrdId, e.Line })
                    .HasName("PK_PurchaseOrdReferences")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseOrdReferences");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((6684681))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.HasOne(d => d.PurchaseOrd)
                    .WithMany(p => p.MaPurchaseOrdReferences)
                    .HasForeignKey(d => d.PurchaseOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOr_PurchaseOr_03");
            });
            modelBuilder.Entity<MaPurchaseOrdShipping>(entity =>
{
                entity.HasKey(e => e.PurchaseOrdId)
                    .HasName("PK_PurchaseOrdShipping")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseOrdShipping");

                entity.Property(e => e.PurchaseOrdId).ValueGeneratedNever();

                entity.Property(e => e.Carrier1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier3)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossVolumeIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossWeightIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NetWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NetWeightIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NoOfPacks).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoOfPacksIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Package)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShipToAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShipToCustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShipToCustSuppType).HasDefaultValueSql("((6094850))");

                entity.Property(e => e.Shipping)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.Transport)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.PurchaseOrd)
                    .WithOne(p => p.MaPurchaseOrdShipping)
                    .HasForeignKey<MaPurchaseOrdShipping>(d => d.PurchaseOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOr_PurchaseOr_00");
            });
            modelBuilder.Entity<MaPurchaseOrdSummary>(entity =>
{
                entity.HasKey(e => e.PurchaseOrdId)
                    .HasName("PK_PurchaseOrdSummary")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseOrdSummary");

                entity.Property(e => e.PurchaseOrdId).ValueGeneratedNever();

                entity.Property(e => e.AdditionalCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AdvanceAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Allowances).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CashOnDeliveryCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CashOnDeliveryPercentage).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CollectionCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CollectionChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CollectionChargesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiscountOnGoods).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountOnServices).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discounts).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountsIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.FreeSamples).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FreeSamplesDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GoodsAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InsuranceCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InsuranceChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PackagingCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PackagingChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PayableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PayableAmountInBaseCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServiceAmounts).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShippingCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShippingChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ShippingChargesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StampsCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StampsChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.StampsChargesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.PurchaseOrd)
                    .WithOne(p => p.MaPurchaseOrdSummary)
                    .HasForeignKey<MaPurchaseOrdSummary>(d => d.PurchaseOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOr_PurchaseOr_06");
            });
            modelBuilder.Entity<MaPurchaseOrdTaxSummay>(entity =>
{
                entity.HasKey(e => new { e.PurchaseOrdId, e.TaxCode })
                    .HasName("PK_PurchaseOrdTaxSummay")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseOrdTaxSummay");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.PurchaseOrd)
                    .WithMany(p => p.MaPurchaseOrdTaxSummay)
                    .HasForeignKey(d => d.PurchaseOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOr_PurchaseOr_05");
            });
            modelBuilder.Entity<MaTmpReorderingFromSupp>(entity =>
{
                entity.HasKey(e => new { e.Supplier, e.Item, e.ReferenceDocNo, e.Position, e.Storage, e.SpecificatorType, e.Specificator })
                    .HasName("PK_TmpReorderingFromSupp")
                    .IsClustered(false);

                entity.ToTable("MA_TmpReorderingFromSupp");

                entity.HasIndex(e => e.Deselected)
                    .HasName("MA_TmpReorderingFromSupp2");

                entity.HasIndex(e => new { e.Supplier, e.Item })
                    .HasName("MA_TmpReorderingFromSupp5");

                entity.HasIndex(e => new { e.Item, e.ReferenceDocNo, e.Position })
                    .HasName("MA_TmpReorderingFromSupp3");

                entity.HasIndex(e => new { e.Supplier, e.Item, e.Storage })
                    .HasName("MA_TmpReorderingFromSupp6");

                entity.HasIndex(e => new { e.Supplier, e.Storage, e.SpecificatorType, e.Specificator })
                    .HasName("MA_TmpReorderingFromSupp8");

                entity.HasIndex(e => new { e.Supplier, e.Item, e.Storage, e.SpecificatorType, e.Specificator })
                    .HasName("MA_TmpReorderingFromSupp4");

                entity.HasIndex(e => new { e.Supplier, e.Item, e.Storage, e.SpecificatorType, e.Specificator, e.ReferenceDocNo, e.Position })
                    .HasName("MA_TmpReorderingFromSupp7");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.City)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.County)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Deselected)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MinOrderQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.MinimumStock).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NotOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OnHand).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Ordered).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Price).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PurchaseFixing).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ReorderingLotSize).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ReservationType)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Reserved).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SaleOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SupplierOrdered).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");

                entity.Property(e => e.ToOrder).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalAmountInBaseCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Zipcode)
                    .HasColumnName("ZIPCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaTmpReorderingFromSuppRef>(entity =>
{
                entity.HasKey(e => new { e.Supplier, e.SaleOrdId })
                    .HasName("PK_TmpReorderingFromSuppRef")
                    .IsClustered(false);

                entity.ToTable("MA_TmpReorderingFromSuppRef");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.RefDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ReferenceDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tbcreated)
                    .HasColumnName("TBCreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbcreatedId).HasColumnName("TBCreatedID");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
        }
    }
}
