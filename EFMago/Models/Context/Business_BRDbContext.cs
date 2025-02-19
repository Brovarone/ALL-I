using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

//Ultimo adeguamento mago.net 3.14.21
namespace EFMago.Models
{
    public partial class Business_BRDbContext : DbContext
    {
        public Business_BRDbContext()
        {
        }
        public Business_BRDbContext(DbContextOptions<Business_BRDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MaBranp> MaBranp { get; set; }
        public virtual DbSet<MaBrautoNumbering> MaBrautoNumbering { get; set; }
        public virtual DbSet<MaBrcest> MaBrcest { get; set; }
        public virtual DbSet<MaBrcfop> MaBrcfop { get; set; }
        public virtual DbSet<MaBrcfopgroup> MaBrcfopgroup { get; set; }
        public virtual DbSet<MaBrcorrectionLetterForCust> MaBrcorrectionLetterForCust { get; set; }
        public virtual DbSet<MaBrcorrectionLetterForSupp> MaBrcorrectionLetterForSupp { get; set; }
        public virtual DbSet<MaBrcustSuppFiscalCtg> MaBrcustSuppFiscalCtg { get; set; }
        public virtual DbSet<MaBrimportDecl> MaBrimportDecl { get; set; }
        public virtual DbSet<MaBrimportDeclDetail> MaBrimportDeclDetail { get; set; }
        public virtual DbSet<MaBrimportNfe> MaBrimportNfe { get; set; }
        public virtual DbSet<MaBrimportNfeDetail> MaBrimportNfeDetail { get; set; }
        public virtual DbSet<MaBrimportNfePymtSched> MaBrimportNfePymtSched { get; set; }
        public virtual DbSet<MaBrimportNfeRef> MaBrimportNfeRef { get; set; }
        public virtual DbSet<MaBrimportTaxRules> MaBrimportTaxRules { get; set; }
        public virtual DbSet<MaBripilegalCode> MaBripilegalCode { get; set; }
        public virtual DbSet<MaBritemFiscalCtg> MaBritemFiscalCtg { get; set; }
        public virtual DbSet<MaBrncm> MaBrncm { get; set; }
        public virtual DbSet<MaBrnfeParameters> MaBrnfeParameters { get; set; }
        public virtual DbSet<MaBrnfeParametersDetails> MaBrnfeParametersDetails { get; set; }
        public virtual DbSet<MaBrnotaFiscalForCustDetail> MaBrnotaFiscalForCustDetail { get; set; }
        public virtual DbSet<MaBrnotaFiscalForCustRef> MaBrnotaFiscalForCustRef { get; set; }
        public virtual DbSet<MaBrnotaFiscalForCustShipping> MaBrnotaFiscalForCustShipping { get; set; }
        public virtual DbSet<MaBrnotaFiscalForCustSummary> MaBrnotaFiscalForCustSummary { get; set; }
        public virtual DbSet<MaBrnotaFiscalForCustomer> MaBrnotaFiscalForCustomer { get; set; }
        public virtual DbSet<MaBrnotaFiscalForSuppDetail> MaBrnotaFiscalForSuppDetail { get; set; }
        public virtual DbSet<MaBrnotaFiscalForSuppRef> MaBrnotaFiscalForSuppRef { get; set; }
        public virtual DbSet<MaBrnotaFiscalForSuppShipping> MaBrnotaFiscalForSuppShipping { get; set; }
        public virtual DbSet<MaBrnotaFiscalForSuppSummary> MaBrnotaFiscalForSuppSummary { get; set; }
        public virtual DbSet<MaBrnotaFiscalForSupplier> MaBrnotaFiscalForSupplier { get; set; }
        public virtual DbSet<MaBrnotaFiscalNumbers> MaBrnotaFiscalNumbers { get; set; }
        public virtual DbSet<MaBrnotaFiscalType> MaBrnotaFiscalType { get; set; }
        public virtual DbSet<MaBrnotaFiscalTypeDetail> MaBrnotaFiscalTypeDetail { get; set; }
        public virtual DbSet<MaBrnve> MaBrnve { get; set; }
        public virtual DbSet<MaBrromaneio> MaBrromaneio { get; set; }
        public virtual DbSet<MaBrromaneioDetail> MaBrromaneioDetail { get; set; }
        public virtual DbSet<MaBrromaneioExpenses> MaBrromaneioExpenses { get; set; }
        public virtual DbSet<MaBrromaneioNotes> MaBrromaneioNotes { get; set; }
        public virtual DbSet<MaBrromaneioPausesDetail> MaBrromaneioPausesDetail { get; set; }
        public virtual DbSet<MaBrromaneioRefuellingDetail> MaBrromaneioRefuellingDetail { get; set; }
        public virtual DbSet<MaBrromaneioSummary> MaBrromaneioSummary { get; set; }
        public virtual DbSet<MaBrseries> MaBrseries { get; set; }
        public virtual DbSet<MaBrseriesUnusedNumbersDetail> MaBrseriesUnusedNumbersDetail { get; set; }
        public virtual DbSet<MaBrserviceTypes> MaBrserviceTypes { get; set; }
        public virtual DbSet<MaBrserviceTypesDetail> MaBrserviceTypesDetail { get; set; }
        public virtual DbSet<MaBrspedparameters> MaBrspedparameters { get; set; }
        public virtual DbSet<MaBrtaxCalc> MaBrtaxCalc { get; set; }
        public virtual DbSet<MaBrtaxCode> MaBrtaxCode { get; set; }
        public virtual DbSet<MaBrtaxFormula> MaBrtaxFormula { get; set; }
        public virtual DbSet<MaBrtaxMessages> MaBrtaxMessages { get; set; }
        public virtual DbSet<MaBrtaxRate> MaBrtaxRate { get; set; }
        public virtual DbSet<MaBrtaxRateDetail> MaBrtaxRateDetail { get; set; }
        public virtual DbSet<MaBrtaxRules> MaBrtaxRules { get; set; }
        public virtual DbSet<MaBrvehicle> MaBrvehicle { get; set; }
        public virtual DbSet<MaCustSuppBrtaxes> MaCustSuppBrtaxes { get; set; }
        public virtual DbSet<MaItemsBrfiscalCtg> MaItemsBrfiscalCtg { get; set; }
        public virtual DbSet<MaItemsBrtaxes> MaItemsBrtaxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Se necessario, configura la stringa di connessione qui
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaBranp>(entity =>
{
                entity.HasKey(e => e.Anp)
                    .HasName("PK_BRANP")
                    .IsClustered(false);

                entity.ToTable("MA_BRANP");

                entity.Property(e => e.Anp)
                    .HasColumnName("ANP")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
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
            modelBuilder.Entity<MaBrautoNumbering>(entity =>
{
                entity.HasKey(e => e.AutonumberingType)
                    .HasName("PK_BRAutoNumbering")
                    .IsClustered(false);

                entity.ToTable("MA_BRAutoNumbering");

                entity.Property(e => e.AutonumberingType).ValueGeneratedNever();

                entity.Property(e => e.AutoNumbering)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxChars).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaBrcest>(entity =>
{
                entity.HasKey(e => e.Cest)
                    .HasName("PK_BRCEST")
                    .IsClustered(false);

                entity.ToTable("MA_BRCEST");

                entity.Property(e => e.Cest)
                    .HasColumnName("CEST")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
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
            modelBuilder.Entity<MaBrcfop>(entity =>
{
                entity.HasKey(e => new { e.Cfop, e.ValidityStartingDate })
                    .HasName("PK_BRCFOP")
                    .IsClustered(false);

                entity.ToTable("MA_BRCFOP");

                entity.Property(e => e.Cfop)
                    .HasColumnName("CFOP")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityStartingDate).HasColumnType("datetime");

                entity.Property(e => e.Cfopgroup)
                    .HasColumnName("CFOPGroup")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExcludeFromTot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MovementType).HasDefaultValueSql("((0))");

                entity.Property(e => e.OperationDescription)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(70)
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

                entity.Property(e => e.TransactionType).HasDefaultValueSql("((0))");

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaBrcfopgroup>(entity =>
{
                entity.HasKey(e => e.Cfopgroup)
                    .HasName("PK_BRCFOPGroup")
                    .IsClustered(false);

                entity.ToTable("MA_BRCFOPGroup");

                entity.Property(e => e.Cfopgroup)
                    .HasColumnName("CFOPGroup")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
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
            modelBuilder.Entity<MaBrcorrectionLetterForCust>(entity =>
{
                entity.HasKey(e => e.CorrectionLetterId)
                    .HasName("PK_BRCorrectionLetterForCust")
                    .IsClustered(false);

                entity.ToTable("MA_BRCorrectionLetterForCust");

                entity.Property(e => e.CorrectionLetterId).ValueGeneratedNever();

                entity.Property(e => e.CorrectionLetterDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CorrectionLetterStatus).HasDefaultValueSql("((32112640))");

                entity.Property(e => e.CorrectionLetterText)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.ProgressiveNumber).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UseCondition)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaBrcorrectionLetterForSupp>(entity =>
{
                entity.HasKey(e => e.CorrectionLetterId)
                    .HasName("PK_BRCorrectionLetterForSupp")
                    .IsClustered(false);

                entity.ToTable("MA_BRCorrectionLetterForSupp");

                entity.Property(e => e.CorrectionLetterId).ValueGeneratedNever();

                entity.Property(e => e.CorrectionLetterDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CorrectionLetterStatus).HasDefaultValueSql("((32112640))");

                entity.Property(e => e.CorrectionLetterText)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.ProgressiveNumber).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UseCondition)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaBrcustSuppFiscalCtg>(entity =>
{
                entity.HasKey(e => e.CustSuppFiscalCtg)
                    .HasName("PK_BRCustSuppFiscalCtg")
                    .IsClustered(false);

                entity.ToTable("MA_BRCustSuppFiscalCtg");

                entity.Property(e => e.CustSuppFiscalCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
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
            modelBuilder.Entity<MaBrimportDecl>(entity =>
{
                entity.HasKey(e => e.Id)
                    .HasName("PK_BRImportDecl")
                    .IsClustered(false);

                entity.ToTable("MA_BRImportDecl");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Afrmmtot)
                    .HasColumnName("AFRMMTot")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Appearance)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomsDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CustomsState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DischargePlace)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExporterCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ImportDeclarationNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Importer).HasDefaultValueSql("((30539776))");

                entity.Property(e => e.ImporterCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InNotaFiscal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IntermediationType).HasDefaultValueSql("((30605312))");

                entity.Property(e => e.LastSubId)
                    .HasColumnName("LastSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ModeOfTransport)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NetWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.RegistrationDate)
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
            modelBuilder.Entity<MaBrimportDeclDetail>(entity =>
{
                entity.HasKey(e => new { e.Id, e.SubId })
                    .HasName("PK_BRImportDeclDetail")
                    .IsClustered(false);

                entity.ToTable("MA_BRImportDeclDetail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SubId).HasColumnName("SubID");

                entity.Property(e => e.AdditionNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.AdditionalCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Afrmm)
                    .HasColumnName("AFRMM")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CofinsPerc)
                    .HasColumnName("COFINS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CofinsTaxable)
                    .HasColumnName("COFINS_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CofinsValue)
                    .HasColumnName("COFINS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefSubId)
                    .HasColumnName("CRRefSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.CustomsValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Drawback)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsPerc)
                    .HasColumnName("ICMS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsReductionPerc)
                    .HasColumnName("ICMS_Reduction_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsTaxable)
                    .HasColumnName("ICMS_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsValue)
                    .HasColumnName("ICMS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IiPerc)
                    .HasColumnName("II_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IiTaxable)
                    .HasColumnName("II_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IiValue)
                    .HasColumnName("II_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ImportCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InNotaFiscal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IofValue)
                    .HasColumnName("IOF_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpiPerc)
                    .HasColumnName("IPI_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpiTaxable)
                    .HasColumnName("IPI_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpiValue)
                    .HasColumnName("IPI_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ncm)
                    .HasColumnName("NCM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PisPerc)
                    .HasColumnName("PIS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PisTaxable)
                    .HasColumnName("PIS_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PisValue)
                    .HasColumnName("PIS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SeqAdditionNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.SiscomexValue)
                    .HasColumnName("SISCOMEX_Value")
                    .HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.TotalAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaBrimportNfe>(entity =>
{
                entity.HasKey(e => e.DocumentId)
                    .HasName("PK_BRImportNFe")
                    .IsClustered(false);

                entity.ToTable("MA_BRImportNFe");

                entity.Property(e => e.AdditionalChargesSend)
                    .HasColumnName("AdditionalCharges_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Address2Send)
                    .HasColumnName("Address2_Send")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AddressSend)
                    .HasColumnName("Address_Send")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AppearanceSend)
                    .HasColumnName("Appearance_Send")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChNfeSend)
                    .HasColumnName("ChNFe_Send")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CityCodeSend)
                    .HasColumnName("CityCode_Send")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CityNameCons)
                    .HasColumnName("CityName_Cons")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CityNameSend)
                    .HasColumnName("CityName_Send")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CofinsValueSend)
                    .HasColumnName("COFINS_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CompanyNameCons)
                    .HasColumnName("CompanyName_Cons")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyNameSend)
                    .HasColumnName("CompanyName_Send")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConsultDateCons)
                    .HasColumnName("ConsultDate_Cons")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CostCenterCons)
                    .HasColumnName("CostCenter_Cons")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountryNameSend)
                    .HasColumnName("CountryName_Send")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppCons)
                    .HasColumnName("CustSupp_Cons")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppTypeCons)
                    .HasColumnName("CustSuppType_Cons")
                    .HasDefaultValueSql("((3211264))");

                entity.Property(e => e.DepartureDateSend)
                    .HasColumnName("DepartureDate_Send")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DepartureHrSend)
                    .HasColumnName("DepartureHr_Send")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DepartureMnSend)
                    .HasColumnName("DepartureMn_Send")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountAmountSend)
                    .HasColumnName("DiscountAmount_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistrictSend)
                    .HasColumnName("District_Send")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocNoSend)
                    .HasColumnName("DocNo_Send")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentDateSend)
                    .HasColumnName("DocumentDate_Send")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FantasyNameSend)
                    .HasColumnName("FantasyName_Send")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FedStateRegSend)
                    .HasColumnName("FedStateReg_Send")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FedStateRegStSend)
                    .HasColumnName("FedStateRegST_Send")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FederalStateCons)
                    .HasColumnName("FederalState_Cons")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FederalStateSend)
                    .HasColumnName("FederalState_Send")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiscalCodeCons)
                    .HasColumnName("FiscalCode_Cons")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiscalCodeSend)
                    .HasColumnName("FiscalCode_Send")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiscalMessageSend)
                    .HasColumnName("FiscalMessage_Send")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodsActivitySend)
                    .HasColumnName("GoodsActivity_Send")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodsAmountSend)
                    .HasColumnName("GoodsAmount_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossWeightSend)
                    .HasColumnName("GrossWeight_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.HeadErrorsCons)
                    .HasColumnName("HeadErrors_Cons")
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsValueSend)
                    .HasColumnName("ICMS_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsexValueSend)
                    .HasColumnName("ICMSEx_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstValueSend)
                    .HasColumnName("ICMSST_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmssttotTaxableValueSend)
                    .HasColumnName("ICMSSTTotTaxableValue_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmstotTaxableValueSend)
                    .HasColumnName("ICMSTotTaxableValue_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IiValueSend)
                    .HasColumnName("II_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ImportDateCons)
                    .HasColumnName("ImportDate_Cons")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InstallmStartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InsuranceChargesSend)
                    .HasColumnName("InsuranceCharges_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpiValueSend)
                    .HasColumnName("IPI_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IsocountryCodeSend)
                    .HasColumnName("ISOCountryCode_Send")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModelSend)
                    .HasColumnName("Model_Send")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MunicipalityRegSend)
                    .HasColumnName("MunicipalityReg_Send")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NetWeightSend)
                    .HasColumnName("NetWeight_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NoOfPacksSend)
                    .HasColumnName("NoOfPacks_Send")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NotaFiscalCodeCons)
                    .HasColumnName("NotaFiscalCode_Cons")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OperationDescriptionSend)
                    .HasColumnName("OperationDescription_Send")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackageSend)
                    .HasColumnName("Package_Send")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentCons)
                    .HasColumnName("Payment_Cons")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentTypeSend)
                    .HasColumnName("PaymentType_Send")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PisValueSend)
                    .HasColumnName("PIS_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProcessDateCons)
                    .HasColumnName("ProcessDate_Cons")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PymtAccountCons)
                    .HasColumnName("PymtAccount_Cons")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PymtCashCons)
                    .HasColumnName("PymtCash_Cons")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReceiptDateCons)
                    .HasColumnName("ReceiptDate_Cons")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.SeriesSend)
                    .HasColumnName("Series_Send")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShipChargesSend)
                    .HasColumnName("ShipCharges_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShippingModeSend)
                    .HasColumnName("ShippingMode_Send")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StreetNoSend)
                    .HasColumnName("StreetNo_Send")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxIdNumberCons)
                    .HasColumnName("TaxIdNumber_Cons")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxIdNumberSend)
                    .HasColumnName("TaxIdNumber_Send")
                    .HasMaxLength(20)
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

                entity.Property(e => e.TelephoneSend)
                    .HasColumnName("Telephone_Send")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TotalAmountSend)
                    .HasColumnName("TotalAmount_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TransportCons)
                    .HasColumnName("Transport_Cons")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ZipcodeSend)
                    .HasColumnName("ZIPCode_Send")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaBrimportNfeDetail>(entity =>
{
                entity.HasKey(e => new { e.DocumentId, e.Line })
                    .HasName("PK_BRImportNFeDetail")
                    .IsClustered(false);

                entity.ToTable("MA_BRImportNFeDetail");

                entity.Property(e => e.BarcodeSend)
                    .HasColumnName("Barcode_Send")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BaseUoMCons)
                    .HasColumnName("BaseUoM_Cons")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CfopSend)
                    .HasColumnName("CFOP_Send")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CofinsCodeSend)
                    .HasColumnName("COFINS_Code_Send")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CofinsPercSend)
                    .HasColumnName("COFINS_Perc_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CofinsTaxableSend)
                    .HasColumnName("COFINS_Taxable_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CofinsValueSend)
                    .HasColumnName("COFINS_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DescriptionSend)
                    .HasColumnName("Description_Send")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DetailErrorsCons)
                    .HasColumnName("DetailErrors_Cons")
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiscountAmountSend)
                    .HasColumnName("DiscountAmount_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistrAdditionalChargesSend)
                    .HasColumnName("DistrAdditionalCharges_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistrDiscountSend)
                    .HasColumnName("DistrDiscount_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistrInsuranceChargesSend)
                    .HasColumnName("DistrInsuranceCharges_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DistrShipChargesSend)
                    .HasColumnName("DistrShipCharges_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ExtipiSend)
                    .HasColumnName("EXTIPI_Send")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GoodsOriginSend)
                    .HasColumnName("GoodsOrigin_Send")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IcmsCodeSend)
                    .HasColumnName("ICMS_Code_Send")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsModSend)
                    .HasColumnName("ICMS_Mod_Send")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IcmsNoTaxReasonSend)
                    .HasColumnName("ICMS_NoTaxReason_Send")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IcmsPercSend)
                    .HasColumnName("ICMS_Perc_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsReductionPercSend)
                    .HasColumnName("ICMS_Reduction_Perc_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsTaxableSend)
                    .HasColumnName("ICMS_Taxable_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsValueSend)
                    .HasColumnName("ICMS_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstCodeSend)
                    .HasColumnName("ICMSST_Code_Send")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsstPercSend)
                    .HasColumnName("ICMSST_Perc_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstReductionPercSend)
                    .HasColumnName("ICMSST_Reduction_Perc_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstTaxableSend)
                    .HasColumnName("ICMSST_Taxable_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstValueSend)
                    .HasColumnName("ICMSST_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmssttoBeCompPercSend)
                    .HasColumnName("ICMSSTToBeComp_Perc_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IiPercSend)
                    .HasColumnName("II_Perc_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IiTaxableSend)
                    .HasColumnName("II_Taxable_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IiValueSend)
                    .HasColumnName("II_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpiCodeSend)
                    .HasColumnName("IPI_Code_Send")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IpiPercSend)
                    .HasColumnName("IPI_Perc_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpiTaxableSend)
                    .HasColumnName("IPI_Taxable_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpiValueSend)
                    .HasColumnName("IPI_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ItemCons)
                    .HasColumnName("Item_Cons")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemSend)
                    .HasColumnName("Item_Send")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MvaPercSend)
                    .HasColumnName("MVA_Perc_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NcmSend)
                    .HasColumnName("NCM_Send")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PisCodeSend)
                    .HasColumnName("PIS_Code_Send")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PisPercSend)
                    .HasColumnName("PIS_Perc_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PisTaxableSend)
                    .HasColumnName("PIS_Taxable_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PisValueSend)
                    .HasColumnName("PIS_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.QtyInBaseUoMCons)
                    .HasColumnName("QtyInBaseUoM_Cons")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.QtySend)
                    .HasColumnName("Qty_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SimplesCodeSend)
                    .HasColumnName("SIMPLES_Code_Send")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SimplesPercSend)
                    .HasColumnName("SIMPLES_Perc_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SimplesTaxableSend)
                    .HasColumnName("SIMPLES_Taxable_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SimplesValueSend)
                    .HasColumnName("SIMPLES_Value_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxRuleCodeCompanyCons)
                    .HasColumnName("TaxRuleCodeCompany_Cons")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxRuleCodeCons)
                    .HasColumnName("TaxRuleCode_Cons")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxableAmountSend)
                    .HasColumnName("TaxableAmount_Send")
                    .HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.TotalAmountSend)
                    .HasColumnName("TotalAmount_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UnitValueSend)
                    .HasColumnName("UnitValue_Send")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.UoMSend)
                    .HasColumnName("UoM_Send")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UoMofQtySendCons)
                    .HasColumnName("UoMOfQtySend_Cons")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.MaBrimportNfeDetail)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRImpNFeDet_BRImpNFe_01");
            });
            modelBuilder.Entity<MaBrimportNfePymtSched>(entity =>
{
                entity.HasKey(e => new { e.DocumentId, e.InstallmentNoSend })
                    .HasName("PK_BRImportNFePymtSched")
                    .IsClustered(false);

                entity.ToTable("MA_BRImportNFePymtSched");

                entity.Property(e => e.InstallmentNoSend).HasColumnName("InstallmentNo_Send");

                entity.Property(e => e.DueDateSend)
                    .HasColumnName("DueDate_Send")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InstallmentAmountSend)
                    .HasColumnName("InstallmentAmount_Send")
                    .HasDefaultValueSql("((0.00))");

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
            modelBuilder.Entity<MaBrimportNfeRef>(entity =>
{
                entity.HasKey(e => new { e.DocumentId, e.Line })
                    .HasName("PK_BRImportNFeRef")
                    .IsClustered(false);

                entity.ToTable("MA_BRImportNFeRef");

                entity.Property(e => e.FedStateRegSend)
                    .HasColumnName("FedStateReg_Send")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModelNfSend)
                    .HasColumnName("ModelNF_Send")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModelSend)
                    .HasColumnName("Model_Send")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MonthSend)
                    .HasColumnName("Month_Send")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NumberCooSend)
                    .HasColumnName("NumberCOO_Send")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumberEcfSend)
                    .HasColumnName("NumberECF_Send")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumberNfSend)
                    .HasColumnName("NumberNF_Send")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RefKeySend)
                    .HasColumnName("RefKey_Send")
                    .HasMaxLength(44)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SeriesSend)
                    .HasColumnName("Series_Send")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxIdNumberSend)
                    .HasColumnName("TaxIdNumber_Send")
                    .HasMaxLength(20)
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

                entity.Property(e => e.TypeCons)
                    .HasColumnName("Type_Cons")
                    .HasDefaultValueSql("((29229056))");

                entity.Property(e => e.UfSend)
                    .HasColumnName("UF_Send")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.YearSend)
                    .HasColumnName("Year_Send")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.MaBrimportNfeRef)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRImpNFeRef_BRImpNFe_01");
            });
            modelBuilder.Entity<MaBrimportTaxRules>(entity =>
{
                entity.HasKey(e => new { e.TaxRuleCode, e.ValidityStartingDate })
                    .HasName("PK_BRImportTaxRules")
                    .IsClustered(false);

                entity.ToTable("MA_BRImportTaxRules");

                entity.Property(e => e.TaxRuleCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityStartingDate).HasColumnType("datetime");

                entity.Property(e => e.AllItems)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Cfop)
                    .HasColumnName("CFOP")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CofinstaxCode)
                    .HasColumnName("COFINSTaxCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cofinstype)
                    .HasColumnName("COFINSType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.CustSuppFiscalCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmssttaxCode)
                    .HasColumnName("ICMSSTTaxCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Icmssttype)
                    .HasColumnName("ICMSSTType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.IcmstaxCode)
                    .HasColumnName("ICMSTaxCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Icmstype)
                    .HasColumnName("ICMSType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.IpitaxCode)
                    .HasColumnName("IPITaxCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ipitype)
                    .HasColumnName("IPIType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemFiscalCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ncm)
                    .HasColumnName("NCM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotaFiscalCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OriginalCfop)
                    .HasColumnName("OriginalCFOP")
                    .HasMaxLength(108)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PistaxCode)
                    .HasColumnName("PISTaxCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Pistype)
                    .HasColumnName("PISType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

                entity.Property(e => e.SimplestaxCode)
                    .HasColumnName("SIMPLESTaxCode")
                    .HasMaxLength(8)
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

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaBripilegalCode>(entity =>
{
                entity.HasKey(e => e.IpilegalCode)
                    .HasName("PK_BRIPILegalCode")
                    .IsClustered(false);

                entity.ToTable("MA_BRIPILegalCode");

                entity.Property(e => e.IpilegalCode)
                    .HasColumnName("IPILegalCode")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
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
            modelBuilder.Entity<MaBritemFiscalCtg>(entity =>
{
                entity.HasKey(e => e.ItemFiscalCtg)
                    .HasName("PK_BRItemFiscalCtg")
                    .IsClustered(false);

                entity.ToTable("MA_BRItemFiscalCtg");

                entity.Property(e => e.ItemFiscalCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
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
            modelBuilder.Entity<MaBrncm>(entity =>
{
                entity.HasKey(e => new { e.Ncm, e.ValidityStartingDate })
                    .HasName("PK_BRNCM")
                    .IsClustered(false);

                entity.ToTable("MA_BRNCM");

                entity.Property(e => e.Ncm)
                    .HasColumnName("NCM")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityStartingDate).HasColumnType("datetime");

                entity.Property(e => e.ApproxTaxesDomesticPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ApproxTaxesImportPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmstaxRateCode)
                    .HasColumnName("ICMSTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IpisettlementType)
                    .HasColumnName("IPISettlementType")
                    .HasDefaultValueSql("((31784960))");

                entity.Property(e => e.MunApproxTaxesDomesticPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.MunApproxTaxesImportPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StateApproxTaxesDomesticPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StateApproxTaxesImportPerc).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaBrnfeParameters>(entity =>
{
                entity.HasKey(e => e.BrnfeParameterId)
                    .HasName("PK_BRNFeParameters")
                    .IsClustered(false);

                entity.ToTable("MA_BRNFeParameters");

                entity.Property(e => e.BrnfeParameterId)
                    .HasColumnName("BRNFeParameterId")
                    .ValueGeneratedNever();

                entity.Property(e => e.AppendDanfePdf)
                    .HasColumnName("AppendDanfePDF")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CertificateName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CheckAlwaysServiceStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.DanfeCopy).HasDefaultValueSql("((1))");

                entity.Property(e => e.DanfeLineDelimiter)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DanfeLogo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DanfeModelLandscape)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DanfeModelNormal)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DanfePdf)
                    .HasColumnName("DanfePDF")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DanfePhraseContingency)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DanfePhraseHomologation)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultTaxRuleCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirElabInutiliz)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirLog)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirReportTemplate)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirXmlconsignee)
                    .HasColumnName("DirXMLConsignee")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirXmlcontingencyFsda)
                    .HasColumnName("DirXMLContingencyFSDA")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirXmlelabErrForCust)
                    .HasColumnName("DirXMLElabErrForCust")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirXmlelabErrForSupp)
                    .HasColumnName("DirXMLElabErrForSupp")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirXmlelabForCust)
                    .HasColumnName("DirXMLElabForCust")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirXmlelabForSupp)
                    .HasColumnName("DirXMLElabForSupp")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirXmlschema)
                    .HasColumnName("DirXMLSchema")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirXmltoBeElabForCust)
                    .HasColumnName("DirXMLToBeElabForCust")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirXmltoBeElabForSupp)
                    .HasColumnName("DirXMLToBeElabForSupp")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EditXmltoBeElabPath)
                    .HasColumnName("EditXMLToBeElabPath")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EmailAutentication)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.EmailPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmailPort).HasDefaultValueSql("((0))");

                entity.Property(e => e.EmailServer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmailTimeOut).HasDefaultValueSql("((30000))");

                entity.Property(e => e.EmailUser)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Environment).HasDefaultValueSql("((0))");

                entity.Property(e => e.FileHomologation)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FileProduction)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HomologationCustomerName)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IgnoreInvalidCertificate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaxSizeLotSend).HasDefaultValueSql("((500))");

                entity.Property(e => e.NoAttempts).HasDefaultValueSql("((1))");

                entity.Property(e => e.NotaFiscalCodeDefCust)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotaFiscalCodeDefSupp)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProxyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProxyPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProxyTimeOut).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProxyUser)
                    .HasMaxLength(50)
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

                entity.Property(e => e.Timezone)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValidateSchemaBeforeShipping)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Version)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaBrnfeParametersDetails>(entity =>
{
                entity.HasKey(e => new { e.BrnfeParameterId, e.SubId })
                    .HasName("PK_BRNFeParametersDetails")
                    .IsClustered(false);

                entity.ToTable("MA_BRNFeParametersDetails");

                entity.Property(e => e.BrnfeParameterId).HasColumnName("BRNFeParameterId");

                entity.Property(e => e.FiscalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsocountryCode)
                    .HasColumnName("ISOCountryCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NaturalPerson)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxIdNumber)
                    .HasMaxLength(20)
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
            modelBuilder.Entity<MaBrnotaFiscalForCustDetail>(entity =>
{
                entity.HasKey(e => new { e.SaleDocId, e.Line })
                    .HasName("PK_BRNotaFiscalForCustDetail")
                    .IsClustered(false);

                entity.ToTable("MA_BRNotaFiscalForCustDetail");

                entity.Property(e => e.Cfop)
                    .HasColumnName("CFOP")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cfopcompany)
                    .HasColumnName("CFOPCompany")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CofinsCode)
                    .HasColumnName("COFINS_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CofinsCodeCompany)
                    .HasColumnName("COFINS_CodeCompany")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CofinsPerc)
                    .HasColumnName("COFINS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CofinsTaxable)
                    .HasColumnName("COFINS_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CofinsValue)
                    .HasColumnName("COFINS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Cofinstype)
                    .HasColumnName("COFINSType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.Extipi)
                    .HasColumnName("EXTIPI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GoodsOrigin).HasDefaultValueSql("((0))");

                entity.Property(e => e.IcmsCode)
                    .HasColumnName("ICMS_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsCodeCompany)
                    .HasColumnName("ICMS_CodeCompany")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsMod)
                    .HasColumnName("ICMS_Mod")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IcmsNoTaxReason)
                    .HasColumnName("ICMS_NoTaxReason")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IcmsPerc)
                    .HasColumnName("ICMS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsReductionPerc)
                    .HasColumnName("ICMS_Reduction_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsTaxable)
                    .HasColumnName("ICMS_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsValue)
                    .HasColumnName("ICMS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsdefCode)
                    .HasColumnName("ICMSDef_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsdefPerc)
                    .HasColumnName("ICMSDef_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsdefTaxable)
                    .HasColumnName("ICMSDef_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsdefValue)
                    .HasColumnName("ICMSDef_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsdestPerc)
                    .HasColumnName("ICMSDest_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsdestTaxable)
                    .HasColumnName("ICMSDest_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsdestTempPerc)
                    .HasColumnName("ICMSDest_TempPerc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsdestValue)
                    .HasColumnName("ICMSDest_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsexCode)
                    .HasColumnName("ICMSEx_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsexPerc)
                    .HasColumnName("ICMSEx_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsexTaxable)
                    .HasColumnName("ICMSEx_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsexValue)
                    .HasColumnName("ICMSEx_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsfcpPerc)
                    .HasColumnName("ICMSFCP_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsfcpValue)
                    .HasColumnName("ICMSFCP_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsinterPerc)
                    .HasColumnName("ICMSInter_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsorigValue)
                    .HasColumnName("ICMSOrig_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstCode)
                    .HasColumnName("ICMSST_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsstMod)
                    .HasColumnName("ICMSST_Mod")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IcmsstPerc)
                    .HasColumnName("ICMSST_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstReductionPerc)
                    .HasColumnName("ICMSST_Reduction_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstTaxable)
                    .HasColumnName("ICMSST_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstValue)
                    .HasColumnName("ICMSST_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmssttoBeCompPerc)
                    .HasColumnName("ICMSSTToBeComp_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Icmssttype)
                    .HasColumnName("ICMSSTType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.Icmstype)
                    .HasColumnName("ICMSType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.IiPerc)
                    .HasColumnName("II_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IiTaxable)
                    .HasColumnName("II_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IiValue)
                    .HasColumnName("II_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpiCode)
                    .HasColumnName("IPI_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IpiCodeCompany)
                    .HasColumnName("IPI_CodeCompany")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IpiPerc)
                    .HasColumnName("IPI_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpiTaxable)
                    .HasColumnName("IPI_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpiValue)
                    .HasColumnName("IPI_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpilegalCode)
                    .HasColumnName("IPILegalCode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ipitype)
                    .HasColumnName("IPIType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.MvaPerc)
                    .HasColumnName("MVA_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Ncm)
                    .HasColumnName("NCM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PisCode)
                    .HasColumnName("PIS_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PisCodeCompany)
                    .HasColumnName("PIS_CodeCompany")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PisPerc)
                    .HasColumnName("PIS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PisTaxable)
                    .HasColumnName("PIS_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PisValue)
                    .HasColumnName("PIS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Pistype)
                    .HasColumnName("PISType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.SimplesCode)
                    .HasColumnName("SIMPLES_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SimplesCodeCompany)
                    .HasColumnName("SIMPLES_CodeCompany")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SimplesPerc)
                    .HasColumnName("SIMPLES_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SimplesTaxable)
                    .HasColumnName("SIMPLES_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SimplesValue)
                    .HasColumnName("SIMPLES_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubIdParent).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuframaPerc)
                    .HasColumnName("SUFRAMA_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SuframaTaxable)
                    .HasColumnName("SUFRAMA_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SuframaValue)
                    .HasColumnName("SUFRAMA_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxMessageCode1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxMessageCode2)
                    .HasMaxLength(8)
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

                entity.HasOne(d => d.SaleDoc)
                    .WithMany(p => p.MaBrnotaFiscalForCustDetail)
                    .HasForeignKey(d => d.SaleDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRNFForCustDet_NF_01");
            });
            modelBuilder.Entity<MaBrnotaFiscalForCustRef>(entity =>
{
                entity.HasKey(e => new { e.SaleDocId, e.Line })
                    .HasName("PK_BRNotaFiscalForCustRef")
                    .IsClustered(false);

                entity.ToTable("MA_BRNotaFiscalForCustRef");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.DocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FedStateReg)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiscalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Model)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModelNf)
                    .HasColumnName("ModelNF")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MovementType).HasDefaultValueSql("((1))");

                entity.Property(e => e.NaturalPerson)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NumberCoo)
                    .HasColumnName("NumberCOO")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumberEcf)
                    .HasColumnName("NumberECF")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumberNf)
                    .HasColumnName("NumberNF")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RefKey)
                    .HasMaxLength(44)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Series)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxIdNumber)
                    .HasMaxLength(20)
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

                entity.Property(e => e.ThirdParties)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Type).HasDefaultValueSql("((29229056))");

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.SaleDoc)
                    .WithMany(p => p.MaBrnotaFiscalForCustRef)
                    .HasForeignKey(d => d.SaleDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRNFForCustRef_NF_01");
            });
            modelBuilder.Entity<MaBrnotaFiscalForCustShipping>(entity =>
{
                entity.HasKey(e => e.SaleDocId)
                    .HasName("PK_BRNotaFiscalForCustShipping")
                    .IsClustered(false);

                entity.ToTable("MA_BRNotaFiscalForCustShipping");

                entity.Property(e => e.SaleDocId).ValueGeneratedNever();

                entity.Property(e => e.DeliveryToBranch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeliveryToCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeliveryToType).HasDefaultValueSql("((30736388))");

                entity.Property(e => e.PickUpPointBranch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickUpPointCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickUpPointType).HasDefaultValueSql("((30670851))");

                entity.Property(e => e.ShippingFederalState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingPlace)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificShippingPlace)
                    .HasMaxLength(60)
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
            modelBuilder.Entity<MaBrnotaFiscalForCustSummary>(entity =>
{
                entity.HasKey(e => e.SaleDocId)
                    .HasName("PK_BRNotaFiscalForCustSummary")
                    .IsClustered(false);

                entity.ToTable("MA_BRNotaFiscalForCustSummary");

                entity.Property(e => e.SaleDocId).ValueGeneratedNever();

                entity.Property(e => e.AdvancePymtAccount)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdvancePymtCash)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CofinsValue)
                    .HasColumnName("COFINS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DeductionIss)
                    .HasColumnName("DeductionISS")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DeductionReason)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsValue)
                    .HasColumnName("ICMS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsdefValue)
                    .HasColumnName("ICMSDef_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsdestValue)
                    .HasColumnName("ICMSDest_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsexValue)
                    .HasColumnName("ICMSEx_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsfcpValue)
                    .HasColumnName("ICMSFCP_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsorigValue)
                    .HasColumnName("ICMSOrig_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstValue)
                    .HasColumnName("ICMSST_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmssttotTaxableValue)
                    .HasColumnName("ICMSSTTotTaxable_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmstotTaxableValue)
                    .HasColumnName("ICMSTotTaxable_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IiValue)
                    .HasColumnName("II_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InsuranceCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InsuranceChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.IpiValue)
                    .HasColumnName("IPI_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IsstaxRateCode)
                    .HasColumnName("ISSTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsstaxRateCodeIsAuto)
                    .HasColumnName("ISSTaxRateCodeIsAuto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PisValue)
                    .HasColumnName("PIS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesCofinsPerc)
                    .HasColumnName("Services_COFINS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesCofinsValue)
                    .HasColumnName("Services_COFINS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesCofinsValueIsAuto)
                    .HasColumnName("Services_COFINS_Value_IsAuto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ServicesCsPerc)
                    .HasColumnName("Services_CS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesCsValue)
                    .HasColumnName("Services_CS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesCsValueIsAuto)
                    .HasColumnName("Services_CS_Value_IsAuto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ServicesInssPerc)
                    .HasColumnName("Services_INSS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesInssValue)
                    .HasColumnName("Services_INSS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesInssValueIsAuto)
                    .HasColumnName("Services_INSS_Value_IsAuto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ServicesIrPerc)
                    .HasColumnName("Services_IR_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesIrValue)
                    .HasColumnName("Services_IR_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesIrValueIsAuto)
                    .HasColumnName("Services_IR_Value_IsAuto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ServicesIssPerc)
                    .HasColumnName("Services_ISS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesIssValue)
                    .HasColumnName("Services_ISS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesPisPerc)
                    .HasColumnName("Services_PIS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesPisValue)
                    .HasColumnName("Services_PIS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesPisValueIsAuto)
                    .HasColumnName("Services_PIS_Value_IsAuto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SimplesValue)
                    .HasColumnName("SIMPLES_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SuframaValue)
                    .HasColumnName("SUFRAMA_Value")
                    .HasDefaultValueSql("((0.00))");

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

                entity.HasOne(d => d.SaleDoc)
                    .WithOne(p => p.MaBrnotaFiscalForCustSummary)
                    .HasForeignKey<MaBrnotaFiscalForCustSummary>(d => d.SaleDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRNFForCustSummary_NF_01");
            });
            modelBuilder.Entity<MaBrnotaFiscalForCustomer>(entity =>
{
                entity.HasKey(e => e.SaleDocId)
                    .HasName("PK_BRNotaFiscalForCustomer")
                    .IsClustered(false);

                entity.ToTable("MA_BRNotaFiscalForCustomer");

                entity.Property(e => e.SaleDocId).ValueGeneratedNever();

                entity.Property(e => e.ApproxTaxesMsg)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CancReason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChNfe)
                    .HasColumnName("ChNFe")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConsultDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CustPresenceIndicator).HasDefaultValueSql("((30277632))");

                entity.Property(e => e.DocDateNfservices)
                    .HasColumnName("DocDateNFServices")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocNoNfservices)
                    .HasColumnName("DocNoNFServices")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnableApproxTaxesMsg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EnableNfeRef)
                    .HasColumnName("EnableNFeRef")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EnableOrigDest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExcludeElectrTransm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExcludedFromTot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FiscalMessage)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImportDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InventoryAdjustId)
                    .HasColumnName("InventoryAdjustID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InventoryReasonAdjust)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Message1)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Message2)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Model)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NProt)
                    .HasColumnName("nProt")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NProtCancNfe)
                    .HasColumnName("nProtCancNFe")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotaFiscalCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Numbered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostedToRomaneio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProcessDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Series)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServiceTypeCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SimplesMsg)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SimplesZeroMsg)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartContingency)
                    .HasMaxLength(20)
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

                entity.Property(e => e.ThirdParties)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.SaleDoc)
                    .WithOne(p => p.MaBrnotaFiscalForCustomer)
                    .HasForeignKey<MaBrnotaFiscalForCustomer>(d => d.SaleDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRNFForCust_NF_01");
            });
            modelBuilder.Entity<MaBrnotaFiscalForSuppDetail>(entity =>
{
                entity.HasKey(e => new { e.PurchaseDocId, e.Line })
                    .HasName("PK_BRNotaFiscalForSuppDetail")
                    .IsClustered(false);

                entity.ToTable("MA_BRNotaFiscalForSuppDetail");

                entity.Property(e => e.Cfop)
                    .HasColumnName("CFOP")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cfopcompany)
                    .HasColumnName("CFOPCompany")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CofinsCode)
                    .HasColumnName("COFINS_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CofinsCodeCompany)
                    .HasColumnName("COFINS_CodeCompany")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CofinsPerc)
                    .HasColumnName("COFINS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CofinsTaxable)
                    .HasColumnName("COFINS_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CofinsValue)
                    .HasColumnName("COFINS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Cofinstype)
                    .HasColumnName("COFINSType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.Extipi)
                    .HasColumnName("EXTIPI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GoodsOrigin).HasDefaultValueSql("((0))");

                entity.Property(e => e.IcmsCode)
                    .HasColumnName("ICMS_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsCodeCompany)
                    .HasColumnName("ICMS_CodeCompany")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsMod)
                    .HasColumnName("ICMS_Mod")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IcmsNoTaxReason)
                    .HasColumnName("ICMS_NoTaxReason")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IcmsPerc)
                    .HasColumnName("ICMS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsReductionPerc)
                    .HasColumnName("ICMS_Reduction_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsTaxable)
                    .HasColumnName("ICMS_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsValue)
                    .HasColumnName("ICMS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsdefCode)
                    .HasColumnName("ICMSDef_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsdefPerc)
                    .HasColumnName("ICMSDef_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsdefTaxable)
                    .HasColumnName("ICMSDef_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsdefValue)
                    .HasColumnName("ICMSDef_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsexCode)
                    .HasColumnName("ICMSEx_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsexPerc)
                    .HasColumnName("ICMSEx_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsexTaxable)
                    .HasColumnName("ICMSEx_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsexValue)
                    .HasColumnName("ICMSEx_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstCode)
                    .HasColumnName("ICMSST_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsstMod)
                    .HasColumnName("ICMSST_Mod")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IcmsstPerc)
                    .HasColumnName("ICMSST_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstReductionPerc)
                    .HasColumnName("ICMSST_Reduction_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstTaxable)
                    .HasColumnName("ICMSST_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstValue)
                    .HasColumnName("ICMSST_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmssttoBeCompPerc)
                    .HasColumnName("ICMSSTToBeComp_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Icmssttype)
                    .HasColumnName("ICMSSTType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.Icmstype)
                    .HasColumnName("ICMSType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.IiPerc)
                    .HasColumnName("II_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IiTaxable)
                    .HasColumnName("II_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IiValue)
                    .HasColumnName("II_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpiCode)
                    .HasColumnName("IPI_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IpiCodeCompany)
                    .HasColumnName("IPI_CodeCompany")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IpiPerc)
                    .HasColumnName("IPI_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpiTaxable)
                    .HasColumnName("IPI_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpiValue)
                    .HasColumnName("IPI_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IpilegalCode)
                    .HasColumnName("IPILegalCode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ipitype)
                    .HasColumnName("IPIType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.MvaPerc)
                    .HasColumnName("MVA_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Ncm)
                    .HasColumnName("NCM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PisCode)
                    .HasColumnName("PIS_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PisCodeCompany)
                    .HasColumnName("PIS_CodeCompany")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PisPerc)
                    .HasColumnName("PIS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PisTaxable)
                    .HasColumnName("PIS_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PisValue)
                    .HasColumnName("PIS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Pistype)
                    .HasColumnName("PISType")
                    .HasDefaultValueSql("((31260672))");

                entity.Property(e => e.SimplesCode)
                    .HasColumnName("SIMPLES_Code")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SimplesCodeCompany)
                    .HasColumnName("SIMPLES_CodeCompany")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SimplesPerc)
                    .HasColumnName("SIMPLES_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SimplesTaxable)
                    .HasColumnName("SIMPLES_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SimplesValue)
                    .HasColumnName("SIMPLES_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubIdParent).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuframaPerc)
                    .HasColumnName("SUFRAMA_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SuframaTaxable)
                    .HasColumnName("SUFRAMA_Taxable")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SuframaValue)
                    .HasColumnName("SUFRAMA_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxMessageCode1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxMessageCode2)
                    .HasMaxLength(8)
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

                entity.HasOne(d => d.PurchaseDoc)
                    .WithMany(p => p.MaBrnotaFiscalForSuppDetail)
                    .HasForeignKey(d => d.PurchaseDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRNFForSuppDet_NF_01");
            });
            modelBuilder.Entity<MaBrnotaFiscalForSuppRef>(entity =>
{
                entity.HasKey(e => new { e.PurchaseDocId, e.Line })
                    .HasName("PK_BRNotaFiscalForSuppRef")
                    .IsClustered(false);

                entity.ToTable("MA_BRNotaFiscalForSuppRef");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211265))");

                entity.Property(e => e.DocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FedStateReg)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FiscalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Model)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModelNf)
                    .HasColumnName("ModelNF")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MovementType).HasDefaultValueSql("((1))");

                entity.Property(e => e.NaturalPerson)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NumberCoo)
                    .HasColumnName("NumberCOO")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumberEcf)
                    .HasColumnName("NumberECF")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumberNf)
                    .HasColumnName("NumberNF")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RefKey)
                    .HasMaxLength(44)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Series)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxIdNumber)
                    .HasMaxLength(20)
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

                entity.Property(e => e.ThirdParties)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Type).HasDefaultValueSql("((29229056))");

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.PurchaseDoc)
                    .WithMany(p => p.MaBrnotaFiscalForSuppRef)
                    .HasForeignKey(d => d.PurchaseDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRNFForSuppRef_NF_01");
            });
            modelBuilder.Entity<MaBrnotaFiscalForSuppShipping>(entity =>
{
                entity.HasKey(e => e.PurchaseDocId)
                    .HasName("PK_BRNFForSuppShip")
                    .IsClustered(false);

                entity.ToTable("MA_BRNotaFiscalForSuppShipping");

                entity.Property(e => e.PurchaseDocId).ValueGeneratedNever();

                entity.Property(e => e.DeliveryToBranch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeliveryToCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeliveryToType).HasDefaultValueSql("((30736388))");

                entity.Property(e => e.PickUpPointBranch)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickUpPointCode)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickUpPointType).HasDefaultValueSql("((30670851))");

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

                entity.HasOne(d => d.PurchaseDoc)
                    .WithOne(p => p.MaBrnotaFiscalForSuppShipping)
                    .HasForeignKey<MaBrnotaFiscalForSuppShipping>(d => d.PurchaseDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRNFForSuppShip_NF_01");
            });
            modelBuilder.Entity<MaBrnotaFiscalForSuppSummary>(entity =>
{
                entity.HasKey(e => e.PurchaseDocId)
                    .HasName("PK_BRNotaFiscalForSuppSummary")
                    .IsClustered(false);

                entity.ToTable("MA_BRNotaFiscalForSuppSummary");

                entity.Property(e => e.PurchaseDocId).ValueGeneratedNever();

                entity.Property(e => e.AdvancePymtAccount)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdvancePymtCash)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CofinsValue)
                    .HasColumnName("COFINS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DeductionIss)
                    .HasColumnName("DeductionISS")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DeductionReason)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsValue)
                    .HasColumnName("ICMS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsdefValue)
                    .HasColumnName("ICMSDef_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsexValue)
                    .HasColumnName("ICMSEx_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmsstValue)
                    .HasColumnName("ICMSST_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmssttotTaxableValue)
                    .HasColumnName("ICMSSTTotTaxable_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IcmstotTaxableValue)
                    .HasColumnName("ICMSTotTaxable_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IiValue)
                    .HasColumnName("II_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InsuranceCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InsuranceChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.IpiValue)
                    .HasColumnName("IPI_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.IsstaxRateCode)
                    .HasColumnName("ISSTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsstaxRateCodeIsAuto)
                    .HasColumnName("ISSTaxRateCodeIsAuto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PisValue)
                    .HasColumnName("PIS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesCofinsPerc)
                    .HasColumnName("Services_COFINS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesCofinsValue)
                    .HasColumnName("Services_COFINS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesCofinsValueIsAuto)
                    .HasColumnName("Services_COFINS_Value_IsAuto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ServicesCsPerc)
                    .HasColumnName("Services_CS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesCsValue)
                    .HasColumnName("Services_CS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesCsValueIsAuto)
                    .HasColumnName("Services_CS_Value_IsAuto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ServicesInssPerc)
                    .HasColumnName("Services_INSS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesInssValue)
                    .HasColumnName("Services_INSS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesInssValueIsAuto)
                    .HasColumnName("Services_INSS_Value_IsAuto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ServicesIrPerc)
                    .HasColumnName("Services_IR_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesIrValue)
                    .HasColumnName("Services_IR_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesIrValueIsAuto)
                    .HasColumnName("Services_IR_Value_IsAuto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ServicesIssPerc)
                    .HasColumnName("Services_ISS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesIssValue)
                    .HasColumnName("Services_ISS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesPisPerc)
                    .HasColumnName("Services_PIS_Perc")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesPisValue)
                    .HasColumnName("Services_PIS_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServicesPisValueIsAuto)
                    .HasColumnName("Services_PIS_Value_IsAuto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SimplesValue)
                    .HasColumnName("SIMPLES_Value")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SuframaValue)
                    .HasColumnName("SUFRAMA_Value")
                    .HasDefaultValueSql("((0.00))");

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

                entity.HasOne(d => d.PurchaseDoc)
                    .WithOne(p => p.MaBrnotaFiscalForSuppSummary)
                    .HasForeignKey<MaBrnotaFiscalForSuppSummary>(d => d.PurchaseDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRNFForSuppSummary_NF_01");
            });
            modelBuilder.Entity<MaBrnotaFiscalForSupplier>(entity =>
{
                entity.HasKey(e => e.PurchaseDocId)
                    .HasName("PK_BRNotaFiscalForSuppomer")
                    .IsClustered(false);

                entity.ToTable("MA_BRNotaFiscalForSupplier");

                entity.Property(e => e.PurchaseDocId).ValueGeneratedNever();

                entity.Property(e => e.ApproxTaxesMsg)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CancReason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChNfe)
                    .HasColumnName("ChNFe")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConsultDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CustPresenceIndicator).HasDefaultValueSql("((30277632))");

                entity.Property(e => e.DocDateNfservices)
                    .HasColumnName("DocDateNFServices")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocNoNfservices)
                    .HasColumnName("DocNoNFServices")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EnableApproxTaxesMsg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EnableNfeRef)
                    .HasColumnName("EnableNFeRef")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EnableOrigDest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExcludeElectrTransm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExcludedFromTot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FiscalMessage)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImportDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InventoryAdjustId)
                    .HasColumnName("InventoryAdjustID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InventoryReasonAdjust)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Message1)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Message2)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Model)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NProt)
                    .HasColumnName("nProt")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NProtCancNfe)
                    .HasColumnName("nProtCancNFe")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotaFiscalCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Numbered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostedToRomaneio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProcessDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Series)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServiceTypeCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SimplesMsg)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SimplesZeroMsg)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartContingency)
                    .HasMaxLength(20)
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

                entity.Property(e => e.ThirdParties)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.PurchaseDoc)
                    .WithOne(p => p.MaBrnotaFiscalForSupplier)
                    .HasForeignKey<MaBrnotaFiscalForSupplier>(d => d.PurchaseDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRNFForSupp_NF_01");
            });
            modelBuilder.Entity<MaBrnotaFiscalNumbers>(entity =>
{
                entity.HasKey(e => new { e.Series, e.Model })
                    .HasName("PK_BRNotaFiscalNumbers")
                    .IsClustered(false);

                entity.ToTable("MA_BRNotaFiscalNumbers");

                entity.Property(e => e.Series)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.LastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastNo).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaBrnotaFiscalType>(entity =>
{
                entity.HasKey(e => e.NotaFiscalCode)
                    .HasName("PK_BRNotaFiscalType")
                    .IsClustered(false);

                entity.ToTable("MA_BRNotaFiscalType");

                entity.Property(e => e.NotaFiscalCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AdditionalCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Advance)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdvanceAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ApproxTaxesMsg)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AutoNumbering)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Cfopgroup)
                    .HasColumnName("CFOPGroup")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustPresenceIndicator).HasDefaultValueSql("((30277632))");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((0))");

                entity.Property(e => e.DanfetypePrint)
                    .HasColumnName("DANFETypePrint")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DistributeChargesByLines)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.EnableApproxTaxesMsg)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EnableNfeRef)
                    .HasColumnName("EnableNFeRef")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EnableOrigDest)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExcludeElectrTransm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExcludedFromTot)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ForGoods)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.FreeSamplesAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FreeSamplesAmount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodsAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IncludedInTurnover).HasDefaultValueSql("((29556736))");

                entity.Property(e => e.InsuranceCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryReason)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InventoryReasonAdjust)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsstaxRateCode)
                    .HasColumnName("ISSTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Message1)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Message2)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Model)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MovementType).HasDefaultValueSql("((0))");

                entity.Property(e => e.NfeIssuingPurpose)
                    .HasColumnName("NFeIssuingPurpose")
                    .HasDefaultValueSql("((29949952))");

                entity.Property(e => e.NotaFiscalAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotaFiscalAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OperationType).HasDefaultValueSql("((0))");

                entity.Property(e => e.Series)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServicesAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SimplesMsg)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SimplesZeroMsg)
                    .HasMaxLength(256)
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
            modelBuilder.Entity<MaBrnotaFiscalTypeDetail>(entity =>
{
                entity.HasKey(e => new { e.NotaFiscalCode, e.Line })
                    .HasName("PK_BRNotaFiscalTypeDetail")
                    .IsClustered(false);

                entity.ToTable("MA_BRNotaFiscalTypeDetail");

                entity.Property(e => e.NotaFiscalCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

                entity.Property(e => e.Series)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
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

                entity.HasOne(d => d.NotaFiscalCodeNavigation)
                    .WithMany(p => p.MaBrnotaFiscalTypeDetail)
                    .HasForeignKey(d => d.NotaFiscalCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRNotaFiscalTypeDetail_00");
            });
            modelBuilder.Entity<MaBrnve>(entity =>
{
                entity.HasKey(e => e.Nve)
                    .HasName("PK_BRNVE")
                    .IsClustered(false);

                entity.ToTable("MA_BRNVE");

                entity.Property(e => e.Nve)
                    .HasColumnName("NVE")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
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
            modelBuilder.Entity<MaBrromaneio>(entity =>
{
                entity.HasKey(e => e.RomaneioId)
                    .HasName("PK_BRRomaneio")
                    .IsClustered(false);

                entity.ToTable("MA_BRRomaneio");

                entity.Property(e => e.RomaneioId).ValueGeneratedNever();

                entity.Property(e => e.ArrivalDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ArrivalKm).HasDefaultValueSql("((0))");

                entity.Property(e => e.DepartureDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DepartureKm).HasDefaultValueSql("((0))");

                entity.Property(e => e.Driver).HasDefaultValueSql("('')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastSubIdPauses).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastSubIdRefuel).HasDefaultValueSql("((0))");

                entity.Property(e => e.RomaneioDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.RomaneioNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Status).HasDefaultValueSql("((29818880))");

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

                entity.Property(e => e.Tractor)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Trailer)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaBrromaneioDetail>(entity =>
{
                entity.HasKey(e => new { e.RomaneioId, e.RomaneioSubId })
                    .HasName("PK_BRRomaneioDetail")
                    .IsClustered(false);

                entity.ToTable("MA_BRRomaneioDetail");

                entity.Property(e => e.ArrivalTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.DeliveryOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.DepartureTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Event)
                    .HasMaxLength(60)
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
            modelBuilder.Entity<MaBrromaneioExpenses>(entity =>
{
                entity.HasKey(e => e.RomaneioId)
                    .HasName("PK_BRRomaneioExpenses")
                    .IsClustered(false);

                entity.ToTable("MA_BRRomaneioExpenses");

                entity.Property(e => e.RomaneioId).ValueGeneratedNever();

                entity.Property(e => e.ActualValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EndingCash).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.EstimatedValue).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Fuel).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Mainteinance).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Meals).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.OtherCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Overnight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StartingCash).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.Tolls).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalRefLiters).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Variation).HasDefaultValueSql("((0.00))");
            });
            modelBuilder.Entity<MaBrromaneioNotes>(entity =>
{
                entity.HasKey(e => e.RomaneioId)
                    .HasName("PK_BRRomaneioNotes")
                    .IsClustered(false);

                entity.ToTable("MA_BRRomaneioNotes");

                entity.Property(e => e.RomaneioId).ValueGeneratedNever();

                entity.Property(e => e.Notes)
                    .HasMaxLength(251)
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
            modelBuilder.Entity<MaBrromaneioPausesDetail>(entity =>
{
                entity.HasKey(e => new { e.RomaneioId, e.RomaneioSubId })
                    .HasName("PK_BRRomaneioPausesDetail")
                    .IsClustered(false);

                entity.ToTable("MA_BRRomaneioPausesDetail");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Reason)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartTime)
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
            modelBuilder.Entity<MaBrromaneioRefuellingDetail>(entity =>
{
                entity.HasKey(e => new { e.RomaneioId, e.RomaneioSubId })
                    .HasName("PK_BRRomaneioRefuellingDetail")
                    .IsClustered(false);

                entity.ToTable("MA_BRRomaneioRefuellingDetail");

                entity.Property(e => e.RefuellingCost).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.RefuellingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.RefuellingQty).HasDefaultValueSql("((0.00))");

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
            modelBuilder.Entity<MaBrromaneioSummary>(entity =>
{
                entity.HasKey(e => e.RomaneioId)
                    .HasName("PK_BRRomaneioSummary")
                    .IsClustered(false);

                entity.ToTable("MA_BRRomaneioSummary");

                entity.Property(e => e.RomaneioId).ValueGeneratedNever();

                entity.Property(e => e.GrossTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.InboundNetWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NetTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.OutboundNetWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShipBackWay).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShipOutwardVoyage).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShipTotCharges).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.TheoreticalTotWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotNoOfPacks).HasDefaultValueSql("((0))");

                entity.Property(e => e.TotVolumM3).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TotalKm).HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<MaBrseries>(entity =>
{
                entity.HasKey(e => new { e.Series, e.Model })
                    .HasName("PK_BRSeries")
                    .IsClustered(false);

                entity.ToTable("MA_BRSeries");

                entity.Property(e => e.Series)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
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
            modelBuilder.Entity<MaBrseriesUnusedNumbersDetail>(entity =>
{
                entity.HasKey(e => new { e.Series, e.Model, e.FromNumber, e.ToNumber, e.OperationDate })
                    .HasName("PK_BRSeriesUnusedNumbersDetail")
                    .IsClustered(false);

                entity.ToTable("MA_BRSeriesUnusedNumbersDetail");

                entity.Property(e => e.Series)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FromNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ToNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OperationDate).HasColumnType("datetime");

                entity.Property(e => e.AnswerStatus)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AnswerStatusDescri)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AuthProtocol)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EasyAttachId)
                    .HasColumnName("EasyAttachID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ElabDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InutReason)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MagoUserId)
                    .HasColumnName("MagoUserID")
                    .HasMaxLength(50)
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
            modelBuilder.Entity<MaBrserviceTypes>(entity =>
{
                entity.HasKey(e => e.ServiceTypeCode)
                    .HasName("PK_BRServiceTypes")
                    .IsClustered(false);

                entity.ToTable("MA_BRServiceTypes");

                entity.Property(e => e.ServiceTypeCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
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
            modelBuilder.Entity<MaBrserviceTypesDetail>(entity =>
{
                entity.HasKey(e => new { e.ServiceTypeCode, e.TaxRateType })
                    .HasName("PK_BRServiceTypesDetail")
                    .IsClustered(false);

                entity.ToTable("MA_BRServiceTypesDetail");

                entity.Property(e => e.ServiceTypeCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.TaxRateCode)
                    .HasMaxLength(8)
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

                entity.HasOne(d => d.ServiceTypeCodeNavigation)
                    .WithMany(p => p.MaBrserviceTypesDetail)
                    .HasForeignKey(d => d.ServiceTypeCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BRServiceTypesDetail_00");
            });
            modelBuilder.Entity<MaBrspedparameters>(entity =>
{
                entity.HasKey(e => e.BrspedparametersId)
                    .HasName("PK_BRSPEDParameters")
                    .IsClustered(false);

                entity.ToTable("MA_BRSPEDParameters");

                entity.Property(e => e.BrspedparametersId)
                    .HasColumnName("BRSPEDParametersId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Accountant)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccountantFiscalCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccountantRegisterNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ActivityType).HasDefaultValueSql("((31391744))");

                entity.Property(e => e.DeclarationType).HasDefaultValueSql("((31326208))");

                entity.Property(e => e.IcmsreceiptsCode)
                    .HasColumnName("ICMSReceiptsCode")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsstreceiptsCode)
                    .HasColumnName("ICMSSTReceiptsCode")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpedconfigFilePath)
                    .HasColumnName("SPEDConfigFilePath")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpedfilePath)
                    .HasColumnName("SPEDFilePath")
                    .HasMaxLength(250)
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
            modelBuilder.Entity<MaBrtaxCalc>(entity =>
{
                entity.HasKey(e => new { e.TaxCalcCode, e.TaxType, e.ValidityStartingDate })
                    .HasName("PK_BRTaxCalc")
                    .IsClustered(false);

                entity.ToTable("MA_BRTaxCalc");

                entity.Property(e => e.TaxCalcCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityStartingDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReducTaxRateCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxFormulaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxRateCode)
                    .HasMaxLength(8)
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

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaBrtaxCode>(entity =>
{
                entity.HasKey(e => new { e.TaxCode, e.TaxType, e.ValidityStartingDate })
                    .HasName("PK_BRTaxCode")
                    .IsClustered(false);

                entity.ToTable("MA_BRTaxCode");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityStartingDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Issue)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Receipt)
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

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaBrtaxFormula>(entity =>
{
                entity.HasKey(e => new { e.TaxFormulaCode, e.TaxType, e.ValidityStartingDate })
                    .HasName("PK_BRTaxFormula")
                    .IsClustered(false);

                entity.ToTable("MA_BRTaxFormula");

                entity.Property(e => e.TaxFormulaCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityStartingDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxAmountFormula)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxableAmountFormula)
                    .HasMaxLength(500)
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

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaBrtaxMessages>(entity =>
{
                entity.HasKey(e => e.TaxMessageCode)
                    .HasName("PK_BRTaxMessages")
                    .IsClustered(false);

                entity.ToTable("MA_BRTaxMessages");

                entity.Property(e => e.TaxMessageCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description2)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description3)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LongDescription)
                    .HasMaxLength(1000)
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
            modelBuilder.Entity<MaBrtaxRate>(entity =>
{
                entity.HasKey(e => new { e.TaxRateCode, e.TaxType, e.ValidityStartingDate })
                    .HasName("PK_BRTaxRate")
                    .IsClustered(false);

                entity.ToTable("MA_BRTaxRate");

                entity.Property(e => e.TaxRateCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityStartingDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotTaxable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxRate).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.Thresold).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaBrtaxRateDetail>(entity =>
{
                entity.HasKey(e => new { e.TaxRateCode, e.TaxType, e.ValidityStartingDate, e.Line })
                    .HasName("PK_BRTaxRateDetail")
                    .IsClustered(false);

                entity.ToTable("MA_BRTaxRateDetail");

                entity.Property(e => e.TaxRateCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityStartingDate).HasColumnType("datetime");

                entity.Property(e => e.MaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.MinAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxRate).HasDefaultValueSql("((0.00))");

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
            modelBuilder.Entity<MaBrtaxRules>(entity =>
{
                entity.HasKey(e => new { e.TaxRuleCode, e.ValidityStartingDate })
                    .HasName("PK_BRTaxRules")
                    .IsClustered(false);

                entity.ToTable("MA_BRTaxRules");

                entity.Property(e => e.TaxRuleCode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityStartingDate).HasColumnType("datetime");

                entity.Property(e => e.AllItems)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Cfop)
                    .HasColumnName("CFOP")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CofinscalcCode)
                    .HasColumnName("COFINSCalcCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppFiscalCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DistributeCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ExcludeIcmsst)
                    .HasColumnName("ExcludeICMSST")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Extipi)
                    .HasColumnName("EXTIPI")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FederalState)
                    .HasMaxLength(108)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodsOrigin).HasDefaultValueSql("((0))");

                entity.Property(e => e.IcmsMod)
                    .HasColumnName("ICMS_Mod")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IcmsNoTaxReason)
                    .HasColumnName("ICMS_NoTaxReason")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IcmsdefTaxFormulaCode)
                    .HasColumnName("ICMSDefTaxFormulaCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsdefTaxRateCode)
                    .HasColumnName("ICMSDefTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsdestTaxFormulaCode)
                    .HasColumnName("ICMSDestTaxFormulaCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsdestTaxRateCode)
                    .HasColumnName("ICMSDestTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsdestTempRateCode)
                    .HasColumnName("ICMSDestTempRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsexTaxFormulaCode)
                    .HasColumnName("ICMSExTaxFormulaCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsexTaxRateCode)
                    .HasColumnName("ICMSExTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsfcptaxFormulaCode)
                    .HasColumnName("ICMSFCPTaxFormulaCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsfcptaxRateCode)
                    .HasColumnName("ICMSFCPTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsinterTaxRateCode)
                    .HasColumnName("ICMSInterTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsorigTaxFormulaCode)
                    .HasColumnName("ICMSOrigTaxFormulaCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsreducTaxRateCode)
                    .HasColumnName("ICMSReducTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmsstMod)
                    .HasColumnName("ICMSST_Mod")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IcmsstreducTaxRateCode)
                    .HasColumnName("ICMSSTReducTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmssttaxFormulaCode)
                    .HasColumnName("ICMSSTTaxFormulaCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmssttaxRateCode)
                    .HasColumnName("ICMSSTTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmssttoBeCompTaxRateCode)
                    .HasColumnName("ICMSSTToBeCompTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmstaxCode)
                    .HasColumnName("ICMSTaxCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmstaxFormulaCode)
                    .HasColumnName("ICMSTaxFormulaCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IcmstaxRateCode)
                    .HasColumnName("ICMSTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IitaxFormulaCode)
                    .HasColumnName("IITaxFormulaCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IitaxRateCode)
                    .HasColumnName("IITaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IpicalcCode)
                    .HasColumnName("IPICalcCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IpilegalCode)
                    .HasColumnName("IPILegalCode")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemFiscalCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MovementType).HasDefaultValueSql("((0))");

                entity.Property(e => e.MvataxRateCode)
                    .HasColumnName("MVATaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Ncm)
                    .HasColumnName("NCM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PiscalcCode)
                    .HasColumnName("PISCalcCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

                entity.Property(e => e.SimplescalcCode)
                    .HasColumnName("SIMPLESCalcCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuframacalcCode)
                    .HasColumnName("SUFRAMACalcCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxMessageCode1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxMessageCode2)
                    .HasMaxLength(8)
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

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaBrvehicle>(entity =>
{
                entity.HasKey(e => e.Code)
                    .HasName("PK_BRVehicle")
                    .IsClustered(false);

                entity.ToTable("MA_BRVehicle");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CapacityKg).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CapacityM3).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EngineSize)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FrameNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FuelType).HasDefaultValueSql("((29753344))");

                entity.Property(e => e.LicensePlate)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Property).HasDefaultValueSql("((29687808))");

                entity.Property(e => e.RegFederalState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RegYear).HasDefaultValueSql("('')");

                entity.Property(e => e.Rntc)
                    .HasColumnName("RNTC")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TareWeightKg).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.VehicleType).HasDefaultValueSql("((29622272))");
            });
            modelBuilder.Entity<MaCustSuppBrtaxes>(entity =>
{
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp })
                    .HasName("PK_CustSuppBRTaxes")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppBRTaxes");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CofinswithHoldingTax)
                    .HasColumnName("COFINSWithHoldingTax")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CswithHoldingTax)
                    .HasColumnName("CSWithHoldingTax")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InsswithHoldingTax)
                    .HasColumnName("INSSWithHoldingTax")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IrwithHoldingTax)
                    .HasColumnName("IRWithHoldingTax")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsstaxRateCode)
                    .HasColumnName("ISSTaxRateCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsswithHoldingTax)
                    .HasColumnName("ISSWithHoldingTax")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PiswithHoldingTax)
                    .HasColumnName("PISWithHoldingTax")
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
            modelBuilder.Entity<MaItemsBrfiscalCtg>(entity =>
{
                entity.HasKey(e => new { e.Item, e.ItemFiscalCtg })
                    .HasName("PK_ItemsBRFiscalCtg")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsBRFiscalCtg");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ItemFiscalCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false);

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

                entity.HasOne(d => d.ItemFiscalCtgNavigation)
                    .WithMany(p => p.MaItemsBrfiscalCtg)
                    .HasForeignKey(d => d.ItemFiscalCtg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsBRFCtg_ItemsFCtg_00");
            });
            modelBuilder.Entity<MaItemsBrtaxes>(entity =>
{
                entity.HasKey(e => e.Item)
                    .HasName("PK_ItemsBRTaxes")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsBRTaxes");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Anp)
                    .HasColumnName("ANP")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ApproxTaxesDomesticPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ApproxTaxesImportPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Cest)
                    .HasColumnName("CEST")
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemType).HasDefaultValueSql("((31719424))");

                entity.Property(e => e.MunApproxTaxesDomesticPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.MunApproxTaxesImportPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Ncm)
                    .HasColumnName("NCM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nve)
                    .HasColumnName("NVE")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServiceTypeCode)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StateApproxTaxesDomesticPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StateApproxTaxesImportPerc).HasDefaultValueSql("((0.00))");

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
