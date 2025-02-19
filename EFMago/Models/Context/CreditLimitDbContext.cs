using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class CreditLimitDbContext : DbContext
    {
        public CreditLimitDbContext()
        {
        }
        public CreditLimitDbContext(DbContextOptions<CreditLimitDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaCreditCustomer> MaCreditCustomer { get; set; }
        public virtual DbSet<MaCreditCustomerDocument> MaCreditCustomerDocument { get; set; }
        public virtual DbSet<MaCreditParameters> MaCreditParameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaCreditCustomer>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.Customer });

                entity.ToTable("MA_CreditCustomer");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CreditLimitManage)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.MaxOrderValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.MaxOrderValueCheckType).HasDefaultValueSql("((28049408))");

                entity.Property(e => e.MaxOrderValueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.MaxOrderedValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.MaxOrderedValueCheckType).HasDefaultValueSql("((28049408))");

                entity.Property(e => e.MaxOrderedValueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.MaximumCredit).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.MaximumCreditCheckType).HasDefaultValueSql("((28049408))");

                entity.Property(e => e.MaximumCreditCheckTypeDefInv).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.MaximumCreditCheckTypeDelDoc).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.MaximumCreditCheckTypeImmInv).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.MaximumCreditDate)
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

                entity.Property(e => e.TotalExposure).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalExposureCheckType).HasDefaultValueSql("((28049408))");

                entity.Property(e => e.TotalExposureCheckTypeDefInv).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.TotalExposureCheckTypeDelDoc).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.TotalExposureCheckTypeImmInv).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.TotalExposureDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.HasOne(d => d.Cust)
                    .WithOne(p => p.MaCreditCustomer)
                    .HasForeignKey<MaCreditCustomer>(d => new { d.CustSuppType, d.Customer })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MA_CreditCustomer_00");
            });
            modelBuilder.Entity<MaCreditCustomerDocument>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.Customer, e.DocumentType, e.DocumentId });

                entity.ToTable("MA_CreditCustomerDocument");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CreditType).HasDefaultValueSql("((28114944))");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentNo)
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

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.MaCreditCustomerDocument)
                    .HasForeignKey(d => new { d.CustSuppType, d.Customer })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MA_CreditCustomerDoc_00");
            });
            modelBuilder.Entity<MaCreditParameters>(entity =>
{
                entity.ToTable("MA_CreditParameters");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DaysOfOutstanding).HasDefaultValueSql("((0))");

                entity.Property(e => e.MarginOnCredit).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.MaxOrderValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.MaxOrderValueCheckType).HasDefaultValueSql("((28049408))");

                entity.Property(e => e.MaxOrderedValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.MaxOrderedValueCheckType).HasDefaultValueSql("((28049408))");

                entity.Property(e => e.MaximumCredit).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.MaximumCreditCheckType).HasDefaultValueSql("((28049408))");

                entity.Property(e => e.MaximumCreditCheckTypeDefInv).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.MaximumCreditCheckTypeDelDoc).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.MaximumCreditCheckTypeImmInv).HasDefaultValueSql("((11599872))");

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

                entity.Property(e => e.TotalCreditLimitnetofOrdered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TotalExposure).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalExposureCheckType).HasDefaultValueSql("((28049408))");

                entity.Property(e => e.TotalExposureCheckTypeDefInv).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.TotalExposureCheckTypeDelDoc).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.TotalExposureCheckTypeImmInv).HasDefaultValueSql("((11599872))");
            });
        }
    }
}
