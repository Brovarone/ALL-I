using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class CRPDbContext : DbContext
    {
        public CRPDbContext()
        {
        }
        public CRPDbContext(DbContextOptions<CRPDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaCrpsimulations> MaCrpsimulations { get; set; }
        public virtual DbSet<MaLoadingDetailSim> MaLoadingDetailSim { get; set; }
        public virtual DbSet<MaPlanTeamsSim> MaPlanTeamsSim { get; set; }
        public virtual DbSet<MaWchoursSim> MaWchoursSim { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaCrpsimulations>(entity =>
{
                entity.HasKey(e => e.Simulation)
                    .HasName("PK_CRPSimulations")
                    .IsClustered(false);

                entity.ToTable("MA_CRPSimulations");

                entity.Property(e => e.Simulation)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.AltRoutingCriteria).HasDefaultValueSql("((24838144))");

                entity.Property(e => e.AltRtgStep)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AltRtgStepCriteria).HasDefaultValueSql("((21757952))");

                entity.Property(e => e.CustomAltStep)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EarlinessTardiness).HasDefaultValueSql("((23199744))");

                entity.Property(e => e.EntryValueType).HasDefaultValueSql("((22347776))");

                entity.Property(e => e.FromDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.GetDurationsFromMo)
                    .HasColumnName("GetDurationsFromMO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Horizon).HasDefaultValueSql("((0))");

                entity.Property(e => e.IncludeSaleOrd)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MachineDetail)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Materials)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MaterialsReservation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Mrpsimulation)
                    .HasColumnName("MRPSimulation")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(254)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParentEarliness)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreferredRouting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.QueueHours).HasDefaultValueSql("((0))");

                entity.Property(e => e.QueueTimeOrigin).HasDefaultValueSql("((21233664))");

                entity.Property(e => e.RunDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Signature)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SimulationType).HasDefaultValueSql("((23658496))");

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

                entity.Property(e => e.TeamLoad)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ToolingLoad)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseCapacity).HasDefaultValueSql("((21102592))");

                entity.Property(e => e.UseHierarchy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseOverflow)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseWaitTime).HasDefaultValueSql("((21168128))");

                entity.Property(e => e.VersionSelect)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WaitHours).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaLoadingDetailSim>(entity =>
{
                entity.HasKey(e => new { e.Simulation, e.Wc, e.LoadDate, e.Line })
                    .HasName("PK_LoadingDetailSim")
                    .IsClustered(false);

                entity.ToTable("MA_LoadingDetailSim");

                entity.Property(e => e.Simulation)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Wc)
                    .HasColumnName("WC")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.LoadDate).HasColumnType("datetime");

                entity.Property(e => e.AltRtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DayPos).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoadHours).HasDefaultValueSql("((0))");

                entity.Property(e => e.Moid)
                    .HasColumnName("MOId")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Mono)
                    .HasColumnName("MONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MonthPos).HasDefaultValueSql("((0))");

                entity.Property(e => e.RtgStep).HasDefaultValueSql("((0))");

                entity.Property(e => e.Setup)
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
            });
            modelBuilder.Entity<MaPlanTeamsSim>(entity =>
{
                entity.HasKey(e => new { e.Simulation, e.Team, e.OrderNo, e.RtgStep, e.Alternate, e.AltRtgStep })
                    .HasName("PK_PlanTeamsSim")
                    .IsClustered(false);

                entity.ToTable("MA_PlanTeamsSim");

                entity.Property(e => e.Simulation)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Team)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Alternate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessingTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.SimEndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SimStartDate)
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

                entity.Property(e => e.WorkersNo).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaWchoursSim>(entity =>
{
                entity.HasKey(e => new { e.Wc, e.Simulation, e.BalanceMonth, e.BalanceYear })
                    .HasName("PK_WCHoursSim")
                    .IsClustered(false);

                entity.ToTable("MA_WCHoursSim");

                entity.Property(e => e.Wc)
                    .HasColumnName("WC")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Simulation)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Day10Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day10Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day10Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day11Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day11Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day11Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day12Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day12Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day12Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day13Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day13Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day13Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day14Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day14Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day14Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day15Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day15Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day15Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day16Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day16Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day16Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day17Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day17Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day17Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day18Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day18Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day18Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day19Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day19Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day19Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day1Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day1Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day1Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day20Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day20Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day20Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day21Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day21Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day21Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day22Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day22Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day22Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day23Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day23Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day23Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day24Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day24Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day24Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day25Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day25Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day25Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day26Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day26Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day26Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day27Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day27Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day27Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day28Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day28Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day28Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day29Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day29Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day29Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day2Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day2Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day2Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day30Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day30Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day30Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day31Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day31Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day31Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day3Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day3Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day3Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day4Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day4Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day4Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day5Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day5Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day5Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day6Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day6Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day6Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day7Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day7Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day7Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day8Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day8Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day8Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day9Capacity).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day9Load).HasDefaultValueSql("((0))");

                entity.Property(e => e.Day9Setup).HasDefaultValueSql("((0))");

                entity.Property(e => e.FirstDay)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastDay)
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
        }
    }
}
