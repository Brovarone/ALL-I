using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class OpenOrdersDbContext : DbContext
    {
        public OpenOrdersDbContext()
        {
        }
        public OpenOrdersDbContext(DbContextOptions<OpenOrdersDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaCustContracts> MaCustContracts { get; set; }
        public virtual DbSet<MaCustContractsDetails> MaCustContractsDetails { get; set; }
        public virtual DbSet<MaCustContractsLines> MaCustContractsLines { get; set; }
        public virtual DbSet<MaCustContractsRef> MaCustContractsRef { get; set; }
        public virtual DbSet<MaDeliveryPlaceItemCust> MaDeliveryPlaceItemCust { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaCustContracts>(entity =>
{
                entity.HasKey(e => e.ContractNo)
                    .HasName("PK_CustContracts")
                    .IsClustered(false);

                entity.ToTable("MA_CustContracts");

                entity.Property(e => e.ContractNo)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ContractType).HasDefaultValueSql("((25690112))");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EndValidityDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ModificationsHistory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.StartValidityDate)
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

                entity.Property(e => e.Validity)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaCustContractsDetails>(entity =>
{
                entity.HasKey(e => new { e.ContractNo, e.Line, e.ConfirmationLevel })
                    .HasName("PK_CustContractsDetails")
                    .IsClustered(false);

                entity.ToTable("MA_CustContractsDetails");

                entity.Property(e => e.ContractNo)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmationLevel)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.DailySplit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Horizon).HasDefaultValueSql("((0))");

                entity.Property(e => e.PeriodType).HasDefaultValueSql("((25624576))");

                entity.Property(e => e.ReferenceDay).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ContractNoNavigation)
                    .WithMany(p => p.MaCustContractsDetails)
                    .HasForeignKey(d => d.ContractNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustContra_CustContra_00");
            });
            modelBuilder.Entity<MaCustContractsLines>(entity =>
{
                entity.HasKey(e => new { e.ContractNo, e.Line })
                    .IsClustered(false);

                entity.ToTable("MA_CustContractsLines");

                entity.Property(e => e.ContractNo)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BudgetQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.BudgetValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiscountIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LineType).HasDefaultValueSql("((3538947))");

                entity.Property(e => e.MinimumQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitValueIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.ContractNoNavigation)
                    .WithMany(p => p.MaCustContractsLines)
                    .HasForeignKey(d => d.ContractNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustContra_CustContra_02");
            });
            modelBuilder.Entity<MaCustContractsRef>(entity =>
{
                entity.HasKey(e => new { e.ContractNo, e.Line })
                    .IsClustered(false);

                entity.ToTable("MA_CustContractsRef");

                entity.Property(e => e.ContractNo)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SaleOrdId).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ContractNoNavigation)
                    .WithMany(p => p.MaCustContractsRef)
                    .HasForeignKey(d => d.ContractNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustContra_CustContra_01");
            });
            modelBuilder.Entity<MaDeliveryPlaceItemCust>(entity =>
{
                entity.HasKey(e => new { e.Item, e.Customer, e.Address })
                    .HasName("PK_DeliveryPlaceItemCust")
                    .IsClustered(false);

                entity.ToTable("MA_DeliveryPlaceItemCust");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(64)
                    .IsUnicode(false);

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

                entity.HasOne(d => d.MaItemCustomers)
                    .WithMany(p => p.MaDeliveryPlaceItemCust)
                    .HasForeignKey(d => new { d.Item, d.Customer })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryPl_ItemCustom_00");
            });
        }
    }
}
