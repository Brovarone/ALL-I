using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21

namespace EFMago.Models
{
    public partial class AccountingBGDbContext : DbContext
    {
        public AccountingBGDbContext()
        {
        }

        public AccountingBGDbContext(DbContextOptions<AccountingBGDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaTaxDocumentType> MaTaxDocumentType { get; set; }
        public virtual DbSet<MaTaxJournalsReferences> MaTaxJournalsReferences { get; set; }
        public virtual DbSet<MaTmpSalePurchaseJournal> MaTmpSalePurchaseJournal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if (!optionsBuilder.IsConfigured)
            //  {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //       optionsBuilder.UseSqlServer("Server=ACERBO\\SQLEXPRESS; Database=DEMON;User Id=sa;Password=euroufficio");
            //   }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaTaxDocumentType>(entity =>
            {
                entity.HasKey(e => e.TypeOfTaxDocument)
                    .HasName("PK_TypeOfTaxDocument")
                    .IsClustered(false);

                entity.ToTable("MA_TaxDocumentType");

                entity.Property(e => e.TypeOfTaxDocument)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
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

            modelBuilder.Entity<MaTaxJournalsReferences>(entity =>
            {
                entity.HasKey(e => new { e.SaleRetailType, e.AccountingTemplate, e.TaxCode })
                    .HasName("PK_TaxJournalsReferences")
                    .IsClustered(false);

                entity.ToTable("MA_TaxJournalsReferences");

                entity.Property(e => e.SaleRetailType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AccountingTemplate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxAmountColumn)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxableAmountColumn)
                    .HasMaxLength(2)
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



            modelBuilder.Entity<MaTmpSalePurchaseJournal>(entity =>
            {
                entity.HasKey(e => new { e.SessionGuid, e.Type, e.Total, e.JournalEntryId })
                    .HasName("PK_TmpSalePurchaseJournal")
                    .IsClustered(false);

                entity.ToTable("MA_TmpSalePurchaseJournal");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Column01).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column0133).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column0140).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column02).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column03)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Column04)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Column04bis)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Column05)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Column05bis)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Column06)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Column07)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Column08)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Column08a)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Column09).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column10).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column11).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column12).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column13).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column14).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column15).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column16).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column17).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column18).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column19).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column20).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column21).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column22).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column23).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column24).HasDefaultValueSql("((0))");

                entity.Property(e => e.Column25).HasDefaultValueSql("((0))");

                entity.Property(e => e.JournalEntryIdDel).HasDefaultValueSql("('0')");

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

                entity.Property(e => e.ViesPeriod)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ViesType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });


        }
    }
}
