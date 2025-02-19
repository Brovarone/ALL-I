using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class IdsMngDbContext : DbContext
    {
        public IdsMngDbContext()
        {
        }
        public IdsMngDbContext(DbContextOptions<IdsMngDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaDocumentReason> MaDocumentReason { get; set; }
        public virtual DbSet<MaIdnumbers> MaIdnumbers { get; set; }
        public virtual DbSet<MaNonFiscalNumbers> MaNonFiscalNumbers { get; set; }
        public virtual DbSet<MaNumberParameters> MaNumberParameters { get; set; }
        public virtual DbSet<MaStubBookNumbers> MaStubBookNumbers { get; set; }
        public virtual DbSet<MaStubBooks> MaStubBooks { get; set; }
        public virtual DbSet<MaTaxJournalNumbers> MaTaxJournalNumbers { get; set; }
        public virtual DbSet<MaTaxJournals> MaTaxJournals { get; set; }
        public virtual DbSet<MaTaxJournalsRange> MaTaxJournalsRange { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaDocumentReason>(entity =>
{
                entity.HasKey(e => e.Code)
                    .HasName("PK_DocumentReason")
                    .IsClustered(false);

                entity.ToTable("MA_DocumentReason");

                entity.Property(e => e.Code)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
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
            modelBuilder.Entity<MaIdnumbers>(entity =>
{
                entity.HasKey(e => e.CodeType)
                    .HasName("PK_IDNumbers")
                    .IsClustered(false);

                entity.ToTable("MA_IDNumbers");

                entity.Property(e => e.CodeType).ValueGeneratedNever();

                entity.Property(e => e.LastId).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaNonFiscalNumbers>(entity =>
{
                entity.HasKey(e => new { e.BalanceYear, e.CodeType })
                    .HasName("PK_NonFiscalNumbers")
                    .IsClustered(false);

                entity.ToTable("MA_NonFiscalNumbers");

                entity.Property(e => e.DisableManualMod)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastDocNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.PrefixFormat).HasDefaultValueSql("((24969217))");

                entity.Property(e => e.PrefixWithSiteCode)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Separators)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Suffix)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuffixChars).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaNumberParameters>(entity =>
{
                entity.HasKey(e => e.NumberParametersId)
                    .HasName("PK_NumberParameters")
                    .IsClustered(false);

                entity.ToTable("MA_NumberParameters");

                entity.Property(e => e.NumberParametersId).ValueGeneratedNever();

                entity.Property(e => e.AutomaticPrefix)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CheckSequentialNumbering).HasDefaultValueSql("((11599873))");

                entity.Property(e => e.ErrorOnDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrefixFormat).HasDefaultValueSql("((24969217))");

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
            modelBuilder.Entity<MaStubBookNumbers>(entity =>
{
                entity.HasKey(e => new { e.BalanceYear, e.StubBook })
                    .HasName("PK_StubBookNumbers")
                    .IsClustered(false);

                entity.ToTable("MA_StubBookNumbers");

                entity.Property(e => e.StubBook)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.LastDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastDocNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Suffix)
                    .HasMaxLength(4)
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
            modelBuilder.Entity<MaStubBooks>(entity =>
{
                entity.HasKey(e => e.StubBook)
                    .HasName("PK_StubBooks")
                    .IsClustered(false);

                entity.ToTable("MA_StubBooks");

                entity.Property(e => e.StubBook)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.CodeType).HasDefaultValueSql("((9961472))");

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
            modelBuilder.Entity<MaTaxJournalNumbers>(entity =>
{
                entity.HasKey(e => new { e.BalanceYear, e.TaxJournal })
                    .HasName("PK_TaxJournalNumbers")
                    .IsClustered(false);

                entity.ToTable("MA_TaxJournalNumbers");

                entity.Property(e => e.TaxJournal)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.LastDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastDocNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.Suffix)
                    .HasMaxLength(4)
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
            modelBuilder.Entity<MaTaxJournals>(entity =>
{
                entity.HasKey(e => e.TaxJournal)
                    .HasName("PK_TaxJournals")
                    .IsClustered(false);

                entity.ToTable("MA_TaxJournals");

                entity.HasIndex(e => new { e.CodeType, e.TaxJournal })
                    .HasName("MA_TaxJournals2");

                entity.HasIndex(e => new { e.Disabled, e.CodeType, e.Euannotation, e.TaxJournal })
                    .HasName("MA_TaxJournals3");

                entity.Property(e => e.TaxJournal)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AutomaticNumbering)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BranchNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.CodeType).HasDefaultValueSql("((131073))");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Euannotation)
                    .HasColumnName("EUAnnotation")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExcludedFromProRata)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExcludedFromVat)
                    .HasColumnName("ExcludedFromVAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InTravelAgencyCalculation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsAprotocol)
                    .HasColumnName("IsAProtocol")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsTravelAgencyJournal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MarginTax)
                    .HasColumnName("MarginTAX")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Omniasection)
                    .HasColumnName("OMNIASection")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('00')");

                entity.Property(e => e.SpecialPrint)
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
            modelBuilder.Entity<MaTaxJournalsRange>(entity =>
{
                entity.HasKey(e => new { e.TaxJournal, e.FirstRangeNo })
                    .HasName("PK_TaxJournalsRange")
                    .IsClustered(false);

                entity.ToTable("MA_TaxJournalsRange");

                entity.Property(e => e.TaxJournal)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.LastAssignedNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastRangeNo).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.TaxJournalNavigation)
                    .WithMany(p => p.MaTaxJournalsRange)
                    .HasForeignKey(d => d.TaxJournal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaxJournalsRange_01");
            });
        }
    }
}
