using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class MRPDbContext : DbContext
    {
        public MRPDbContext()
        {
        }
        public MRPDbContext(DbContextOptions<MRPDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaMrpparameters> MaMrpparameters { get; set; }
        public virtual DbSet<MaMrpsimulations> MaMrpsimulations { get; set; }
        public virtual DbSet<MaPurchaseReq> MaPurchaseReq { get; set; }
        public virtual DbSet<MaPurchaseReqDetail> MaPurchaseReqDetail { get; set; }
        public virtual DbSet<MaPurchaseReqRequirements> MaPurchaseReqRequirements { get; set; }
        public virtual DbSet<MaSaleForecasts> MaSaleForecasts { get; set; }
        public virtual DbSet<MaTmpAvailabilityForecast> MaTmpAvailabilityForecast { get; set; }
        public virtual DbSet<MaTmpMrpproposals> MaTmpMrpproposals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaMrpparameters>(entity =>
{
                entity.HasKey(e => e.MrpparametersId)
                    .HasName("PK_MRPParameters")
                    .IsClustered(false);

                entity.ToTable("MA_MRPParameters");

                entity.Property(e => e.MrpparametersId)
                    .HasColumnName("MRPParametersId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Mrphorizon)
                    .HasColumnName("MRPHorizon")
                    .HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaMrpsimulations>(entity =>
{
                entity.HasKey(e => e.Simulation)
                    .HasName("PK_MRPSimulations")
                    .IsClustered(false);

                entity.ToTable("MA_MRPSimulations");

                entity.Property(e => e.Simulation)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AheadDepositDaysMo)
                    .HasColumnName("AheadDepositDaysMO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AheadDepositDaysPo)
                    .HasColumnName("AheadDepositDaysPO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AllCommCtg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllHomogCtg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllItems)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllItmType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllMo)
                    .HasColumnName("AllMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AnticipationDays)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CommCtgList)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreateMoonly)
                    .HasColumnName("CreateMOOnly")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CreatePronly)
                    .HasColumnName("CreatePROnly")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DayOfRequirement).HasDefaultValueSql("((1))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExplodeAllBomlevels)
                    .HasColumnName("ExplodeAllBOMLevels")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FinishedLeadTimeOrigin).HasDefaultValueSql("((23330817))");

                entity.Property(e => e.FromItem)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromMo)
                    .HasColumnName("FromMO")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromMoexisting)
                    .HasColumnName("FromMOExisting")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FromProdPlan)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FromReorderPoint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FromSaleOrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupByJob)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupByJobDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupByJobGroupSf)
                    .HasColumnName("GroupByJobGroupSF")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupLotsByDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.HomogCtgList)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Horizon).HasDefaultValueSql("((0))");

                entity.Property(e => e.HrzEndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.HrzType).HasDefaultValueSql("((22806528))");

                entity.Property(e => e.IncludeSaleOrdExpired)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ItmTypeList)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaxLevelBomexplosion)
                    .HasColumnName("MaxLevelBOMExplosion")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mocreated)
                    .HasColumnName("MOCreated")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MoinProgress)
                    .HasColumnName("MOInProgress")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Moreleased)
                    .HasColumnName("MOReleased")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MovePastDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NetByItemMaster)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NetByMo)
                    .HasColumnName("NetByMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NetByMoEmptyJob)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NetByMoconfirmed)
                    .HasColumnName("NetByMOConfirmed")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NetByPurchOrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NetFirstLevelOnDayReqPolicy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NetFirstLevelOnJobPolicy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NetFirstLevelOnLotPolicy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NetOtherLevelsOnDayReqPolicy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NetOtherLevelsOnJobPolicy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NetOtherLevelsOnLotPolicy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OnlyPurchOrdWithMrpStorage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OpenOrdersOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OrderReleaseDays)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProdPlanId)
                    .HasColumnName("ProdPlanID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PunctualReorderPoint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchaseLeadTimeOrigin).HasDefaultValueSql("((23330817))");

                entity.Property(e => e.ReorderPointDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.RunDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SaleForecastsOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SaleOrdSaleForeRelation).HasDefaultValueSql("((22872068))");

                entity.Property(e => e.SaleOrdersOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Signature)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SkipNotWorkingDays)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SkipSetupTime)
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

                entity.Property(e => e.ToItem)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ToMo)
                    .HasColumnName("ToMO")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UseAheadDepositMo)
                    .HasColumnName("UseAheadDepositMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseAheadDepositPo)
                    .HasColumnName("UseAheadDepositPO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseCustOrdDeliveryDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UseDeliveryConfirmedDatePo)
                    .HasColumnName("UseDeliveryConfirmedDatePO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseDeliveryExpectedDatePo)
                    .HasColumnName("UseDeliveryExpectedDatePO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UseMinStock)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseSimulatedEndDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WeekDayOfRequirement).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaPurchaseReq>(entity =>
{
                entity.HasKey(e => e.PurchaseReqId)
                    .HasName("PK_PurchaseReq")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseReq");

                entity.Property(e => e.PurchaseReqId).ValueGeneratedNever();

                entity.Property(e => e.CodeType).HasDefaultValueSql("((23986176))");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Fulfilled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseReqNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Simulation)
                    .HasMaxLength(15)
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
            });
            modelBuilder.Entity<MaPurchaseReqDetail>(entity =>
{
                entity.HasKey(e => new { e.PurchaseReqId, e.Line })
                    .HasName("PK_PurchaseReqDetail")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseReqDetail");

                entity.Property(e => e.ConfirmationLevel)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Feasibility).HasDefaultValueSql("((23396353))");

                entity.Property(e => e.GoodsDelivery)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IssueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MrpconfirmationRank)
                    .HasColumnName("MRPConfirmationRank")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Position).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseOrdPos).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseReqNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseReqStatus).HasDefaultValueSql("((23068672))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShipToCustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShipToCustSuppType).HasDefaultValueSql("((6094850))");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
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

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.PurchaseReq)
                    .WithMany(p => p.MaPurchaseReqDetail)
                    .HasForeignKey(d => d.PurchaseReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseRe_PurchaseRe_00");
            });
            modelBuilder.Entity<MaPurchaseReqRequirements>(entity =>
{
                entity.HasKey(e => new { e.PurchaseReqId, e.Line, e.MocompLine })
                    .HasName("PK_PurchaseReqRequirements")
                    .IsClustered(false);

                entity.ToTable("MA_PurchaseReqRequirements");

                entity.Property(e => e.MocompLine).HasColumnName("MOCompLine");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParentMoid)
                    .HasColumnName("ParentMOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentMono)
                    .HasColumnName("ParentMONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PurchaseOrdPos).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseReqNo)
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

                entity.HasOne(d => d.MaPurchaseReqDetail)
                    .WithMany(p => p.MaPurchaseReqRequirements)
                    .HasForeignKey(d => new { d.PurchaseReqId, d.Line })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseRe_PurchaseRe_01");
            });
            modelBuilder.Entity<MaSaleForecasts>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Year, e.Month, e.Week, e.Job, e.CostCenter })
                    .HasName("PK_SaleForecasts")
                    .IsClustered(false);

                entity.ToTable("MA_SaleForecasts");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleQuantity).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaTmpAvailabilityForecast>(entity =>
{
                entity.HasKey(e => new { e.Simulation, e.Variant, e.SimulatedDate, e.Item, e.Line })
                    .HasName("PK_TmpAvailabilityForecast")
                    .IsClustered(false);

                entity.ToTable("MA_TmpAvailabilityForecast");

                entity.Property(e => e.Simulation)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.SimulatedDate).HasColumnType("datetime");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmationLevel)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Delay)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DocLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((23461888))");

                entity.Property(e => e.EventType).HasDefaultValueSql("((22085636))");

                entity.Property(e => e.GroupSf)
                    .HasColumnName("GroupSF")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProdPlanForShortage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProductKind).HasDefaultValueSql("((22413314))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.Value).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaTmpMrpproposals>(entity =>
{
                entity.HasKey(e => new { e.Line, e.Simulation })
                    .HasName("PK_TmpMRPProposals")
                    .IsClustered(false);

                entity.ToTable("MA_TmpMRPProposals");

                entity.Property(e => e.Simulation)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DescriptiveText)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((23461888))");

                entity.Property(e => e.Feasibility).HasDefaultValueSql("((23396353))");

                entity.Property(e => e.IssueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Product)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductKind).HasDefaultValueSql("((22413314))");

                entity.Property(e => e.ProposedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdNo)
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

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
        }
    }
}
