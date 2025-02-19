using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class IBConnectorDbContext : DbContext
    {
        public IBConnectorDbContext()
        {
        }
        public IBConnectorDbContext(DbContextOptions<IBConnectorDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaIbcagingPeriods> MaIbcagingPeriods { get; set; }
        public virtual DbSet<MaIbcconfigurations> MaIbcconfigurations { get; set; }
        public virtual DbSet<MaIbcdocuments> MaIbcdocuments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaIbcagingPeriods>(entity =>
{
                entity.HasKey(e => new { e.Configuration, e.CustSuppType, e.AgingPeriodsType, e.Line })
                    .HasName("PK_IBCAgingPeriods")
                    .IsClustered(false);

                entity.ToTable("MA_IBCAgingPeriods");

                entity.Property(e => e.Configuration)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AgingPeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.AgingPeriodDescription)
                    .HasMaxLength(128)
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
            modelBuilder.Entity<MaIbcconfigurations>(entity =>
{
                entity.HasKey(e => e.Configuration)
                    .HasName("PK_IBCConfigurations")
                    .IsClustered(false);

                entity.ToTable("MA_IBCConfigurations");

                entity.Property(e => e.Configuration)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Accounting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostAccounting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DateType).HasDefaultValueSql("((3997696))");

                entity.Property(e => e.Days).HasDefaultValueSql("((0))");

                entity.Property(e => e.DeliveryNotes)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Inventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InventoryAnalysis)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Invoices)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Masters)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Orders)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PaymentSchedule)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Quotations)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.StartDate)
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
            });
            modelBuilder.Entity<MaIbcdocuments>(entity =>
{
                entity.HasKey(e => new { e.Configuration, e.DocumentType })
                    .HasName("PK_IBCDocuments")
                    .IsClustered(false);

                entity.ToTable("MA_IBCDocuments");

                entity.Property(e => e.Configuration)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CommissionSign).HasDefaultValueSql("((0))");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostSign).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentClass).HasDefaultValueSql("((4063232))");

                entity.Property(e => e.DocumentCycle).HasDefaultValueSql("((4128768))");

                entity.Property(e => e.PurchasesDocumentType).HasDefaultValueSql("((9830400))");

                entity.Property(e => e.QuantitySign).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesDocumentType).HasDefaultValueSql("((3407873))");

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

                entity.Property(e => e.ValueSign).HasDefaultValueSql("((0))");
            });
        }
    }
}
