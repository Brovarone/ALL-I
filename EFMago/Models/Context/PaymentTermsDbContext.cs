using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class PaymentTermsDbContext : DbContext
    {
        public PaymentTermsDbContext()
        {
        }
        public PaymentTermsDbContext(DbContextOptions<PaymentTermsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaCreditCards> MaCreditCards { get; set; }
        public virtual DbSet<MaPaymentTerms> MaPaymentTerms { get; set; }
        public virtual DbSet<MaPaymentTermsPercInstall> MaPaymentTermsPercInstall { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaCreditCards>(entity =>
{
                entity.HasKey(e => e.CreditCard)
                    .HasName("PK_CreditCards")
                    .IsClustered(false);

                entity.ToTable("MA_CreditCards");

                entity.Property(e => e.CreditCard)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Offset)
                    .HasMaxLength(16)
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
            modelBuilder.Entity<MaPaymentTerms>(entity =>
{
                entity.HasKey(e => e.Payment)
                    .HasName("PK_PaymentTerms")
                    .IsClustered(false);

                entity.ToTable("MA_PaymentTerms");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_PaymentTerms2");

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Acgcode)
                    .HasColumnName("ACGCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AtSight)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BusinessYear)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CollectionCharges).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreditCard)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DaysBetweenInstallments).HasDefaultValueSql("((0))");

                entity.Property(e => e.DeferredDayMonth1).HasDefaultValueSql("((0))");

                entity.Property(e => e.DeferredDayMonth1Same)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeferredDayMonth2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DeferredDayMonth2Same)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DueDateType).HasDefaultValueSql("((2949121))");

                entity.Property(e => e.ExcludedMonth1).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExcludedMonth2).HasDefaultValueSql("((0))");

                entity.Property(e => e.FirstPaymentDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.FixedDay).HasDefaultValueSql("((0))");

                entity.Property(e => e.FixedDayRounding).HasDefaultValueSql("((2818050))");

                entity.Property(e => e.InstallmentType).HasDefaultValueSql("((2686977))");

                entity.Property(e => e.IntrastatCollectionType).HasDefaultValueSql("((655360))");

                entity.Property(e => e.NoOfInstallments).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Offset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PercInstallment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PymtCash)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SettingsOnPercInstallment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Spacode)
                    .HasColumnName("SPACode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxInstallment).HasDefaultValueSql("((2752515))");

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

                entity.Property(e => e.WorkingDays)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaPaymentTermsPercInstall>(entity =>
{
                entity.HasKey(e => new { e.Payment, e.InstallmentNo })
                    .HasName("PK_PaymentTermsPercInstall")
                    .IsClustered(false);

                entity.ToTable("MA_PaymentTermsPercInstall");

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Days).HasDefaultValueSql("((0))");

                entity.Property(e => e.DueDateType).HasDefaultValueSql("((2949121))");

                entity.Property(e => e.FixedDay).HasDefaultValueSql("((0))");

                entity.Property(e => e.FixedDayRounding).HasDefaultValueSql("((2818050))");

                entity.Property(e => e.InstallmentType).HasDefaultValueSql("((2686977))");

                entity.Property(e => e.Perc).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.PaymentNavigation)
                    .WithMany(p => p.MaPaymentTermsPercInstall)
                    .HasForeignKey(d => d.Payment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentTer_PaymentTer_01");
            });
        }
    }
}
