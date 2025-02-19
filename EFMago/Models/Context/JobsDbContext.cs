using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class JobsDbContext : DbContext
    {
        public JobsDbContext()
        {
        }
        public JobsDbContext(DbContextOptions<JobsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaJobGroups> MaJobGroups { get; set; }
        public virtual DbSet<MaJobs> MaJobs { get; set; }
        public virtual DbSet<MaJobsBalances> MaJobsBalances { get; set; }
        public virtual DbSet<MaJobsParameters> MaJobsParameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaJobGroups>(entity =>
{
                entity.HasKey(e => e.GroupCode)
                    .HasName("PK_JobGroups")
                    .IsClustered(false);

                entity.ToTable("MA_JobGroups");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_JobGroups2");

                entity.Property(e => e.GroupCode)
                    .HasMaxLength(10)
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
            modelBuilder.Entity<MaJobs>(entity =>
{
                entity.HasKey(e => e.Job)
                    .HasName("PK_Jobs")
                    .IsClustered(false);

                entity.ToTable("MA_Jobs");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_Jobs2");

                entity.HasIndex(e => new { e.GroupCode, e.Job })
                    .HasName("MA_Jobs3");

                entity.HasIndex(e => new { e.Customer, e.DeliveryDate, e.Job })
                    .HasName("MA_Jobs4");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Collected).HasDefaultValueSql("((0))");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Contract)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContractCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.DepreciationPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EijobCode)
                    .HasColumnName("EIJobCode")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExpectedCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ExpectedStartingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.GroupCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImCrrefId).HasColumnName("IM_CRRefID");

                entity.Property(e => e.ImCrrefType)
                    .HasColumnName("IM_CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.ImJobId).HasColumnName("IM_JobId");

                entity.Property(e => e.ImJobStatus)
                    .HasColumnName("IM_JobStatus")
                    .HasDefaultValueSql("((19595264))");

                entity.Property(e => e.ImJobSubStatus)
                    .HasColumnName("IM_JobSubStatus")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Inhouse)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.JobType).HasDefaultValueSql("((25034752))");

                entity.Property(e => e.MachineHours).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ParentJob)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartingDate)
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
            modelBuilder.Entity<MaJobsBalances>(entity =>
{
                entity.HasKey(e => new { e.Job, e.Account, e.FiscalYear, e.BalanceYear, e.BalanceType, e.BalanceMonth })
                    .HasName("PK_JobsBalances")
                    .IsClustered(false);

                entity.ToTable("MA_JobsBalances");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.ActualCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualCreditQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualDebit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualDebitQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetCreditQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetDebit).HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetDebitQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastCreditQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastDebit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastDebitQty).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.JobNavigation)
                    .WithMany(p => p.MaJobsBalances)
                    .HasForeignKey(d => d.Job)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobsBalanc_Jobs_00");
            });
            modelBuilder.Entity<MaJobsParameters>(entity =>
{
                entity.HasKey(e => e.JobsParametersId)
                    .HasName("PK_JobsParameters")
                    .IsClustered(false);

                entity.ToTable("MA_JobsParameters");

                entity.Property(e => e.JobsParametersId).ValueGeneratedNever();

                entity.Property(e => e.ConsiderJobsNotAssigned)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FilterJobsByCustomer)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.JobAutonumbering)
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
        }
    }
}
