using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class ManufacturingDbContext : DbContext
    {
        public ManufacturingDbContext()
        {
        }
        public ManufacturingDbContext(DbContextOptions<ManufacturingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaBomposting> MaBomposting { get; set; }
        public virtual DbSet<MaManufacturingParameters> MaManufacturingParameters { get; set; }
        public virtual DbSet<MaMo> MaMo { get; set; }
        public virtual DbSet<MaMocomponents> MaMocomponents { get; set; }
        public virtual DbSet<MaMocomponentsStepsQty> MaMocomponentsStepsQty { get; set; }
        public virtual DbSet<MaMohierarchies> MaMohierarchies { get; set; }
        public virtual DbSet<MaMolabour> MaMolabour { get; set; }
        public virtual DbSet<MaMosteps> MaMosteps { get; set; }
        public virtual DbSet<MaMostepsDetailedQty> MaMostepsDetailedQty { get; set; }
        public virtual DbSet<MaMostepsKanban> MaMostepsKanban { get; set; }
        public virtual DbSet<MaPickings> MaPickings { get; set; }
        public virtual DbSet<MaTmpMoexplosion> MaTmpMoexplosion { get; set; }
        public virtual DbSet<MaTmpMoimplosion> MaTmpMoimplosion { get; set; }
        public virtual DbSet<MaTmpPapersPrint> MaTmpPapersPrint { get; set; }
        public virtual DbSet<MaTmpProducibilityAnalysis> MaTmpProducibilityAnalysis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaBomposting>(entity =>
{
                entity.HasKey(e => e.BompostingId)
                    .HasName("PK_BOMPosting")
                    .IsClustered(false);

                entity.ToTable("MA_BOMPosting");

                entity.Property(e => e.BompostingId)
                    .HasColumnName("BOMPostingId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BompostingNo)
                    .HasColumnName("BOMPostingNo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

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
            modelBuilder.Entity<MaManufacturingParameters>(entity =>
{
                entity.HasKey(e => e.ManufacturingParametersId)
                    .HasName("PK_ManufacturingParameters")
                    .IsClustered(false);

                entity.ToTable("MA_ManufacturingParameters");

                entity.Property(e => e.ManufacturingParametersId).ValueGeneratedNever();

                entity.Property(e => e.AllowEditInToconfirmimation)
                    .HasColumnName("AllowEditInTOConfirmimation")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllowModifyFpinMoconf)
                    .HasColumnName("AllowModifyFPInMOConf")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllowNotPostableInPrandMo)
                    .HasColumnName("AllowNotPostableInPRAndMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AskConfirmChildMo)
                    .HasColumnName("AskConfirmChildMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AskConfirmClosureRoutingStep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AskConfirmFirstStepOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AskConfirmMajorPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AskConfirmMinorPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AskConfirmPickingList)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AskConfirmRoutingStep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AskIntegratePl)
                    .HasColumnName("AskIntegratePL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AskReturnMaterial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AssignLotStorageOnPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BlockLotOnMoconfPicking)
                    .HasColumnName("BlockLotOnMOConfPicking")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BoLmandatory)
                    .HasColumnName("BoLMandatory")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CalculateCostScrap)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CalculateCostSecondRate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CalculateMocostUsingMochild)
                    .HasColumnName("CalculateMOCostUsingMOChild")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Calendar)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0000')");

                entity.Property(e => e.CanEditMostepDate)
                    .HasColumnName("CanEditMOStepDate")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CancelInHouseRmreseInvRsn)
                    .HasColumnName("CancelInHouseRMReseInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CancelOutsrcRmreseInvRsn)
                    .HasColumnName("CancelOutsrcRMReseInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CheckAssignedLot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CheckLotOnMoconfPicking)
                    .HasColumnName("CheckLotOnMOConfPicking")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ClearingInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfirmChildMo)
                    .HasColumnName("ConfirmChildMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ConfirmClosureRoutingStep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfirmRoutingStep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfirmSingleMo)
                    .HasColumnName("ConfirmSingleMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfirmStepWithPreviousQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CopyOnPrevStepsMoconfirmed)
                    .HasColumnName("CopyOnPrevStepsMOConfirmed")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CopyOnPreviousSteps)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DefaultExtScrapStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultExtSecondRateStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultExtSfstorage)
                    .HasColumnName("DefaultExtSFStorage")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultExtStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultScrapStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultSecondRateStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultSfstorage)
                    .HasColumnName("DefaultSFStorage")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DenyAutomaticMatReqPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DenyInteractMatReqPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DenyInteractToolReqPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DifferentSubcntrStorages)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DinstinctFixedCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableBoLgeneration)
                    .HasColumnName("DisableBoLGeneration")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableMaxProducibilityCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisablePickingListClosure)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisablePickingListGeneration)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableSubcntrOrdCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisplayQtyZeroLots)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.DnwithNetBeforePl)
                    .HasColumnName("DNWithNetBeforePL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DrawingAsItemAlias)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EditMocomponentsUnloadQty)
                    .HasColumnName("EditMOComponentsUnloadQty")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EditWaste)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EnableSelKanbanRtgSteps)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExtractOnlyRtgstepMatch)
                    .HasColumnName("ExtractOnlyRTGStepMatch")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ForecastRequireDay).HasDefaultValueSql("((1))");

                entity.Property(e => e.ForecastRequireWeekDay).HasDefaultValueSql("((1))");

                entity.Property(e => e.FurtherMoconfInSubcntrBoL)
                    .HasColumnName("FurtherMOConfInSubcntrBoL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.GroupMocomponents)
                    .HasColumnName("GroupMOComponents")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupTo)
                    .HasColumnName("GroupTO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Horizon).HasDefaultValueSql("((0))");

                entity.Property(e => e.HrzType).HasDefaultValueSql("((22806528))");

                entity.Property(e => e.InHouseFpreceiptInvRsn)
                    .HasColumnName("InHouseFPReceiptInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InHouseRmissueInvRsn)
                    .HasColumnName("InHouseRMIssueInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InHouseRmpickingInvRsn)
                    .HasColumnName("InHouseRMPickingInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InHouseRmreservInvRsn)
                    .HasColumnName("InHouseRMReservInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InHouseScrapInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InHouseSrloadInvRsn)
                    .HasColumnName("InHouseSRLoadInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InHouseStdSfreservInvRsn)
                    .HasColumnName("InHouseStdSFReservInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InHouseToOutsrcInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IntegratePl)
                    .HasColumnName("IntegratePL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IssueInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.JobTicketType).HasDefaultValueSql("((22937600))");

                entity.Property(e => e.LastStepMocomponentsCheck)
                    .HasColumnName("LastStepMOComponentsCheck")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LotGenMomentItemDefault)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LotGenerationMoment).HasDefaultValueSql("((25821186))");

                entity.Property(e => e.LotMandatoryInPl)
                    .HasColumnName("LotMandatoryInPL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LotOverbook)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.LotsAssignedByWms)
                    .HasColumnName("LotsAssignedByWMS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ManufacturingLifoFifo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MaxShiftNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.MoconfirmationsButtons)
                    .HasColumnName("MOConfirmationsButtons")
                    .HasDefaultValueSql("((511))");

                entity.Property(e => e.ModisplayForStatus)
                    .HasColumnName("MODisplayForStatus")
                    .HasDefaultValueSql("((20578308))");

                entity.Property(e => e.ModisplayForType)
                    .HasColumnName("MODisplayForType")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mrphorizon)
                    .HasColumnName("MRPHorizon")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MultipleLots)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NetByItemMaster)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

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

                entity.Property(e => e.NoConfirmedLabour)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoVariantOnLoad)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NumberOfAttempts).HasDefaultValueSql("((1))");

                entity.Property(e => e.OldModeStepTimeCalc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.OutsourceProcessingCostCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OutsrcFpreceiptInvRsn)
                    .HasColumnName("OutsrcFPReceiptInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsrcRmissueInvRsn)
                    .HasColumnName("OutsrcRMIssueInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsrcRmpickingInvRsn)
                    .HasColumnName("OutsrcRMPickingInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsrcRmreservInvRsn)
                    .HasColumnName("OutsrcRMReservInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsrcScrapInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsrcSrloadInvRsn)
                    .HasColumnName("OutsrcSRLoadInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsrcStdSfreservInvRsn)
                    .HasColumnName("OutsrcStdSFReservInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsrcToInHouseInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsrcToOutsrcInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OverIssue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PickAlsoMissingMocomponents)
                    .HasColumnName("PickAlsoMissingMOComponents")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PickComponentsCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PickMocomponents)
                    .HasColumnName("PickMOComponents")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PickProductionLotFromStorage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PickingFromPurch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PickingListCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PickingStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickingStorageSemifinished)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PlanningHorizon).HasDefaultValueSql("((0))");

                entity.Property(e => e.PlpickAlsoMissingMocomponent)
                    .HasColumnName("PLPickAlsoMissingMOComponent")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreparePickingList)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreparePickingLists)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrepareShopFloorPapers)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrepareSubcntDn)
                    .HasColumnName("PrepareSubcntDN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrepareSubcntOrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProcessingQtyTime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RecalculateActualCosts)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReturnMaterial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReturnedMaterialRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevInHouseFpreceiptInvRsn)
                    .HasColumnName("RevInHouseFPReceiptInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevInHouseRmissueInvRsn)
                    .HasColumnName("RevInHouseRMIssueInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevInHouseScrapInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevInHouseSrloadInvRsn)
                    .HasColumnName("RevInHouseSRLoadInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevInHouseToOutsrcInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevOutsrcFpreceiptInvRsn)
                    .HasColumnName("RevOutsrcFPReceiptInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevOutsrcRmissueInvRsn)
                    .HasColumnName("RevOutsrcRMIssueInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevOutsrcRmpickingInvRsn)
                    .HasColumnName("RevOutsrcRMPickingInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevOutsrcScrapInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevOutsrcSrloadInvRsn)
                    .HasColumnName("RevOutsrcSRLoadInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevOutsrcToInHouseInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevOutsrcToOutsrcInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevReturnedMaterialRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SearchInDefaultStorage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SearchInSupplierStorage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SearchOnlyInSubcntStorage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SecondRateInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SeparateOrderForMo)
                    .HasColumnName("SeparateOrderForMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SetDnstorages)
                    .HasColumnName("SetDNStorages")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SetProcessingQtyOnNextStep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SetProdPlanNoOnChildMo)
                    .HasColumnName("SetProdPlanNoOnChildMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SetStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ShowLeadTimeMsg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ShowOnlyItemSupplierInPr)
                    .HasColumnName("ShowOnlyItemSupplierInPR")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SimplifiedInventoryEntries)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SkipNotWorkingDays)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.StdLoadsAdjustmentInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StepsCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SubcntBoLrsn)
                    .HasColumnName("SubcntBoLRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubcntDnandOrd)
                    .HasColumnName("SubcntDNAndOrd")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SubcntDnbeginningText)
                    .HasColumnName("SubcntDNBeginningText")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubcntDnendingText)
                    .HasColumnName("SubcntDNEndingText")
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubcntDnrsn)
                    .HasColumnName("SubcntDNRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubcntOrdRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubcontractorStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierDocOptionalNote)
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

                entity.Property(e => e.ToolInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ToolIssueInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TotalTime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UnderIssue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UnloadIenegativeAdjInvRsn)
                    .HasColumnName("UnloadIENegativeAdjInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnloadIepositiveAdjInvRsn)
                    .HasColumnName("UnloadIEPositiveAdjInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UseAnticipationDays)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseCorrectionManagement)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseDnstoragesAndLots)
                    .HasColumnName("UseDNStoragesAndLots")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseExistingLotMo)
                    .HasColumnName("UseExistingLotMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseInspectionNoteStorage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseMochildAvailability)
                    .HasColumnName("UseMOChildAvailability")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseOrderReleaseDays)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseOriginalComponent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UseRtgStepDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UseRtgStepPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseStandardCostForSf)
                    .HasColumnName("UseStandardCostForSF")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseStepCosts)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ValueOnlyPartialSfreceipt)
                    .HasColumnName("ValueOnlyPartialSFReceipt")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WmscheckTransferRequests)
                    .HasColumnName("WMSCheckTransferRequests")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WmsloadingZone)
                    .HasColumnName("WMSLoadingZone")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WmsmanufacturingLink)
                    .HasColumnName("WMSManufacturingLink")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WmsmanufacturingLinkOnLoad)
                    .HasColumnName("WMSManufacturingLinkOnLoad")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Wmsrmpicking)
                    .HasColumnName("WMSRMPicking")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WmstoconfPickMovedQty)
                    .HasColumnName("WMSTOConfPickMovedQty")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.WmstrautomaticDevelopment)
                    .HasColumnName("WMSTRAutomaticDevelopment")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WmstrautomaticRun)
                    .HasColumnName("WMSTRAutomaticRun")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaMo>(entity =>
{
                entity.HasKey(e => e.Moid)
                    .HasName("PK_MO")
                    .IsClustered(false);

                entity.ToTable("MA_MO");

                entity.HasIndex(e => e.Simulation)
                    .HasName("IX_MA_MO_2");

                entity.HasIndex(e => new { e.Simulation, e.Mono })
                    .HasName("IX_MA_MO_1");

                entity.Property(e => e.Moid)
                    .HasColumnName("MOId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActualMaterialCostKanban).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualProcCostKanban).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualSetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualTimeKanban).HasDefaultValueSql("((0))");

                entity.Property(e => e.BarcodeSegment)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfirmationLevel)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostsCalculationLastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ecodate)
                    .HasColumnName("ECODate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Ecorevision)
                    .HasColumnName("ECORevision")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EndingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstimatedDuration).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstimatedMaterialCostKanban).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstimatedProcCostKanban).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstimatedProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstimatedSetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstimatedTimeKanban).HasDefaultValueSql("((0))");

                entity.Property(e => e.Feasibility).HasDefaultValueSql("((23396353))");

                entity.Property(e => e.FromExplosion)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupSf)
                    .HasColumnName("GroupSF")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InternalOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LabourActualCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.LabourBudgetCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaterialsActualCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaterialsBudgetCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.Mono)
                    .HasColumnName("MONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MoreadOnly)
                    .HasColumnName("MOReadOnly")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Mostatus)
                    .HasColumnName("MOStatus")
                    .HasDefaultValueSql("((20578308))");

                entity.Property(e => e.MrpconfirmationRank)
                    .HasColumnName("MRPConfirmationRank")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Position).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrintDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProcessingActualCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingBudgetCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductKind).HasDefaultValueSql("((22413314))");

                entity.Property(e => e.ProductionLotNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductionPlanId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionPlanLine).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProposedQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.RunDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SaleOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.SecondRateQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.SecondRateUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SetupActualCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupBudgetCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.SimEndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SimStartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SimulatedProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.SimulatedSetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.Simulation)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.StartingTime).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaMocomponents>(entity =>
{
                entity.HasKey(e => new { e.Moid, e.Line })
                    .HasName("PK_MOComponents")
                    .IsClustered(false);

                entity.ToTable("MA_MOComponents");

                entity.HasIndex(e => e.Component)
                    .HasName("IX_MA_MOComponents_6");

                entity.HasIndex(e => e.JobTicketNo)
                    .HasName("IX_MA_MOComponents_2");

                entity.HasIndex(e => e.PickingListNo)
                    .HasName("MA_MOComponents3");

                entity.HasIndex(e => e.Trid)
                    .HasName("IX_MA_MOComponents_7");

                entity.HasIndex(e => new { e.Moid, e.ReferredPosition, e.InitialPosition })
                    .HasName("IX_MA_MOComponents_4");

                entity.HasIndex(e => new { e.Simulation, e.Component, e.EstimatedUseDate })
                    .HasName("IX_MA_MOComponents_1");

                entity.HasIndex(e => new { e.Closed, e.Lot, e.Storage, e.SpecificatorType, e.Specificator })
                    .HasName("IX_MA_MOComponents_5");

                entity.Property(e => e.Moid).HasColumnName("MOId");

                entity.Property(e => e.ActualCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.AdjustmentQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.AssignedQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.AutomaticallyConfirmation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BoLid)
                    .HasColumnName("BoLId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BoLline)
                    .HasColumnName("BoLLine")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.Closed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeliveryNoteId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Dnquantity)
                    .HasColumnName("DNQuantity")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DnrtgStep)
                    .HasColumnName("DNRtgStep")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EndUseRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.EnteredQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstimatedUseDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FixedComponent)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FixedQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FromKanban)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InitialPosition).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsAoverPick)
                    .HasColumnName("IsAOverPick")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsAreplacement)
                    .HasColumnName("IsAReplacement")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsTool)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.JobTicketNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Location)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lot)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Mono)
                    .HasColumnName("MONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NeededQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.NotConfirm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NotEnter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NotRoundedPickedQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsourcedWc)
                    .HasColumnName("OutsourcedWC")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ParentBom)
                    .HasColumnName("ParentBOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParentVar)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PickedQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickingListDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PickingListNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Position).HasDefaultValueSql("((0))");

                entity.Property(e => e.PostedToInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReferredPosition).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReplacedComponent)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReplacedLot)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReplacedVariant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOrdPos).HasDefaultValueSql("((0))");

                entity.Property(e => e.Simulation)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorType).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.SplitPick)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TechnicalData)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Trid)
                    .HasColumnName("TRID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Valorize)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Waste)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.WasteUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Wc)
                    .HasColumnName("WC")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Mo)
                    .WithMany(p => p.MaMocomponents)
                    .HasForeignKey(d => d.Moid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MOComponen_MO_00");
            });
            modelBuilder.Entity<MaMocomponentsStepsQty>(entity =>
{
                entity.HasKey(e => new { e.Moid, e.MocomponentsLineNumber, e.RtgStep })
                    .HasName("PK_MOComponentsStepsQty")
                    .IsClustered(false);

                entity.ToTable("MA_MOComponentsStepsQty");

                entity.Property(e => e.Moid).HasColumnName("MOId");

                entity.Property(e => e.MocomponentsLineNumber).HasColumnName("MOComponentsLineNumber");

                entity.Property(e => e.EnteredQuantity).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.Mo)
                    .WithMany(p => p.MaMocomponentsStepsQty)
                    .HasForeignKey(d => new { d.Moid, d.MocomponentsLineNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MOComponen_MOComponen_00");
            });
            modelBuilder.Entity<MaMohierarchies>(entity =>
{
                entity.HasKey(e => new { e.Simulation, e.ParentMoid, e.ChildMoid, e.ChildPurchaseReqId, e.ChildPurchaseReqLineNumber })
                    .HasName("PK_MOHierarchies")
                    .IsClustered(false);

                entity.ToTable("MA_MOHierarchies");

                entity.HasIndex(e => new { e.Simulation, e.ParentMoid, e.ChildMoid })
                    .HasName("IX_MA_MOHierarchies_1");

                entity.HasIndex(e => new { e.Simulation, e.ParentMo, e.ChildPurchaseReqId, e.ChildPurchaseReqLineNumber })
                    .HasName("IX_MA_MOHierarchies_3");

                entity.HasIndex(e => new { e.Simulation, e.ParentMoid, e.ChildPurchaseReqId, e.ChildPurchaseReqLineNumber })
                    .HasName("IX_MA_MOHierarchies_2");

                entity.Property(e => e.Simulation)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ParentMoid).HasColumnName("ParentMOId");

                entity.Property(e => e.ChildMoid).HasColumnName("ChildMOId");

                entity.Property(e => e.ChildMo)
                    .HasColumnName("ChildMO")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsAmo)
                    .HasColumnName("IsAMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsApo)
                    .HasColumnName("IsAPO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ParentMo)
                    .HasColumnName("ParentMO")
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
            modelBuilder.Entity<MaMolabour>(entity =>
{
                entity.HasKey(e => new { e.Moid, e.SubId, e.Line })
                    .HasName("PK_MOLabour")
                    .IsClustered(false);

                entity.ToTable("MA_MOLabour");

                entity.Property(e => e.Moid).HasColumnName("MOId");

                entity.Property(e => e.Line).ValueGeneratedOnAdd();

                entity.Property(e => e.AltRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AttendancePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsEvaluated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LabourDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LabourType).HasDefaultValueSql("((28508160))");

                entity.Property(e => e.NoOfResources).HasDefaultValueSql("((0))");

                entity.Property(e => e.Phase).HasDefaultValueSql("((28573696))");

                entity.Property(e => e.ResourceCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ResourceType).HasDefaultValueSql("((27131908))");

                entity.Property(e => e.RtgStep).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.WorkerId)
                    .HasColumnName("WorkerID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WorkingTime).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaMosteps>(entity =>
{
                entity.HasKey(e => new { e.Moid, e.RtgStep, e.Alternate, e.AltRtgStep })
                    .HasName("PK_MOSteps")
                    .IsClustered(false);

                entity.ToTable("MA_MOSteps");

                entity.HasIndex(e => e.JobTicketNo)
                    .HasName("IX_MA_MOSteps_1");

                entity.HasIndex(e => new { e.Mono, e.RtgStep, e.Alternate, e.AltRtgStep })
                    .HasName("IX_MA_MOSteps_2");

                entity.Property(e => e.Moid).HasColumnName("MOId");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ActualProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualSetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualWc)
                    .HasColumnName("ActualWC")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdditionalCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.AdditionalRtgStep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DataFromOperation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Dnquantity)
                    .HasColumnName("DNQuantity")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EndingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstimatedProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstimatedQueueTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstimatedSetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.EstimatedWc)
                    .HasColumnName("EstimatedWC")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HourlyCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.HourlySetUpCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsWc)
                    .HasColumnName("IsWC")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.IssuedToProductionQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.JobTicketId).HasDefaultValueSql("((0))");

                entity.Property(e => e.JobTicketLineNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.JobTicketNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.JtprintDate)
                    .HasColumnName("JTPrintDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LabourActualCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.LabourBudgetCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.LineTypeInDn)
                    .HasColumnName("LineTypeInDN")
                    .HasDefaultValueSql("((24576000))");

                entity.Property(e => e.Location)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LotsCounter).HasDefaultValueSql("((0))");

                entity.Property(e => e.Mono)
                    .HasColumnName("MONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Mostatus)
                    .HasColumnName("MOStatus")
                    .HasDefaultValueSql("((25427968))");

                entity.Property(e => e.NoDngeneration)
                    .HasColumnName("NoDNGeneration")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NotProcessedQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Operation)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Outsourced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PartialReceiptToEnd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostedToInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreviousStepQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrintedJobTicket)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProcessActualTeamElem).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessEstimatedLabourTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessEstimatedStaffingPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessEstimatedTeam)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProcessEstimatedTeamMember).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingActualCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingActualLabourTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingActualTeam)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProcessingBudgetCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionRunNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.QueueTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnedMaterialQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Scrap)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapLocation)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ScrapVariant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SecondRate)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SecondRateLocation)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SecondRateQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.SecondRateStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SecondRateUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SecondRateVariant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SetupActualCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupActualLabourTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupActualTeam)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SetupActualTeamElem).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupBudgetCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupEstimatedLabourTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupEstimatedStaffingPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupEstimatedTeam)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SetupEstimatedTeamMember).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShiftNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.SimEndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SimStartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Simulation)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.StartingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.StepDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.StepQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.StepRunDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubcontractorOrderQuantity).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalTime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UnitCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Wc)
                    .HasColumnName("WC")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Mo)
                    .WithMany(p => p.MaMosteps)
                    .HasForeignKey(d => d.Moid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MOSteps_MO_00");
            });
            modelBuilder.Entity<MaMostepsDetailedQty>(entity =>
{
                entity.HasKey(e => new { e.Moid, e.RtgStep, e.Alternate, e.AltRtgStep, e.Line })
                    .HasName("PK_MOStepsDetailedQty")
                    .IsClustered(false);

                entity.ToTable("MA_MOStepsDetailedQty");

                entity.Property(e => e.Moid).HasColumnName("MOId");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ActualProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualSetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.AutomaticallyConfirmation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BoL)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BoLid)
                    .HasColumnName("BoLId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BoLline)
                    .HasColumnName("BoLLine")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IssuedQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemType).HasDefaultValueSql("((24641536))");

                entity.Property(e => e.Position).HasDefaultValueSql("((0))");

                entity.Property(e => e.PostedToInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PreprintedDocNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProcessingType).HasDefaultValueSql("((24707072))");

                entity.Property(e => e.ProducedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchaseOrdId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ShiftNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorType).HasDefaultValueSql("((6750211))");

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

                entity.Property(e => e.ToBeCosted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.MaMosteps)
                    .WithMany(p => p.MaMostepsDetailedQty)
                    .HasForeignKey(d => new { d.Moid, d.RtgStep, d.Alternate, d.AltRtgStep })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MOStepsDet_MOSteps_00");
            });
            modelBuilder.Entity<MaMostepsKanban>(entity =>
{
                entity.HasKey(e => new { e.Moid, e.RtgStep, e.Alternate, e.AltRtgStep, e.ProgRow })
                    .HasName("PK_MOStepsKanban")
                    .IsClustered(false);

                entity.ToTable("MA_MOStepsKanban");

                entity.Property(e => e.Moid).HasColumnName("MOId");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Enabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InHouseProcCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsOutsourced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsTotalTime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Mono)
                    .HasColumnName("MONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Operation)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsourcedProcCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentBom)
                    .HasColumnName("ParentBOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParentVar)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.Simulation)
                    .HasMaxLength(15)
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

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Wc)
                    .HasColumnName("WC")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaPickings>(entity =>
{
                entity.HasKey(e => e.PickingListNo)
                    .HasName("PK_Pickings")
                    .IsClustered(false);

                entity.ToTable("MA_Pickings");

                entity.Property(e => e.PickingListNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

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
            modelBuilder.Entity<MaTmpMoexplosion>(entity =>
{
                entity.HasKey(e => new { e.UserName, e.Computer, e.Document, e.Line })
                    .HasName("PK_TmpMOExplosion")
                    .IsClustered(false);

                entity.ToTable("MA_TmpMOExplosion");

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Computer)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Document)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AltRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bomlevel)
                    .HasColumnName("BOMLevel")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Error)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Incidence).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsArtgStep)
                    .HasColumnName("IsARtgStep")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsAsubcontractingDoc)
                    .HasColumnName("IsASubcontractingDoc")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LineNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.Mo)
                    .HasColumnName("MO")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Moid)
                    .HasColumnName("MOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Moparent)
                    .HasColumnName("MOParent")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Moroot)
                    .HasColumnName("MORoot")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParentMoid)
                    .HasColumnName("ParentMOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0))");

                entity.Property(e => e.RootMoid)
                    .HasColumnName("RootMOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOrdPos).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubcontractingDocId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubcontractingDocType).HasDefaultValueSql("((25427973))");

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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaTmpMoimplosion>(entity =>
{
                entity.HasKey(e => new { e.UserName, e.Computer, e.Document, e.Line })
                    .HasName("PK_TmpMOImplosion")
                    .IsClustered(false);

                entity.ToTable("MA_TmpMOImplosion");

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Computer)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Document)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.AbsorbedQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bom)
                    .HasColumnName("BOM")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Bomlevel)
                    .HasColumnName("BOMLevel")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Error)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LineNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.Mo)
                    .HasColumnName("MO")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Moid)
                    .HasColumnName("MOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.RequiredQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOrdPos).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UsedQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaTmpPapersPrint>(entity =>
{
                entity.HasKey(e => new { e.SessionGuid, e.Document, e.Line })
                    .HasName("PK_TmpPapersPrint")
                    .IsClustered(false);

                entity.ToTable("MA_TmpPapersPrint");

                entity.HasIndex(e => new { e.DocumentType, e.DocumentId })
                    .HasName("IX_MA_TmpPapersPrint_1");

                entity.HasIndex(e => new { e.DocumentType, e.DocumentNumber })
                    .HasName("IX_MA_TmpPapersPrint_2");

                entity.Property(e => e.Document)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaTmpProducibilityAnalysis>(entity =>
{
                entity.HasKey(e => new { e.UserName, e.Computer, e.Component, e.Variant, e.DeliveryDate, e.Moid, e.Line })
                    .HasName("PK_TmpProducibilityAnalysis")
                    .IsClustered(false);

                entity.ToTable("MA_TmpProducibilityAnalysis");

                entity.Property(e => e.UserName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Computer)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.Moid).HasColumnName("MOId");

                entity.Property(e => e.Mono)
                    .HasColumnName("MONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NeededQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickedQuantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickingListNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorType).HasDefaultValueSql("((6750211))");

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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
        }
    }
}
