using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class SalesPeopleDbContext : DbContext
    {
        public SalesPeopleDbContext()
        {
        }
        public SalesPeopleDbContext(DbContextOptions<SalesPeopleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaAreas> MaAreas { get; set; }
        public virtual DbSet<MaCommissionCtg> MaCommissionCtg { get; set; }
        public virtual DbSet<MaCommissionEntries> MaCommissionEntries { get; set; }
        public virtual DbSet<MaCommissionEntriesDetail> MaCommissionEntriesDetail { get; set; }
        public virtual DbSet<MaCommissionPolicies> MaCommissionPolicies { get; set; }
        public virtual DbSet<MaCommissionPoliciesDetail> MaCommissionPoliciesDetail { get; set; }
        public virtual DbSet<MaEnasarcoparameters> MaEnasarcoparameters { get; set; }
        public virtual DbSet<MaSalesPeople> MaSalesPeople { get; set; }
        public virtual DbSet<MaSalesPeopleAllowance> MaSalesPeopleAllowance { get; set; }
        public virtual DbSet<MaSalesPeopleBalanceFirr> MaSalesPeopleBalanceFirr { get; set; }
        public virtual DbSet<MaSalesPeopleBalances> MaSalesPeopleBalances { get; set; }
        public virtual DbSet<MaSalesPeopleParameters> MaSalesPeopleParameters { get; set; }
        public virtual DbSet<MaSalesPeoplePartners> MaSalesPeoplePartners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaAreas>(entity =>
{
                entity.HasKey(e => e.Area)
                    .HasName("PK_Areas")
                    .IsClustered(false);

                entity.ToTable("MA_Areas");

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AreaManager)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
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
            modelBuilder.Entity<MaCommissionCtg>(entity =>
{
                entity.HasKey(e => e.Category)
                    .HasName("PK_CommissionCtg")
                    .IsClustered(false);

                entity.ToTable("MA_CommissionCtg");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_CommissionCtg2");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
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
            modelBuilder.Entity<MaCommissionEntries>(entity =>
{
                entity.HasKey(e => e.EntryId)
                    .HasName("PK_CommissionEntries")
                    .IsClustered(false);

                entity.ToTable("MA_CommissionEntries");

                entity.HasIndex(e => new { e.DocumentDate, e.EntryId })
                    .HasName("IX_MA_CommissionEntries_5");

                entity.HasIndex(e => new { e.Salesperson, e.Customer })
                    .HasName("IX_MA_CommissionEntries_2");

                entity.HasIndex(e => new { e.DocumentDate, e.Salesperson, e.Customer })
                    .HasName("IX_MA_CommissionEntries_4");

                entity.HasIndex(e => new { e.Salesperson, e.Area, e.Customer })
                    .HasName("IX_MA_CommissionEntries_1");

                entity.HasIndex(e => new { e.DocumentDate, e.Salesperson, e.Area, e.Customer })
                    .HasName("IX_MA_CommissionEntries_3");

                entity.Property(e => e.EntryId).ValueGeneratedNever();

                entity.Property(e => e.AccrualPercAtInvoiceDate).HasDefaultValueSql("((0))");

                entity.Property(e => e.AccrualType).HasDefaultValueSql("((3473408))");

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParentEntryId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Policy)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PymtSchedId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaCommissionEntriesDetail>(entity =>
{
                entity.HasKey(e => new { e.EntryId, e.Line })
                    .HasName("PK_CommissionEntriesDetail")
                    .IsClustered(false);

                entity.ToTable("MA_CommissionEntriesDetail");

                entity.HasIndex(e => new { e.EntryId, e.InstallmentNo })
                    .HasName("IX_MA_CommissionEntriesDet_3");

                entity.HasIndex(e => new { e.Salesperson, e.ActualAccrualDate })
                    .HasName("IX_MA_CommissionEntriesDet_1");

                entity.HasIndex(e => new { e.ActualAccrualDate, e.Salesperson, e.Authorized, e.Invoiced })
                    .HasName("IX_MA_CommissionEntriesDet_2");

                entity.Property(e => e.ActualAccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Authorized)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Base).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cancel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Comm).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreditNoteDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExpectedAccrualDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.GenByOutstanding)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InstallmentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InstallmentNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Invoiced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Outstanding)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OutstandingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Suspended)
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

                entity.HasOne(d => d.Entry)
                    .WithMany(p => p.MaCommissionEntriesDetail)
                    .HasForeignKey(d => d.EntryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Commission_Commission_00");
            });
            modelBuilder.Entity<MaCommissionPolicies>(entity =>
{
                entity.HasKey(e => e.Policy)
                    .HasName("PK_CommissionPolicies")
                    .IsClustered(false);

                entity.ToTable("MA_CommissionPolicies");

                entity.Property(e => e.Policy)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.AccrualPercAtInvoiceDate).HasDefaultValueSql("((0))");

                entity.Property(e => e.AccrualType).HasDefaultValueSql("((3473408))");

                entity.Property(e => e.CommissionFormula)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CommissionOnLines)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CommissionType).HasDefaultValueSql("((2555904))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiscountsDetail)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FinalDiscountIncluded)
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
            modelBuilder.Entity<MaCommissionPoliciesDetail>(entity =>
{
                entity.HasKey(e => new { e.Policy, e.Line })
                    .HasName("PK_CommissionPoliciesDetail")
                    .IsClustered(false);

                entity.ToTable("MA_CommissionPoliciesDetail");

                entity.Property(e => e.Policy)
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.AllCodes)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AreaManagerCommPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.CommissionType).HasDefaultValueSql("((2555904))");

                entity.Property(e => e.CrossingCode)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrossingCode2)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrossingCodeType).HasDefaultValueSql("((11206656))");

                entity.Property(e => e.CrossingCodeType2).HasDefaultValueSql("((11206656))");

                entity.Property(e => e.CrossingValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FinalDiscountIncluded)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PolicyCommType).HasDefaultValueSql("((11141120))");

                entity.Property(e => e.SalespersonCommPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.StartingFrom)
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

                entity.HasOne(d => d.PolicyNavigation)
                    .WithMany(p => p.MaCommissionPoliciesDetail)
                    .HasForeignKey(d => d.Policy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Commission_Commission_01");
            });
            modelBuilder.Entity<MaEnasarcoparameters>(entity =>
{
                entity.HasKey(e => e.Line)
                    .HasName("PK_ENASARCOParameters")
                    .IsClustered(false);

                entity.ToTable("MA_ENASARCOParameters");

                entity.Property(e => e.Line).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Perc).HasDefaultValueSql("((0))");

                entity.Property(e => e.PercSalePerson).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.ToAmount).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaSalesPeople>(entity =>
{
                entity.HasKey(e => e.Salesperson)
                    .HasName("PK_SalesPeople")
                    .IsClustered(false);

                entity.ToTable("MA_SalesPeople");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AgencyChangeDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.AreaManager)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BaseAreaMngCommission).HasDefaultValueSql("((0))");

                entity.Property(e => e.BaseCommission).HasDefaultValueSql("((0))");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Enasarco)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiringDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.HiringDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.IsAcompany)
                    .HasColumnName("IsACompany")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsAcorporation)
                    .HasColumnName("IsACorporation")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsAnAreaManager)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsAnEmployee)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MonthlyFixedAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NoCommissionEdit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OneFirmOnly)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Policy)
                    .HasMaxLength(9)
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

                entity.Property(e => e.Tbguid)
                    .HasColumnName("TBGuid")
                    .HasDefaultValueSql("(0x00)");

                entity.Property(e => e.Tbmodified)
                    .HasColumnName("TBModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TbmodifiedId).HasColumnName("TBModifiedID");
            });
            modelBuilder.Entity<MaSalesPeopleAllowance>(entity =>
{
                entity.HasKey(e => new { e.Salesperson, e.BalanceYear, e.IsManual })
                    .HasName("PK_SalesPeopleAllowance")
                    .IsClustered(false);

                entity.ToTable("MA_SalesPeopleAllowance");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Accrued).HasDefaultValueSql("((0))");

                entity.Property(e => e.Base).HasDefaultValueSql("((0))");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentDate)
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

                entity.HasOne(d => d.SalespersonNavigation)
                    .WithMany(p => p.MaSalesPeopleAllowance)
                    .HasForeignKey(d => d.Salesperson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesPeopl_SalesPeopl_03");
            });
            modelBuilder.Entity<MaSalesPeopleBalanceFirr>(entity =>
{
                entity.HasKey(e => new { e.Salesperson, e.BalanceYear, e.CodeType, e.IsManual })
                    .HasName("PK_SalesPeopleBalanceFIRR")
                    .IsClustered(false);

                entity.ToTable("MA_SalesPeopleBalanceFIRR");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AccruedAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.Base).HasDefaultValueSql("((0))");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentDate)
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

                entity.HasOne(d => d.SalespersonNavigation)
                    .WithMany(p => p.MaSalesPeopleBalanceFirr)
                    .HasForeignKey(d => d.Salesperson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesPeopl_SalesPeopl_02");
            });
            modelBuilder.Entity<MaSalesPeopleBalances>(entity =>
{
                entity.HasKey(e => new { e.Salesperson, e.BalanceYear, e.BalanceMonth })
                    .HasName("PK_SalesPeopleBalances")
                    .IsClustered(false);

                entity.ToTable("MA_SalesPeopleBalances");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AccruedCommission).HasDefaultValueSql("((0))");

                entity.Property(e => e.AcquiredCommission).HasDefaultValueSql("((0))");

                entity.Property(e => e.Budget).HasDefaultValueSql("((0))");

                entity.Property(e => e.Enasarcopayed)
                    .HasColumnName("ENASARCOPayed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcopayedAss)
                    .HasColumnName("ENASARCOPayedAss")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcopaymentDate)
                    .HasColumnName("ENASARCOPaymentDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.EnasarcotaxableAmount)
                    .HasColumnName("ENASARCOTaxableAmount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcotoPay)
                    .HasColumnName("ENASARCOToPay")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcotoPayAss)
                    .HasColumnName("ENASARCOToPayAss")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcotoPayAssSalesperson)
                    .HasColumnName("ENASARCOToPayAssSalesperson")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcotoPayGrossAmount)
                    .HasColumnName("ENASARCOToPayGrossAmount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcotoPaySalesperson)
                    .HasColumnName("ENASARCOToPaySalesperson")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OneFirmOnly)
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

                entity.Property(e => e.Turnover).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.SalespersonNavigation)
                    .WithMany(p => p.MaSalesPeopleBalances)
                    .HasForeignKey(d => d.Salesperson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesPeopl_SalesPeopl_00");
            });
            modelBuilder.Entity<MaSalesPeopleParameters>(entity =>
{
                entity.HasKey(e => e.SalesPeopleParametersId)
                    .HasName("PK_SalesPeopleParameters")
                    .IsClustered(false);

                entity.ToTable("MA_SalesPeopleParameters");

                entity.Property(e => e.SalesPeopleParametersId).ValueGeneratedNever();

                entity.Property(e => e.AcceptNegativeComm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllowancePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.AreaManagerManagement).HasDefaultValueSql("((5570560))");

                entity.Property(e => e.BracketSkipCurrentDoc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CommAmountIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CommPercIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DiscountsDetail)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EnasarcomultiFirmMax)
                    .HasColumnName("ENASARCOMultiFirmMax")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcomultiFirmMin)
                    .HasColumnName("ENASARCOMultiFirmMin")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcooneFirmMax)
                    .HasColumnName("ENASARCOOneFirmMax")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcooneFirmMin)
                    .HasColumnName("ENASARCOOneFirmMin")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Enasarcoperc)
                    .HasColumnName("ENASARCOPerc")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcopercCompany)
                    .HasColumnName("ENASARCOPercCompany")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcopercSalesPerson)
                    .HasColumnName("ENASARCOPercSalesPerson")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EnasarcouponAcquiredComm)
                    .HasColumnName("ENASARCOUponAcquiredComm")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EnasarcouponSalespersons)
                    .HasColumnName("ENASARCOUponSalespersons")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SalespersTurnNetDiscount)
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

                entity.Property(e => e.WarnIfNoSalesperson)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WarnIfZeroComm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaSalesPeoplePartners>(entity =>
{
                entity.HasKey(e => new { e.Salesperson, e.IdNumber })
                    .HasName("PK_SalesPeoplePartners")
                    .IsClustered(false);

                entity.ToTable("MA_SalesPeoplePartners");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.FiscalCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Quota).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.SalespersonNavigation)
                    .WithMany(p => p.MaSalesPeoplePartners)
                    .HasForeignKey(d => d.Salesperson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalesPeopl_SalesPeopl_01");
            });
        }
    }
}
