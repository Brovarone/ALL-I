using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class InventoryAccountingDbContext : DbContext
    {
        public InventoryAccountingDbContext()
        {
        }
        public InventoryAccountingDbContext(DbContextOptions<InventoryAccountingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaChangeRetailData> MaChangeRetailData { get; set; }
        public virtual DbSet<MaChangeRetailDataDetail> MaChangeRetailDataDetail { get; set; }
        public virtual DbSet<MaExtAccTemplate> MaExtAccTemplate { get; set; }
        public virtual DbSet<MaExtAccTemplateDetail> MaExtAccTemplateDetail { get; set; }
        public virtual DbSet<MaInvAccDefaults> MaInvAccDefaults { get; set; }
        public virtual DbSet<MaInvAccDefaultsDetail> MaInvAccDefaultsDetail { get; set; }
        public virtual DbSet<MaInvAccTransParameters> MaInvAccTransParameters { get; set; }
        public virtual DbSet<MaItemsStorageRetailPrices> MaItemsStorageRetailPrices { get; set; }
        public virtual DbSet<MaOffsetsCustSupp> MaOffsetsCustSupp { get; set; }
        public virtual DbSet<MaOffsetsItems> MaOffsetsItems { get; set; }
        public virtual DbSet<MaOffsetsItemsCommodityCtg> MaOffsetsItemsCommodityCtg { get; set; }
        public virtual DbSet<MaOffsetsStorages> MaOffsetsStorages { get; set; }
        public virtual DbSet<MaOffsetsStoragesHead> MaOffsetsStoragesHead { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaChangeRetailData>(entity =>
{
                entity.HasKey(e => e.ChangeRetailDataId)
                    .HasName("PK_ChangeRetailData")
                    .IsClustered(false);

                entity.ToTable("MA_ChangeRetailData");

                entity.Property(e => e.ChangeRetailDataId)
                    .HasColumnName("ChangeRetailDataID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccTemplate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChangeRetailDataDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ChangeRetailDataNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ForTaxChange)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ForValue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.GrandTotDiff).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PostingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Storage)
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

                entity.Property(e => e.TotNetPriceDiff).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotVatdiff)
                    .HasColumnName("TotVATDiff")
                    .HasDefaultValueSql("((0.00))");
            });
            modelBuilder.Entity<MaChangeRetailDataDetail>(entity =>
{
                entity.HasKey(e => new { e.ChangeRetailDataId, e.ChangeRetailDataLine })
                    .HasName("PK_ChangeRetailDataDetail")
                    .IsClustered(false);

                entity.ToTable("MA_ChangeRetailDataDetail");

                entity.Property(e => e.ChangeRetailDataId).HasColumnName("ChangeRetailDataID");

                entity.Property(e => e.BaseUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefLine)
                    .HasColumnName("CRRefLine")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.CurrentPrice).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CurrentTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NewPrice).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NewTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.TotDiff).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Vatdiff)
                    .HasColumnName("VATDiff")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.WithTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.ChangeRetailData)
                    .WithMany(p => p.MaChangeRetailDataDetail)
                    .HasForeignKey(d => d.ChangeRetailDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChangeRetailDataDetail_00");
            });
            modelBuilder.Entity<MaExtAccTemplate>(entity =>
{
                entity.HasKey(e => e.Template)
                    .HasName("PK_ExtAccTemplate")
                    .IsClustered(false);

                entity.ToTable("MA_ExtAccTemplate");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_ExtAccTemplate2");

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AccountingTemplate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocDateFormula)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GroupRepeatedLines)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SwitchCreditDebit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.UseBaseCurrency)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaExtAccTemplateDetail>(entity =>
{
                entity.HasKey(e => new { e.Template, e.Line })
                    .HasName("PK_ExtAccTemplateDetail")
                    .IsClustered(false);

                entity.ToTable("MA_ExtAccTemplateDetail");

                entity.Property(e => e.Template)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AccountFormula)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccountingReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AmountFormula)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AmountType).HasDefaultValueSql("((6356992))");

                entity.Property(e => e.CustSuppFormula)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitCredit).HasDefaultValueSql("((4980736))");

                entity.Property(e => e.LineType).HasDefaultValueSql("((3080194))");

                entity.Property(e => e.OffsetGroupNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Repeat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StorageNo).HasDefaultValueSql("((1))");

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

                entity.HasOne(d => d.TemplateNavigation)
                    .WithMany(p => p.MaExtAccTemplateDetail)
                    .HasForeignKey(d => d.Template)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExtAccTemp_ExtAccTemp_00");
            });
            modelBuilder.Entity<MaInvAccDefaults>(entity =>
{
                entity.HasKey(e => e.InvAccDefaultsId)
                    .HasName("PK_InvAccDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_InvAccDefaults");

                entity.Property(e => e.InvAccDefaultsId).ValueGeneratedNever();

                entity.Property(e => e.CustomerAccountRoot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemConsumptionOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemPurchacesOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemSalesOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchasesGoodsOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RetailPriceChangeAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RetailPriceChangeAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SalesGoodsOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServicesPurchasesOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServicesSalesOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierAccountRoot)
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
            });
            modelBuilder.Entity<MaInvAccDefaultsDetail>(entity =>
{
                entity.HasKey(e => new { e.InvAccDefaultsId, e.OffsetSymbol })
                    .HasName("PK_InvAccDefaultsDetail")
                    .IsClustered(false);

                entity.ToTable("MA_InvAccDefaultsDetail");

                entity.Property(e => e.OffsetSymbol)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Offset)
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

                entity.HasOne(d => d.InvAccDefaults)
                    .WithMany(p => p.MaInvAccDefaultsDetail)
                    .HasForeignKey(d => d.InvAccDefaultsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvAccDefa_InvAccDefa_00");
            });
            modelBuilder.Entity<MaInvAccTransParameters>(entity =>
{
                entity.HasKey(e => e.Id)
                    .HasName("PK_InvAccTransParameters")
                    .IsClustered(false);

                entity.ToTable("MA_InvAccTransParameters");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CorrPurcInvExtAccTempInt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CorrPurchaseInvExtAccTemp)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrSaleInvExtAccTempIntegra)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CorrSaleInvoiceExtAccTem)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsRetailAndWholesale)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsRetailOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurCrNoteInvExtAcc)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurCrNoteInvExtAccInt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurcInvExtAccTempIntegrated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchaseInvoiceExtAccTemp)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleCrNoteInvExtAcc)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleCrNoteInvExtAccInt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SaleInvExtAccTempIntegrated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SaleInvoiceExtAccTemp)
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

                entity.Property(e => e.UseSpecAccForExcDiff)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaItemsStorageRetailPrices>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Storage })
                    .HasName("PK_ItemsStorageRetailPrices")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsStorageRetailPrices");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

                entity.Property(e => e.PriceWithTax)
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
            });
            modelBuilder.Entity<MaOffsetsCustSupp>(entity =>
{
                entity.HasKey(e => new { e.CustSupp, e.CustSuppType, e.OffsetSymbol })
                    .HasName("PK_OffsetsCustSupp")
                    .IsClustered(false);

                entity.ToTable("MA_OffsetsCustSupp");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.OffsetSymbol)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Offset)
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
            });
            modelBuilder.Entity<MaOffsetsItems>(entity =>
{
                entity.HasKey(e => new { e.Item, e.OffsetSymbol })
                    .HasName("PK_OffsetsItems")
                    .IsClustered(false);

                entity.ToTable("MA_OffsetsItems");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.OffsetSymbol)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Offset)
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
            });
            modelBuilder.Entity<MaOffsetsItemsCommodityCtg>(entity =>
{
                entity.HasKey(e => new { e.CommodityCtg, e.OffsetSymbol })
                    .HasName("PK_OffsetsItemsCommodityCtg")
                    .IsClustered(false);

                entity.ToTable("MA_OffsetsItemsCommodityCtg");

                entity.Property(e => e.CommodityCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.OffsetSymbol)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Offset)
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
            });
            modelBuilder.Entity<MaOffsetsStorages>(entity =>
{
                entity.HasKey(e => new { e.Storage, e.OffsetSymbol })
                    .HasName("PK_OffsetsStorages")
                    .IsClustered(false);

                entity.ToTable("MA_OffsetsStorages");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.OffsetSymbol)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Offset)
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
            });
            modelBuilder.Entity<MaOffsetsStoragesHead>(entity =>
{
                entity.HasKey(e => e.Storage)
                    .HasName("PK_OffsetsStoragesHead")
                    .IsClustered(false);

                entity.ToTable("MA_OffsetsStoragesHead");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumptionOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerAccountRoot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchasesGoodsOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SalesGoodsOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServicesPurchasesOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServicesSalesOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierAccountRoot)
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
            });
        }
    }
}
