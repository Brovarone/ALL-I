using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class InvoiceMngDbContext : DbContext
    {
        public InvoiceMngDbContext()
        {
        }
        public InvoiceMngDbContext(DbContextOptions<InvoiceMngDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaCorrectionDocParameters> MaCorrectionDocParameters { get; set; }
        public virtual DbSet<MaDocumentParameters> MaDocumentParameters { get; set; }
        public virtual DbSet<MaInvoiceParameters> MaInvoiceParameters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaCorrectionDocParameters>(entity =>
{
                entity.HasKey(e => e.IdcorrectionDocParameters)
                    .HasName("PK_CorrectionDocParameters")
                    .IsClustered(false);

                entity.ToTable("MA_CorrectionDocParameters");

                entity.Property(e => e.IdcorrectionDocParameters)
                    .HasColumnName("IDCorrectionDocParameters")
                    .ValueGeneratedNever();

                entity.Property(e => e.DenyToDeleteCorrectedLine).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.DenyToInsertQtyGreater).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.ModifyOriginalPymtSched)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NegativeValueInAccTrans)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchasePriceToPropose).HasDefaultValueSql("((29491200))");

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
            modelBuilder.Entity<MaDocumentParameters>(entity =>
{
                entity.HasKey(e => e.DocumentType)
                    .HasName("PK_DocumentParameters")
                    .IsClustered(false);

                entity.ToTable("MA_DocumentParameters");

                entity.Property(e => e.DocumentType).ValueGeneratedNever();

                entity.Property(e => e.Archive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AutomaticRoundingTotPayable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BelowCostCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CheckNegativeValues).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.DeletingCheckType).HasDefaultValueSql("((10682368))");

                entity.Property(e => e.DisableRollBack)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableUpdArchive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableUpdIssue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableUpdPostAccounting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableUpdPostInspOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableUpdPostIntrastat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableUpdPostInvReturn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableUpdPostInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableUpdPostPymntSched)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableUpdPrinter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableUpdSendEmail)
                    .HasColumnName("DisableUpdSendEMail")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DisableUpdSendPostaLite)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EmailCheckType)
                    .HasColumnName("EMailCheckType")
                    .HasDefaultValueSql("((10682368))");

                entity.Property(e => e.InvoicedDncheckType)
                    .HasColumnName("InvoicedDNCheckType")
                    .HasDefaultValueSql("((10682368))");

                entity.Property(e => e.Issue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IssueCheckType).HasDefaultValueSql("((10682368))");

                entity.Property(e => e.LineType).HasDefaultValueSql("((3538947))");

                entity.Property(e => e.NetOfTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NoRollback)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostAccounting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostAccountingCheckType).HasDefaultValueSql("((10682368))");

                entity.Property(e => e.PostInspectionOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostIntrastat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostIntrastatCheckType).HasDefaultValueSql("((10682368))");

                entity.Property(e => e.PostInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostInventoryCheckType).HasDefaultValueSql("((10682368))");

                entity.Property(e => e.PostInventoryReturn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostPymntSched)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostPymtSchedCheckType).HasDefaultValueSql("((10682368))");

                entity.Property(e => e.PostaLiteCheckType).HasDefaultValueSql("((10682368))");

                entity.Property(e => e.PostaLiteDeliveryType).HasDefaultValueSql("((2147352576))");

                entity.Property(e => e.PostaLitePrintType).HasDefaultValueSql("((2147287040))");

                entity.Property(e => e.PrintCheckType).HasDefaultValueSql("((10682368))");

                entity.Property(e => e.PrintPreview)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Printer)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReferencesPrintType).HasDefaultValueSql("((524293))");

                entity.Property(e => e.RoundOffNetPrice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.RoundingTo).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SendEmail)
                    .HasColumnName("SendEMail")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SendPostaLite)
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

                entity.Property(e => e.UpdateAccounting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.UpdateInventory)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");
            });
            modelBuilder.Entity<MaInvoiceParameters>(entity =>
{
                entity.HasKey(e => e.IdinvoiceParameters)
                    .HasName("PK_InvoiceParameters")
                    .IsClustered(false);

                entity.ToTable("MA_InvoiceParameters");

                entity.Property(e => e.IdinvoiceParameters)
                    .HasColumnName("IDInvoiceParameters")
                    .ValueGeneratedNever();

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

                entity.Property(e => e.VatOnDocLine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
        }
    }
}
