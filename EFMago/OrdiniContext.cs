using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

//Ultimo adeguamento mago.net 3.14.21
//Personalizzazioni
//  ALL_SPA - Ordini - 9

// studio https://stackoverflow.com/questions/61644773/entity-framework-modelbuilder-in-two-different-files

namespace EFMago.Models
{
    public partial class OrdiniContext : DbContext
    {
        public OrdiniContext()
        {
        }

        public OrdiniContext(DbContextOptions<OrdiniContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allattivita> Allattivita { get; set; }
        public virtual DbSet<Allcespiti> Allcespiti { get; set; }
        public virtual DbSet<Alldescrizioni> Alldescrizioni { get; set; }
        public virtual DbSet<AllordCliAcc> AllordCliAcc { get; set; }
        public virtual DbSet<AllordCliAttivita> AllordCliAttivita { get; set; }
        public virtual DbSet<AllordCliContratto> AllordCliContratto { get; set; }
        public virtual DbSet<AllordCliContrattoDescFatt> AllordCliContrattoDescFatt { get; set; }
        public virtual DbSet<AllordCliContrattoDistinta> AllordCliContrattoDistinta { get; set; }
        public virtual DbSet<AllordCliContrattoDistintaServAgg> AllordCliContrattoDistintaServAgg { get; set; }
        public virtual DbSet<AllordCliContrattoDistintaServAgg> AllordCliContrattoDistCesp { get; set; }
        public virtual DbSet<AllordCliDescrizioni> AllordCliDescrizioni { get; set; }
        public virtual DbSet<AllordCliTipologiaServizi> AllordCliTipologiaServizi { get; set; }
        public virtual DbSet<AllordCliFattEle> AllordCliFattEle { get; set; }
        public virtual DbSet<AllordFiglio> AllordFiglio { get; set; }
        public virtual DbSet<AllordPadre> AllordPadre { get; set; }
        public virtual DbSet<AlltipoRigaServizio> AlltipoRigaServizio { get; set; }
        #region blocco Clienti
        public virtual DbSet<MaCustomerClassification> MaCustomerClassification { get; set; }
        public virtual DbSet<MaCustomerCtg> MaCustomerCtg { get; set; }
        public virtual DbSet<MaCustomerSpecification> MaCustomerSpecification { get; set; }
        public virtual DbSet<MaCustSupp> MaCustSupp { get; set; }
        public virtual DbSet<MaCustSuppBalances> MaCustSuppBalances { get; set; }
        public virtual DbSet<MaCustSuppBlackList> MaCustSuppBlackList { get; set; }
        public virtual DbSet<MaCustSuppBranches> MaCustSuppBranches { get; set; }
        public virtual DbSet<MaCustSuppBudget> MaCustSuppBudget { get; set; }
        public virtual DbSet<MaCustSuppCircularLetters> MaCustSuppCircularLetters { get; set; }
        public virtual DbSet<MaCustSuppCustomerOptions> MaCustSuppCustomerOptions { get; set; }
        public virtual DbSet<MaCustSuppForm> MaCustSuppForm { get; set; }
        public virtual DbSet<MaCustSuppFormCategory> MaCustSuppFormCategory { get; set; }
        public virtual DbSet<MaCustSuppNaturalPerson> MaCustSuppNaturalPerson { get; set; }
        public virtual DbSet<MaCustSuppNotes> MaCustSuppNotes { get; set; }
        public virtual DbSet<MaCustSuppOutstandings> MaCustSuppOutstandings { get; set; }
        public virtual DbSet<MaCustSuppParameters> MaCustSuppParameters { get; set; }
        public virtual DbSet<MaCustSuppPeople> MaCustSuppPeople { get; set; }
        public virtual DbSet<MaCustSuppSupplierOptions> MaCustSuppSupplierOptions { get; set; }
        public virtual DbSet<MaDeclarationOfIntent> MaDeclarationOfIntent { get; set; }
        public virtual DbSet<MaDeclarationOfIntentNumbers> MaDeclarationOfIntentNumbers { get; set; }
        public virtual DbSet<MaPlafond> MaPlafond { get; set; }
        public virtual DbSet<MaSddmandate> MaSddmandate { get; set; }
        public virtual DbSet<ImCustSuppPolicies> ImCustSuppPolicies { get; set; }
        public virtual DbSet<ImSuppliersDiscounts> ImSuppliersDiscounts { get; set; }
        public virtual DbSet<MaCreditCustomer> MaCreditCustomer { get; set; }
        public virtual DbSet<MaCreditCustomerDocument> MaCreditCustomerDocument { get; set; }
        #endregion
        #region Blocco Articoli
        public virtual DbSet<MaItems> MaItems { get; set; }
        public virtual DbSet<MaItemsGoodsData> MaItemsGoodsData { get; set; }
        //
        public virtual DbSet<MaItemsIntrastat> MaItemsIntrastat { get; set; }
        public virtual DbSet<MaItemsManufacturingData> MaItemsManufacturingData { get; set; }
        public virtual DbSet<MaItemNotes> MaItemNotes { get; set; }
        public virtual DbSet<MaItemsComparableUoM> MaItemsComparableUoM { get; set; }
        public virtual DbSet<MaItemsFifo> MaItemsFifo { get; set; }
        public virtual DbSet<MaItemsFifodomCurr> MaItemsFifodomCurr { get; set; }
        public virtual DbSet<MaItemsFiscalData> MaItemsFiscalData { get; set; }
        public virtual DbSet<MaItemsFiscalDataDomCurr> MaItemsFiscalDataDomCurr { get; set; }
        public virtual DbSet<MaItemsKit> MaItemsKit { get; set; }
        public virtual DbSet<MaItemsLanguageDescri> MaItemsLanguageDescri { get; set; }
        public virtual DbSet<MaItemsLifo> MaItemsLifo { get; set; }
        public virtual DbSet<MaItemsLifodomCurr> MaItemsLifodomCurr { get; set; }
        public virtual DbSet<MaItemsMonthlyBalances> MaItemsMonthlyBalances { get; set; }
        public virtual DbSet<MaItemsPriceLists> MaItemsPriceLists { get; set; }
        public virtual DbSet<MaItemsPurchaseBarCode> MaItemsPurchaseBarCode { get; set; }
        public virtual DbSet<MaItemsStorageQty> MaItemsStorageQty { get; set; }
        public virtual DbSet<MaItemsStorageQtyMonthly> MaItemsStorageQtyMonthly { get; set; }
        public virtual DbSet<MaItemsSubstitute> MaItemsSubstitute { get; set; }
        public virtual DbSet<MaItemsWmszones> MaItemsWmszones { get; set; }
        public virtual DbSet<MaStandardCostHistorical> MaStandardCostHistorical { get; set; }
        #endregion
        #region Blocco Ordini
        public virtual DbSet<MaSaleOrd> MaSaleOrd { get; set; }
        public virtual DbSet<MaSaleOrdComponents> MaSaleOrdComponents { get; set; }
        public virtual DbSet<MaSaleOrdDetails> MaSaleOrdDetails { get; set; }
        public virtual DbSet<MaSaleOrdNotes> MaSaleOrdNotes { get; set; }
        public virtual DbSet<MaSaleOrdPymtSched> MaSaleOrdPymtSched { get; set; }
        public virtual DbSet<MaSaleOrdReferences> MaSaleOrdReferences { get; set; }
        public virtual DbSet<MaSaleOrdShipping> MaSaleOrdShipping { get; set; }
        public virtual DbSet<MaSaleOrdSummary> MaSaleOrdSummary { get; set; }
        public virtual DbSet<MaSaleOrdTaxSummary> MaSaleOrdTaxSummary { get; set; }
        #endregion
        #region Blocco Default
        public virtual DbSet<MaUserDefaultSaleOrders> MaUserDefaultSaleOrders { get; set; }
        public virtual DbSet<MaUserDefaultSales> MaUserDefaultSales { get; set; }
        public virtual DbSet<MaAccountingDefaults> MaAccountingDefaults { get; set; }
        public virtual DbSet<MaChartOfAccounts> MaChartOfAccounts { get; set; }
        public virtual DbSet<MaChartOfAccountsBalances> MaChartOfAccountsBalances { get; set; }
        public virtual DbSet<MaChartOfAccountsLang> MaChartOfAccountsLang { get; set; }
        public virtual DbSet<MaTaxCodesDefaults> MaTaxCodesDefaults { get; set; }
        public virtual DbSet<MaTaxCodes> MaTaxCodes { get; set; }
        public virtual DbSet<MaTaxCodesLists> MaTaxCodesLists { get; set; }
        public virtual DbSet<MaTaxCodesLang> MaTaxCodesLang { get; set; }
        public virtual DbSet<MaPaymentTerms> MaPaymentTerms { get; set; }
        public virtual DbSet<MaPaymentTermsDefaults> MaPaymentTermsDefaults { get; set; }
        public virtual DbSet<MaPaymentTermsLang> MaPaymentTermsLang { get; set; }
        public virtual DbSet<MaPaymentTermsPercInstall> MaPaymentTermsPercInstall { get; set; }
        #endregion
        public virtual DbSet<MaIdnumbers> MaIdnumbers { get; set; }
        public virtual DbSet<MaNonFiscalNumbers> MaNonFiscalNumbers { get; set; }

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
            #region ALL_ordini - Software Brovarone
            modelBuilder.Entity<Allattivita>(entity =>
            {
                entity.HasKey(e => e.Attivita)
                    .IsClustered(false);

                entity.ToTable("ALLAttivita");

                entity.Property(e => e.Attivita)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Annullamento)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Istat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Sospensione)
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

                // AGGIUNTO DA ME SU CAMPO NON CHIAVE ( aggiungo HasPrincipalKey)
                entity.HasOne(d => d.AllordCliAttivita)
                    .WithOne(p => p.Allattivita)
                    .HasForeignKey<Allattivita>(d => d.Attivita)
                    .HasPrincipalKey<AllordCliAttivita>(p => p.Attivita)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllAttivita_Attivita_00");

            });
            modelBuilder.Entity<Allcespiti>(entity =>
            {
                entity.HasKey(e => new { e.IdOrdCli, e.Cespite })
                    .IsClustered(false);

                entity.ToTable("ALLCespiti");

                entity.Property(e => e.Cespite)
                    .HasMaxLength(10)
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

                entity.HasOne(d => d.SaleOrd)
                   .WithMany(p => p.ALLCespiti)
                   .HasForeignKey(d => d.IdOrdCli)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Alldescrizioni>(entity =>
            {
                entity.HasKey(e => e.Codice)
                    .IsClustered(false);

                entity.ToTable("ALLDescrizioni");

                entity.Property(e => e.Codice)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Testo)
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
            modelBuilder.Entity<AllordCliAcc>(entity =>
            {
                entity.HasKey(e => e.IdOrdCli)
                    .IsClustered(false);

                entity.ToTable("ALLOrdCliAcc");

                entity.Property(e => e.IdOrdCli).ValueGeneratedNever();

                entity.Property(e => e.Agente)
                    .HasColumnName("Agente")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ApplicoIstat)
                    .HasColumnName("ApplicoISTAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CdC)
                    .HasColumnName("CdC")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CondPag)
                    .HasColumnName("CondPag")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContributoInstallazione).HasDefaultValueSql("((0))");

                entity.Property(e => e.DataCessazione)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataDecorrenza)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataPrevistaScadenza)
                 .HasColumnType("datetime")
                 .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataRiduzione)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataRiscatto)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataScadenzaFissa)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataSospensione)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Ggdisdetta)
                    .HasColumnName("GGDisdetta")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Impianto)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImpiantoDue)
                 .HasMaxLength(8)
                 .IsUnicode(false)
                 .HasDefaultValueSql("('')");

                entity.Property(e => e.ImpiantoProprietaCliente)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ImportoCanone).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImportoProvvigione).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImportoRiduzione).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImportoRiscatto).HasDefaultValueSql("((0))");

                entity.Property(e => e.MesiDurata).HasDefaultValueSql("((0))");

                entity.Property(e => e.MesiRinnovo).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModelloContratto).HasDefaultValueSql("((1229717504))");

                entity.Property(e => e.MotivoCessazione)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MotivoSospensione)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nota)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrdineSospeso)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PercRiduzione).HasDefaultValueSql("((0))");

                entity.Property(e => e.SedeInvioDoc)
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

                entity.Property(e => e.TipoContratto).HasDefaultValueSql("((1108934656))");

                entity.Property(e => e.Vettore)
                    .HasColumnName("Vettore")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.SaleOrd)
                    .WithOne(p => p.ALLOrdCliAcc)
                    .HasForeignKey<AllordCliAcc>(d => d.IdOrdCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllordCliAcc_SaleOrd_00");
            });
            modelBuilder.Entity<AllordCliAttivita>(entity =>
            {
                entity.HasKey(e => new { e.IdOrdCli, e.Line })
                    .IsClustered(false);

                entity.ToTable("ALLOrdCliAttivita");

                entity.Property(e => e.Attivita)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DaFatturare)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DataFine)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataInizio)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataRifatturazione)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Fatturata)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Nota)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TestoFattura)
                  .HasMaxLength(128)
                  .IsUnicode(false)
                  .HasDefaultValueSql("('')");

                entity.Property(e => e.RifLinea).HasDefaultValueSql("((0))");

                entity.Property(e => e.RifServizio)
                    .HasMaxLength(21)
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

                entity.Property(e => e.ValUnit)
                    .HasColumnName("ValUnit")
                    .HasDefaultValueSql("((0))");

                // AGGIUNTO DA ME
                entity.HasOne(d => d.SaleOrd)
                   .WithMany(p => p.AllordCliAttivita)
                   .HasForeignKey(d => d.IdOrdCli)
                   .OnDelete(DeleteBehavior.ClientSetNull);

                // Collegameto a riga contratto
                entity.HasOne(d => d.AllordCliContratto)
                    .WithMany(p => p.AllordCliAttivita)
                    .HasForeignKey(d => new { d.IdOrdCli, d.RifLinea })
                    .OnDelete(DeleteBehavior.ClientSetNull);
                //.HasPrincipalKey<AllordCliContratto>(p => new { p.IdOrdCli, p.Line })

            });
            modelBuilder.Entity<AllordCliContratto>(entity =>
            {
                entity.HasKey(e => new { e.IdOrdCli, e.Line })
                    .IsClustered(false);

                entity.ToTable("ALLOrdCliContratto");

                entity.Property(e => e.CdC)
                  .HasColumnName("CdC")
                  .HasMaxLength(8)
                  .IsUnicode(false)
                  .HasDefaultValueSql("('')");

                entity.Property(e => e.CodContratto)
                  .HasColumnName("CodContratto")
                  .HasMaxLength(15)
                  .IsUnicode(false)
                  .HasDefaultValueSql("('')"); 
                
                entity.Property(e => e.CodIntegra)
                     .HasColumnName("CodIntegra")
                     .HasMaxLength(15)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                entity.Property(e => e.DataDecorrenza)
                    .HasColumnName("DataDecorrenza")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataFineElaborazione)
                    .HasColumnName("DataFineElaborazione")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataProssimaFatt)
                    .HasColumnName("DataProssimaFatt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataUltRivIstat)
                    .HasColumnName("DataUltRivISTAT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Descrizione)
                    .HasColumnName("Descrizione")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                                
                entity.Property(e => e.Fatturato)
                    .HasColumnName("Fatturato")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Franchigia)
                    .HasColumnName("Franchigia")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Impianto)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MultiImpianto)
                    .HasColumnName("MultiImpianto")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
                  
                entity.Property(e => e.NonRiportaInFatt)
                    .HasColumnName("NonRiportaInFatt")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Nota)
                    .HasColumnName("Nota")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qta)
                    .HasColumnName("Qta")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Servizio)
                    .HasColumnName("Servizio")
                    .HasMaxLength(21)
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

                entity.Property(e => e.TipoRigaServizio)
                    .HasColumnName("TipoRigaServizio")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Um)
                    .HasColumnName("UM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValUnit)
                    .HasColumnName("ValUnit")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ValUnitIstat)
                    .HasColumnName("ValUnitISTAT")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SubLineAttivita)
                    .HasColumnName("SubLineAttivita")
                    .HasDefaultValueSql("((0))"); 
                
                entity.Property(e => e.SubLineDescFatt)
                    .HasColumnName("SubLineDescFatt")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SubLineDistinta)
                    .HasColumnName("SubLineDistinta")
                    .HasDefaultValueSql("((0))");
                               
                // AGGIUNTO DA ME
                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.ALLordCliContratto)
                    .HasForeignKey(d => d.IdOrdCli)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<AllordCliContrattoDescFatt>(entity =>
            {
                entity.HasKey(e => new { e.IdOrdCli, e.Line, e.RifLinea })
                    .IsClustered(false);

                entity.ToTable("ALLOrdCliContratto_DescFatt");

                entity.Property(e => e.Codice)
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasDefaultValueSql("('')");

                entity.Property(e => e.Descrizione)
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

                entity.HasOne(d => d.AllordCliContratto)
                    .WithMany(p => p.AllordCliContrattoDescFatt)
                    .HasForeignKey(d => new { d.IdOrdCli, d.RifLinea })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<AllordCliContrattoDistinta>(entity =>
            {
                entity.HasKey(e => new { e.IdOrdCli, e.Line, e.RifLinea })
                    .IsClustered(false);

                entity.ToTable("ALLOrdCliContratto_Distinta");
                
                entity.Property(e => e.CdC)
                    .HasColumnName("CdC")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CodContratto)
                   .HasColumnName("CodContratto")
                   .HasMaxLength(15)
                   .IsUnicode(false)
                   .HasDefaultValueSql("('')");

                entity.Property(e => e.CodIntegra)
                   .HasColumnName("CodIntegra")
                   .HasMaxLength(15)
                   .IsUnicode(false)
                   .HasDefaultValueSql("('')");

                entity.Property(e => e.DataDecorrenza)
                    .HasColumnName("DataDecorrenza")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataFineElaborazione)
                    .HasColumnName("DataFineElaborazione")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataProssimaFatt)
                    .HasColumnName("DataProssimaFatt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataUltRivIstat)
                    .HasColumnName("DataUltRivISTAT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Descrizione)
                    .HasColumnName("Descrizione")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Impianto)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Nota)
                    .HasColumnName("Nota")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qta)
                    .HasColumnName("Qta")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Servizio)
                    .HasColumnName("Servizio")
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubLineServAgg)
                    .HasColumnName("SubLineServAgg")
                    .HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TipoRigaServizio)
                    .HasColumnName("TipoRigaServizio")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Um)
                    .HasColumnName("UM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValUnit)
                    .HasColumnName("ValUnit")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ValUnitIstat)
                    .HasColumnName("ValUnitISTAT")
                    .HasDefaultValueSql("((0))");

                // AGGIUNTO DA ME
                entity.HasOne(d => d.AllordCliContratto)
                    .WithMany(p => p.AllordCliContrattoDistinta)
                    .HasForeignKey(d => new { d.IdOrdCli, d.RifLinea })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<AllordCliContrattoDistintaServAgg>(entity =>
            {
                entity.HasKey(e => new { e.IdOrdCli, e.Line, e.RifLinea, e.RifRifLinea })
                    .IsClustered(false);

                entity.ToTable("ALLOrdCliContratto_Distinta_ServAgg");

                entity.Property(e => e.DataDecorrenza)
                    .HasColumnName("DataDecorrenza")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataFineElaborazione)
                    .HasColumnName("DataFineElaborazione")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataProssimaFatt)
                    .HasColumnName("DataProssimaFatt")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DataUltRivIstat)
                    .HasColumnName("DataUltRivISTAT")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Descrizione)
                    .HasColumnName("Descrizione")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Franchigia)
                    .HasColumnName("Franchigia")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Qta)
                    .HasColumnName("Qta")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Servizio)
                    .HasColumnName("Servizio")
                    .HasMaxLength(21)
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

                entity.Property(e => e.TipoRigaServizio)
                    .HasColumnName("TipoRigaServizio")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Um)
                    .HasColumnName("UM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ValUnit)
                    .HasColumnName("ValUnit")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ValUnitIstat)
                    .HasColumnName("ValUnitISTAT")
                    .HasDefaultValueSql("((0))");

                // AGGIUNTO DA ME
                entity.HasOne(d => d.AllordCliContrattoDistinta)
                    .WithMany(p => p.AllordCliContrattoDistintaServAgg)
                    .HasForeignKey(d => new { d.IdOrdCli, d.RifLinea , d.RifRifLinea })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<AllordCliContrattoDistCesp>(entity =>
            {
                entity.HasKey(e => new { e.IdOrdCli, e.Cespite, e.RifLinea, e.RifRifLinea })
                    .IsClustered(false);

                entity.ToTable("ALLOrdCliContratto_Dist_Cesp");

                entity.Property(e => e.Cespite)
                    .HasMaxLength(10)
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

                entity.HasOne(d => d.AllordCliContrattoDistinta)
                    .WithMany(p => p.AllordCliContrattoDistCesp)
                    .HasForeignKey(d => new { d.IdOrdCli, d.RifLinea, d.RifRifLinea })
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<AllordCliDescrizioni>(entity =>
            {
                entity.HasKey(e => new { e.IdOrdCli, e.Line })
                    .IsClustered(false);

                entity.ToTable("ALLOrdCliDescrizioni");

                entity.Property(e => e.Codice)
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasDefaultValueSql("('')");

                entity.Property(e => e.Descrizione)
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

                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.ALLordCliDescrizioni)
                    .HasForeignKey(d => d.IdOrdCli)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<AllordCliFattEle>(entity =>
            {
                entity.HasKey(e => e.IdOrdCli)
                    .IsClustered(false);

                entity.ToTable("ALLOrdCliFattEle");

                entity.Property(e => e.IdOrdCli).ValueGeneratedNever();

                entity.Property(e => e.F2_1_1_5_4)
                    .HasColumnName("F2_1_1_5_4")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_1_11)
                    .HasColumnName("F2_1_1_11")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                //Dati Ordine di Acquisto
                entity.Property(e => e.F2_1_2_1)
                    .HasColumnName("F2_1_2_1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.F2_1_2_2)
                    .HasColumnName("F2_1_2_2")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_2_3)
                   .HasColumnName("F2_1_2_3")
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.F2_1_2_4)
                    .HasColumnName("F2_1_2_4")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_2_5)
                    .HasColumnName("F2_1_2_5")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
                
                entity.Property(e => e.F2_1_2_6)
                    .HasColumnName("F2_1_2_6")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_2_7)
                    .HasColumnName("F2_1_2_7")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                //Dati Contratto
                entity.Property(e => e.F2_1_3_1)
                    .HasColumnName("F2_1_3_1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.F2_1_3_2)
                    .HasColumnName("F2_1_3_2")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_3_3)
                   .HasColumnName("F2_1_3_3")
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.F2_1_3_4)
                    .HasColumnName("F2_1_3_4")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_3_5)
                    .HasColumnName("F2_1_3_5")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_3_6)
                    .HasColumnName("F2_1_3_6")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_3_7)
                    .HasColumnName("F2_1_3_7")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                //Dati Convenzione
                entity.Property(e => e.F2_1_4_1)
                    .HasColumnName("F2_1_4_1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.F2_1_4_2)
                    .HasColumnName("F2_1_4_2")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_4_3)
                   .HasColumnName("F2_1_4_3")
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.F2_1_4_4)
                    .HasColumnName("F2_1_4_4")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_4_5)
                    .HasColumnName("F2_1_4_5")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_4_6)
                    .HasColumnName("F2_1_4_6")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_4_7)
                    .HasColumnName("F2_1_4_7")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                //Dati Ricezione
                entity.Property(e => e.F2_1_5_1)
                    .HasColumnName("F2_1_5_1")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.F2_1_5_2)
                    .HasColumnName("F2_1_5_2")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_5_3)
                   .HasColumnName("F2_1_5_3")
                   .HasColumnType("datetime")
                   .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.F2_1_5_4)
                    .HasColumnName("F2_1_5_4")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_5_5)
                    .HasColumnName("F2_1_5_5")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_5_6)
                    .HasColumnName("F2_1_5_6")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.F2_1_5_7)
                    .HasColumnName("F2_1_5_7")
                    .HasMaxLength(15)
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

              
                entity.HasOne(d => d.SaleOrd)
                    .WithOne(p => p.ALLOrdCliFattEle)
                    .HasForeignKey<AllordCliFattEle>(d => d.IdOrdCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllordCliFattEle_SaleOrd_00");
            });
            modelBuilder.Entity<AllordCliTipologiaServizi>(entity =>
            {
                entity.HasKey(e => new { e.IdOrdCli, e.Tipologia })
                    .IsClustered(false);

                entity.ToTable("ALLOrdCliTipologiaServizi");

                entity.Property(e => e.Tipologia)
                    .HasMaxLength(8)
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

                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.ALLordCliTipologiaServizi)
                    .HasForeignKey(d => d.IdOrdCli)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });
            modelBuilder.Entity<AllordFiglio>(entity =>
            {
                entity.HasKey(e => new { e.IdOrdCli, e.IdOrdFiglio })
                    .IsClustered(false);

                entity.ToTable("ALLOrdFiglio");

                entity.Property(e => e.NrOrdFiglio)
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

                entity.HasOne(d => d.SaleOrd)
                   .WithMany(p => p.AllordFiglio)
                   .HasForeignKey(d => d.IdOrdCli)
                   .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<AllordPadre>(entity =>
            {
                entity.HasKey(e => new { e.IdOrdCli, e.IdOrdPadre })
                    .IsClustered(false);

                entity.ToTable("ALLOrdPadre");

                entity.Property(e => e.NrOrdPadre)
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

                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.AllordPadre)
                    .HasForeignKey(d => d.IdOrdCli)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<AlltipoRigaServizio>(entity =>
            {
                entity.HasKey(e => e.TipoRigaServizio)
                    .IsClustered(false);

                entity.ToTable("ALLTipoRigaServizio");

                entity.Property(e => e.TipoRigaServizio)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Agosto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Aprile)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Cadenza).HasDefaultValueSql("((2009399296))");

                entity.Property(e => e.Campagna)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Descrizione)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Dicembre)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Febbraio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Gennaio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Giugno)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Luglio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Maggio)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Marzo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Novembre)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Ottobre)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Periodicita).HasDefaultValueSql("((1094254592))");

                entity.Property(e => e.Settembre)
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

                entity.Property(e => e.TipologiaServizio).HasDefaultValueSql("((1276116992))");

                // AGGIUNTO DA ME
                entity.HasOne(d => d.AllordCliContratto)
                    .WithOne(p => p.AlltipoRigaServizio)
                    .HasForeignKey<AlltipoRigaServizio>(d => d.TipoRigaServizio)
                    .HasPrincipalKey<AllordCliContratto>(p => p.TipoRigaServizio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlltipoRigaServizio_TipoRigaServizio_00");

                entity.HasOne(d => d.AllordCliContrattoDistinta)
                    .WithOne(p => p.AlltipoRigaServizio)
                    .HasForeignKey<AlltipoRigaServizio>(d => d.TipoRigaServizio)
                    .HasPrincipalKey<AllordCliContrattoDistinta>(p => p.TipoRigaServizio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlltipoRigaServizio_TipoRigaServizio_01");

                entity.HasOne(d => d.AllordCliContrattoDistintaServAgg)
                    .WithOne(p => p.AlltipoRigaServizio)
                    .HasForeignKey<AlltipoRigaServizio>(d => d.TipoRigaServizio)
                    .HasPrincipalKey<AllordCliContrattoDistintaServAgg>(p => p.TipoRigaServizio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlltipoRigaServizio_TipoRigaServizio_02");
            });
            #endregion
            #region CustSupp
            modelBuilder.Entity<MaCustomerClassification>(entity =>
            {
                entity.HasKey(e => e.CustomerClassification)
                    .HasName("PK_CustomerClassification")
                    .IsClustered(false);

                entity.ToTable("MA_CustomerClassification");

                entity.Property(e => e.CustomerClassification)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
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
            modelBuilder.Entity<MaCustomerCtg>(entity =>
{
    entity.HasKey(e => e.Category)
        .HasName("PK_CustomerCtg")
        .IsClustered(false);

    entity.ToTable("MA_CustomerCtg");

    entity.HasIndex(e => e.Description)
        .HasName("MA_CustomerCtg2");

    entity.Property(e => e.Category)
        .HasMaxLength(8)
        .IsUnicode(false);

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
            modelBuilder.Entity<MaCustomerSpecification>(entity =>
{
    entity.HasKey(e => e.CustomerSpecification)
        .HasName("PK_CustomerSpecification")
        .IsClustered(false);

    entity.ToTable("MA_CustomerSpecification");

    entity.Property(e => e.CustomerSpecification)
        .HasMaxLength(8)
        .IsUnicode(false);

    entity.Property(e => e.Description)
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
            modelBuilder.Entity<MaDeclarationOfIntent>(entity =>
            {
                entity.HasKey(e => e.DeclId)
                    .HasName("PK_DeclarationOfIntent")
                    .IsClustered(false);

                entity.ToTable("MA_DeclarationOfIntent");

                entity.HasIndex(e => new { e.CustSuppType, e.DeclDate, e.LogNo })
                    .HasName("MA_DeclarationOfIntent3");

                entity.HasIndex(e => new { e.CustSuppType, e.DeclYear, e.LogNo })
                    .HasName("MA_DeclarationOfIntent2");

                entity.Property(e => e.DeclId).ValueGeneratedNever();

                entity.Property(e => e.AnnulmentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.CustomerDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.CustomerNo)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeclDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DeclType).HasDefaultValueSql("((1507330))");

                entity.Property(e => e.DeclYear).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocProtocol)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FromDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LetterNotes)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LimitAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.LogNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrintAnnulmentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PrintDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PrintFileDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PrintLetterDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrintedAnnulment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrintedLetter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PrintedOnFile)
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

                entity.Property(e => e.TelProtocol)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ToDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");
            });
            modelBuilder.Entity<MaDeclarationOfIntentNumbers>(entity =>
{
    entity.HasKey(e => new { e.BalanceYear, e.Received })
        .HasName("PK_DeclarationOfIntentNumbers")
        .IsClustered(false);

    entity.ToTable("MA_DeclarationOfIntentNumbers");

    entity.Property(e => e.Received)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength();

    entity.Property(e => e.DefinitivelyPrinted)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.LastDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("('17991231')");

    entity.Property(e => e.LastLogNo).HasDefaultValueSql("((0))");

    entity.Property(e => e.LastPrintingDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("('17991231')");

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
            modelBuilder.Entity<MaCustSupp>(entity =>
{
    entity.HasKey(e => new { e.CustSuppType, e.CustSupp })
        .HasName("PK_CustSupp")
        .IsClustered(false);

    entity.ToTable("MA_CustSupp");

    entity.HasIndex(e => e.CustSuppBank)
        .HasName("MA_CustSupp6");

    entity.HasIndex(e => e.TaxIdNumber)
        .HasName("MA_CustSupp5");

    entity.HasIndex(e => new { e.CustSuppType, e.CompanyName })
        .HasName("MA_CustSupp2");

    entity.HasIndex(e => new { e.CustSuppType, e.FiscalCode })
        .HasName("MA_CustSupp4");

    entity.HasIndex(e => new { e.CustSuppType, e.TaxIdNumber })
        .HasName("MA_CustSupp3");

    entity.Property(e => e.CustSupp)
        .HasMaxLength(12)
        .IsUnicode(false);

    entity.Property(e => e.Account)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.ActivityCode)
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Address)
        .HasMaxLength(128)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Address2)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.AdministrationReference)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.AllcopiaCartacea)
        .HasColumnName("ALLCopiaCartacea")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.AswStandard).HasDefaultValueSql("((12582912))");

    entity.Property(e => e.BlackListCustSupp)
        .HasMaxLength(12)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Ca)
        .HasColumnName("CA")
        .HasMaxLength(18)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Cacheck)
        .HasColumnName("CACheck")
        .HasMaxLength(2)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Cbicode)
        .HasColumnName("CBICode")
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CertifiedEmail)
        .HasColumnName("CertifiedEMail")
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.ChambOfCommCounty)
        .HasMaxLength(3)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.ChambOfCommRegistrNo)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Cin)
        .HasColumnName("CIN")
        .HasMaxLength(1)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.City)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CompanyBank)
        .HasMaxLength(11)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CompanyCa)
        .HasColumnName("CompanyCA")
        .HasMaxLength(18)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CompanyName)
        .HasMaxLength(128)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CompanyRegistrNo)
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.ContactPerson)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CostCenter)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Country)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.County)
        .HasMaxLength(3)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CreditNoteAccTpl)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Currency)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CustSuppBank)
        .HasMaxLength(11)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CustSuppKind).HasDefaultValueSql("((7733248))");

    entity.Property(e => e.CustomerCompanyCa)
        .HasColumnName("CustomerCompanyCA")
        .HasMaxLength(18)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.DdcustSupp)
        .HasColumnName("DDCustSupp")
        .HasMaxLength(16)
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

    entity.Property(e => e.District)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.DocumentSendingType).HasDefaultValueSql("((11337728))");

    entity.Property(e => e.Draft)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.EicertifiedEmail)
        .HasColumnName("EICertifiedEMail")
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.EitypeCodeItem)
        .HasColumnName("EITypeCodeItem")
        .HasMaxLength(35)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.EitypeCodeItemBarcode)
        .HasColumnName("EITypeCodeItemBarcode")
        .HasMaxLength(35)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.EitypeCodeItemCustomer)
        .HasColumnName("EITypeCodeItemCustomer")
        .HasMaxLength(35)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.EiunitValue)
        .HasColumnName("EIUnitValue")
        .HasDefaultValueSql("((24903680))");

    entity.Property(e => e.ElectronicInvoicing)
        .HasMaxLength(1)
        .IsUnicode(false)
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Email)
        .HasColumnName("EMail")
        .HasMaxLength(128)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Eoricode)
        .HasColumnName("EORICode")
        .HasMaxLength(17)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.ExternalCode)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FactoringCa)
        .HasColumnName("FactoringCA")
        .HasMaxLength(18)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FantasyName)
        .HasMaxLength(128)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Fax)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FdcompanyName)
        .HasColumnName("FDCompanyName")
        .HasMaxLength(80)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Fdeoricode)
        .HasColumnName("FDEORICode")
        .HasMaxLength(17)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FdfiscalCode)
        .HasColumnName("FDFiscalCode")
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FdfiscalCodeId)
        .HasColumnName("FDFiscalCodeID")
        .HasMaxLength(28)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FdisocountryCode)
        .HasColumnName("FDISOCountryCode")
        .HasMaxLength(2)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FdlastName)
        .HasColumnName("FDLastName")
        .HasMaxLength(60)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Fdname)
        .HasColumnName("FDName")
        .HasMaxLength(60)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FdnaturalPerson)
        .HasColumnName("FDNaturalPerson")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.FdtitleCode)
        .HasColumnName("FDTitleCode")
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FedStateReg)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FederalState)
        .HasMaxLength(2)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FiscalCode)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FiscalCtg)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FiscalName)
        .HasMaxLength(128)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FiscalRegime)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.GenRegEntity)
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.GenRegNo)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Iban)
        .HasColumnName("IBAN")
        .HasMaxLength(34)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.IbanisManual)
        .HasColumnName("IBANIsManual")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.ImmediateLikeAccompanying)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.InCurrency)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.InLiquidation)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.InTaxLists)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('1')");

    entity.Property(e => e.InsertionDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("('17991231')");

    entity.Property(e => e.Internet)
        .HasMaxLength(32)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.InvoiceAccTpl)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Ipacode)
        .HasColumnName("IPACode")
        .HasMaxLength(7)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.IsAnEucustSupp)
        .HasColumnName("IsAnEUCustSupp")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.IsCustoms)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.IsDummy)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.IsocountryCode)
        .HasColumnName("ISOCountryCode")
        .HasMaxLength(2)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Job)
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Language)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Latitude)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.LeasingLetter)
        .HasMaxLength(1)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.LinkedCustSupp)
        .HasMaxLength(12)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Longitude)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.MailSendingType).HasDefaultValueSql("((12451841))");

    entity.Property(e => e.MunicipalityReg)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.NaturalPerson)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.NoBlackList)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.NoSendPostaLite)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.NoTaxComm)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Notes)
        .HasMaxLength(1024)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.OldCustSupp)
        .HasMaxLength(12)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.OmniasubAccount)
        .HasColumnName("OMNIASubAccount")
        .HasMaxLength(6)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Payment)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.PaymentAddress)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.PaymentPeriShablesOver60)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.PaymentPeriShablesWithin60)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.PermanentBranchCode)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Presentation).HasDefaultValueSql("((1376256))");

    entity.Property(e => e.PriceList)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.PrintedInKepyo)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('1')");

    entity.Property(e => e.PrivacyStatement)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.PrivacyStatementPrintDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("('17991231')");

    entity.Property(e => e.Profession)
        .HasMaxLength(15)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.PublicSector)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.PymtAccount)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Region)
        .HasMaxLength(32)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.RegisterReceivedEi)
        .HasColumnName("RegisterReceivedEI")
        .HasDefaultValueSql("((20905986))");

    entity.Property(e => e.SendByCertifiedEmail)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.SendDocumentsTo)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.ShipToAddress)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Siacode)
        .HasColumnName("SIACode")
        .HasMaxLength(5)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.SkypeId)
        .HasColumnName("SkypeID")
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.SplitTax)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Storage)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.StreetNo)
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.SubmissionExcluded)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Suframa)
        .HasColumnName("SUFRAMA")
        .HasMaxLength(9)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.TaxIdNumber)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.TaxOffice)
        .HasMaxLength(32)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.TaxpayerType).HasDefaultValueSql("((30212096))");

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

    entity.Property(e => e.Telephone1)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Telephone2)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Telex)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.TitleCode)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.UsedForSummaryDocuments)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.WorkingPosition)
        .HasMaxLength(32)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.WorkingTime)
        .HasMaxLength(24)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Zipcode)
        .HasColumnName("ZIPCode")
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

});
            modelBuilder.Entity<MaCustSuppBalances>(entity =>
{
    entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.FiscalYear, e.BalanceYear, e.BalanceType, e.BalanceMonth, e.Nature, e.Currency })
        .HasName("PK_CustSuppBalances")
        .IsClustered(false);

    entity.ToTable("MA_CustSuppBalances");

    entity.Property(e => e.CustSupp)
        .HasMaxLength(12)
        .IsUnicode(false);

    entity.Property(e => e.Currency)
        .HasMaxLength(8)
        .IsUnicode(false);

    entity.Property(e => e.Credit).HasDefaultValueSql("((0))");

    entity.Property(e => e.Debit).HasDefaultValueSql("((0))");

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

    entity.HasOne(d => d.CustSuppNavigation)
        .WithMany(p => p.MaCustSuppBalances)
        .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_CustSuppBa_CustSupp_00");
});
            modelBuilder.Entity<MaCustSuppBlackList>(entity =>
{
    entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.BalanceYear, e.BalanceMonth, e.IsManual, e.CreditNotesPrevPeriod, e.CreditNotesPrevYear })
        .HasName("PK_CustSuppBlackList")
        .IsClustered(false);

    entity.ToTable("MA_CustSuppBlackList");

    entity.HasIndex(e => new { e.Grouping, e.CustSuppType, e.CustSupp, e.CreditNotesPrevPeriod, e.CreditNotesPrevYear })
        .HasName("IX_MA_CustSuppBlackList");

    entity.Property(e => e.CustSupp)
        .HasMaxLength(12)
        .IsUnicode(false);

    entity.Property(e => e.IsManual)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength();

    entity.Property(e => e.CreditNotesPrevPeriod)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength();

    entity.Property(e => e.CreditNotesPrevYear)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength();

    entity.Property(e => e.Exempt).HasDefaultValueSql("((0))");

    entity.Property(e => e.Grouping)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.NoTaxableGoods).HasDefaultValueSql("((0))");

    entity.Property(e => e.NoTaxableServices).HasDefaultValueSql("((0))");

    entity.Property(e => e.NotInBlackListAmount).HasDefaultValueSql("((0))");

    entity.Property(e => e.NotSubjectGoods).HasDefaultValueSql("((0))");

    entity.Property(e => e.NotSubjectServices).HasDefaultValueSql("((0))");

    entity.Property(e => e.TaxAmountGoods).HasDefaultValueSql("((0))");

    entity.Property(e => e.TaxAmountServices).HasDefaultValueSql("((0))");

    entity.Property(e => e.TaxableAmountGoods).HasDefaultValueSql("((0))");

    entity.Property(e => e.TaxableAmountServices).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaCustSuppBranches>(entity =>
{
    entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.Branch })
        .HasName("PK_CustSuppBranches")
        .IsClustered(false);

    entity.ToTable("MA_CustSuppBranches");

    entity.HasIndex(e => e.TaxIdNumber)
        .HasName("MA_CustSuppBranches2");

    entity.Property(e => e.CustSupp)
        .HasMaxLength(12)
        .IsUnicode(false);

    entity.Property(e => e.Branch)
        .HasMaxLength(8)
        .IsUnicode(false);

    entity.Property(e => e.Address)
        .HasMaxLength(128)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Address2)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.AdministrationReference)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.AreaManager)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.City)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CompanyName)
        .HasMaxLength(128)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.ContactPerson)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Country)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.County)
        .HasMaxLength(3)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Disabled)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.District)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.EishipNumberData)
        .HasColumnName("EIShipNumberData")
        .HasDefaultValueSql("((0))");

    entity.Property(e => e.EishipTextData)
        .HasColumnName("EIShipTextData")
        .HasMaxLength(60)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.EishipTypeData)
        .HasColumnName("EIShipTypeData")
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Email)
        .HasColumnName("EMail")
        .HasMaxLength(128)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Fax)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FederalState)
        .HasMaxLength(2)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FiscalCode)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.FiscalName)
        .HasMaxLength(128)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Internet)
        .HasMaxLength(32)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Ipacode)
        .HasColumnName("IPACode")
        .HasMaxLength(7)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.IsocountryCode)
        .HasColumnName("ISOCountryCode")
        .HasMaxLength(2)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Language)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Latitude)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Longitude)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.MailSendingType).HasDefaultValueSql("((12451841))");

    entity.Property(e => e.Notes)
        .HasMaxLength(128)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Region)
        .HasMaxLength(32)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Salesperson)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Siacode)
        .HasColumnName("SIACode")
        .HasMaxLength(5)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.SkypeId)
        .HasColumnName("SkypeID")
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.StreetNo)
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.TaxIdNumber)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.TaxOffice)
        .HasMaxLength(32)
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

    entity.Property(e => e.Telephone1)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Telephone2)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Telex)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.WorkingTime)
        .HasMaxLength(24)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Zipcode)
        .HasColumnName("ZIPCode")
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.HasOne(d => d.CustSuppNavigation)
        .WithMany(p => p.MaCustSuppBranches)
        .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_CustSuppBr_CustSupp_00");
});
            modelBuilder.Entity<MaCustSuppBudget>(entity =>
            {
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.FiscalYear, e.BalanceYear, e.BalanceType, e.BalanceMonth })
                    .HasName("PK_CustSuppBudget")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppBudget");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.ActualCreditNotesAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualDebitNotesAmount).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualOrdered).HasDefaultValueSql("((0))");

                entity.Property(e => e.ActualTurnover).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedBudget).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TurnoverBudget).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CustSuppNavigation)
                    .WithMany(p => p.MaCustSuppBudget)
                    .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppBu_CustSupp_00");
            });
            modelBuilder.Entity<MaCustSuppCircularLetters>(entity =>
{
    entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.Template })
        .HasName("PK_CustSuppCircularLetters")
        .IsClustered(false);

    entity.ToTable("MA_CustSuppCircularLetters");

    entity.Property(e => e.CustSupp)
        .HasMaxLength(12)
        .IsUnicode(false);

    entity.Property(e => e.Template)
        .HasMaxLength(8)
        .IsUnicode(false);

    entity.Property(e => e.Disabled)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.PrintDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("('17991231')");

    entity.Property(e => e.Printed)
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

    entity.HasOne(d => d.CustSuppNavigation)
        .WithMany(p => p.MaCustSuppCircularLetters)
        .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_CustSuppCi_CustSupp_00");
});
            modelBuilder.Entity<MaCustSuppCustomerOptions>(entity =>
{
    entity.HasKey(e => new { e.CustSuppType, e.Customer })
        .HasName("PK_CustSuppCustomerOptions")
        .IsClustered(false);

    entity.ToTable("MA_CustSuppCustomerOptions");

    entity.Property(e => e.Customer)
        .HasMaxLength(12)
        .IsUnicode(false);

    entity.Property(e => e.AllocationArea)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Area)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.AreaManager)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Blocked)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Carrier1)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Carrier2)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Carrier3)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CashOnDeliveryLevel).HasDefaultValueSql("((0))");

    entity.Property(e => e.CashOrderCharges).HasDefaultValueSql("((0))");

    entity.Property(e => e.Category)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.ChargesPercOnTotAmt).HasDefaultValueSql("((0))");

    entity.Property(e => e.CommissionCtg)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.ConsignmentPartner)
        .HasMaxLength(12)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Contract)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CrossDocking)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.CustomerClassification)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CustomerSpecification)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.DebitCollectionCharges)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('1')");

    entity.Property(e => e.DebitFreeSamplesTaxAmount).HasDefaultValueSql("((3276802))");

    entity.Property(e => e.DebitStampCharges)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.DeclarationOfIntentDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("('17991231')");

    entity.Property(e => e.DeclarationOfIntentDueDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("('17991231')");

    entity.Property(e => e.DeclarationOfIntentId).HasDefaultValueSql("((0))");

    entity.Property(e => e.DeclarationOfIntentNo)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.DeclarationOfIntentOurNo)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.DirectAllocation)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.ExcludedFromWeee)
        .HasColumnName("ExcludedFromWEEE")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.ExemptFromTax)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.FreeOfChargeLevel).HasDefaultValueSql("((0))");

    entity.Property(e => e.GoodsOffset)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.GroupBills)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('1')");

    entity.Property(e => e.GroupCostAccounting)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.GroupItems)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.GroupOrders)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.InvoicingCustomer)
        .HasMaxLength(12)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.InvoicingGroup)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.IsAprivatePerson)
        .HasColumnName("IsAPrivatePerson")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.LastDocDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("('17991231')");

    entity.Property(e => e.LastDocNo)
        .HasMaxLength(10)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.LastDocTotal).HasDefaultValueSql("((0))");

    entity.Property(e => e.LastPaymentTerm)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.LotOverbook)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.LotSelection).HasDefaultValueSql("((8454147))");

    entity.Property(e => e.MaxOrderValue).HasDefaultValueSql("((0))");

    entity.Property(e => e.MaxOrderValueCheckType).HasDefaultValueSql("((11599872))");

    entity.Property(e => e.MaxOrderValueDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("('17991231')");

    entity.Property(e => e.MaxOrderedValue).HasDefaultValueSql("((0))");

    entity.Property(e => e.MaxOrderedValueCheckType).HasDefaultValueSql("((11599872))");

    entity.Property(e => e.MaxOrderedValueDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("('17991231')");

    entity.Property(e => e.MaximumCredit).HasDefaultValueSql("((0))");

    entity.Property(e => e.MaximumCreditCheckType).HasDefaultValueSql("((11599872))");

    entity.Property(e => e.MaximumCreditDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("('17991231')");

    entity.Property(e => e.NoCarrierCharges)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.NoOfMaxLevelReqForPymt).HasDefaultValueSql("((0))");

    entity.Property(e => e.NoPrintDueDate)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.NotUseTd25)
        .HasColumnName("NotUseTD25")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.OneDnperOrder)
        .HasColumnName("OneDNPerOrder")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.OneDocumentPerPl)
        .HasColumnName("OneDocumentPerPL")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.OneInvoicePerDn)
        .HasColumnName("OneInvoicePerDN")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.OneInvoicePerOrder)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.OneReturnFromCustomerPerCn)
        .HasColumnName("OneReturnFromCustomerPerCN")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.OpenedAdmCases)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.OpenedAdmCasesAmount).HasDefaultValueSql("((0))");

    entity.Property(e => e.PackCharges).HasDefaultValueSql("((0))");

    entity.Property(e => e.Package)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.PasplitPayment)
        .HasColumnName("PASplitPayment")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.PenalityPerc).HasDefaultValueSql("((0))");

    entity.Property(e => e.Port)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Priority).HasDefaultValueSql("((0))");

    entity.Property(e => e.PublicAuthority)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.ReferencesPrintType).HasDefaultValueSql("((524293))");

    entity.Property(e => e.ReqForPymtLastDate)
        .HasColumnType("datetime")
        .HasDefaultValueSql("('17991231')");

    entity.Property(e => e.ReqForPymtLastLevel).HasDefaultValueSql("((0))");

    entity.Property(e => e.ReqForPymtThreshold).HasDefaultValueSql("((0))");

    entity.Property(e => e.Salesperson)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.ServicesOffset)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Shipping)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.ShippingCharges).HasDefaultValueSql("((0))");

    entity.Property(e => e.ShowPricesOnDn)
        .HasColumnName("ShowPricesOnDN")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.SuspendedTax)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.TaxCode)
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

    entity.Property(e => e.Transport)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.TssendObjection)
        .HasColumnName("TSSendObjection")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.UseReqForPymt)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Variant)
        .HasMaxLength(21)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.VirtualStampFulfilled)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.WithholdingTaxBasePerc).HasDefaultValueSql("((0))");

    entity.Property(e => e.WithholdingTaxManagement)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.WithholdingTaxPerc).HasDefaultValueSql("((0))");

    entity.HasOne(d => d.Cust)
        .WithOne(p => p.MaCustSuppCustomerOptions)
        .HasForeignKey<MaCustSuppCustomerOptions>(d => new { d.CustSuppType, d.Customer })
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_CustSuppCu_CustSupp_00");
});
            modelBuilder.Entity<MaCustSuppForm>(entity =>
            {
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.DocumentNamespace })
                    .HasName("PK_CustSuppForm")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppForm");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentNamespace)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ReportDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReportNamespace)
                    .IsRequired()
                    .HasMaxLength(250)
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
            });
            modelBuilder.Entity<MaCustSuppFormCategory>(entity =>
{
    entity.HasKey(e => new { e.CustSuppType, e.Category, e.DocumentNamespace })
        .HasName("PK_CustSuppFormCategory")
        .IsClustered(false);

    entity.ToTable("MA_CustSuppFormCategory");

    entity.Property(e => e.Category)
        .HasMaxLength(8)
        .IsUnicode(false);

    entity.Property(e => e.DocumentNamespace)
        .HasMaxLength(250)
        .IsUnicode(false);

    entity.Property(e => e.ReportDescription)
        .HasMaxLength(250)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.ReportNamespace)
        .IsRequired()
        .HasMaxLength(250)
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
});
            modelBuilder.Entity<MaCustSuppNaturalPerson>(entity =>
            {
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp })
                    .HasName("PK_CustSuppNaturalPerson")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppNaturalPerson");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.CityOfBirth)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountyOfBirth)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FeeTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ForfeitRegime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Form770Letter)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Gender).HasDefaultValueSql("((2097152))");

                entity.Property(e => e.Inpsaccount)
                    .HasColumnName("INPSAccount")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastName)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Professional)
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

                entity.HasOne(d => d.CustSuppNavigation)
                    .WithOne(p => p.MaCustSuppNaturalPerson)
                    .HasForeignKey<MaCustSuppNaturalPerson>(d => new { d.CustSuppType, d.CustSupp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppNa_CustSupp_00");
            });
            modelBuilder.Entity<MaCustSuppNotes>(entity =>
{
    entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.Line })
        .HasName("PK_CustSuppNotes")
        .IsClustered(false);

    entity.ToTable("MA_CustSuppNotes");

    entity.Property(e => e.CustSupp)
        .HasMaxLength(12)
        .IsUnicode(false);

    entity.Property(e => e.AccompanyingInvoices)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.BillOfLading)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.CopyInPurchases)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.CopyInSales)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.CorrAccInvoice)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.CorrInvoice)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.CorrReceipt)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.CreditNote)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.CustQuota)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.DebitNote)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Dn)
        .HasColumnName("DN")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Einvoice)
        .HasColumnName("EInvoice")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Invoice)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.InvoiceForAdv)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Ncreceipt)
        .HasColumnName("NCReceipt")
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Notes)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.PickingList)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Proforma)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.PurchCorrInv)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.PurchInvForAdv)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.PurchaseDoc)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.PurchaseOrd)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Receipt)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.RetCust)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.RetSupp)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.SaleOrd)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.ShowInAccounting)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.ShowInPurchases)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.ShowInPureAccounting)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.ShowInSales)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.SubcontrBillOfLading)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.SubcontrDeliveryNote)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.SubcontrPurchOrder)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.SuppQuota)
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

    entity.HasOne(d => d.CustSuppNavigation)
        .WithMany(p => p.MaCustSuppNotes)
        .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_CustSuppNo_CustSupp_00");
});
            modelBuilder.Entity<MaCustSuppOutstandings>(entity =>
            {
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.FiscalYear })
                    .HasName("PK_CustSuppOutstandings")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppOutstandings");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.NoOfOutstandings).HasDefaultValueSql("((0))");

                entity.Property(e => e.OutstandingsTotAmt).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.CustSuppNavigation)
                    .WithMany(p => p.MaCustSuppOutstandings)
                    .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppOu_CustSupp_00");
            });
            modelBuilder.Entity<MaCustSuppParameters>(entity =>
{
    entity.HasKey(e => e.CustSuppParametersId)
        .HasName("PK_CustSuppParameters")
        .IsClustered(false);

    entity.ToTable("MA_CustSuppParameters");

    entity.Property(e => e.CustSuppParametersId).ValueGeneratedNever();

    entity.Property(e => e.AutomaticPrefix)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.BankComboMaxItems).HasDefaultValueSql("((300))");

    entity.Property(e => e.CityComboMaxItems).HasDefaultValueSql("((300))");

    entity.Property(e => e.ContactsAutoNum)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.ContactsAutomaticPrefix)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.ContactsMaxChars).HasDefaultValueSql("((0))");

    entity.Property(e => e.CustDocumentSendingType).HasDefaultValueSql("((11337728))");

    entity.Property(e => e.CustMailSendingType).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.CustPaymentTerm)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CustSuppDraftDefault)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.CustSuppDraftType).HasDefaultValueSql("((25100288))");

    entity.Property(e => e.CustSuppMaxChars).HasDefaultValueSql("((0))");

    entity.Property(e => e.CustomerAutoNum)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.EucustomerTaxCode)
        .HasColumnName("EUCustomerTaxCode")
        .HasMaxLength(4)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.IsocountryCode)
        .HasColumnName("ISOCountryCode")
        .HasMaxLength(2)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.LastContact).HasDefaultValueSql("((0))");

    entity.Property(e => e.LastCustomer).HasDefaultValueSql("((0))");

    entity.Property(e => e.LastProspSupp).HasDefaultValueSql("((0))");

    entity.Property(e => e.LastSupplier).HasDefaultValueSql("((0))");

    entity.Property(e => e.PrefixWithSiteCode)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.ProspSuppAutoNum)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.SuppDocumentSendingType).HasDefaultValueSql("((11337728))");

    entity.Property(e => e.SuppMailSendingType).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.SuppPaymentTerm)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.SupplierAutonum)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.TaxIdNumberLinkUrl)
        .HasMaxLength(256)
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

    entity.Property(e => e.UseCityComplete)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");
});
            modelBuilder.Entity<MaCustSuppPeople>(entity =>
{
    entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.Line })
        .HasName("PK_CustSuppPeople")
        .IsClustered(false);

    entity.ToTable("MA_CustSuppPeople");

    entity.Property(e => e.CustSupp)
        .HasMaxLength(12)
        .IsUnicode(false);

    entity.Property(e => e.AccompanyingInvoices).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.AllDocuments).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.Branch)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.CorrectionAccInvoice).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.CorrectionInvoice).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.CorrectionReceipt).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.CreditNote).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.CustomerQuotation).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.DebitNote).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.DeliveryNote).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.Email)
        .HasColumnName("EMail")
        .HasMaxLength(128)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.ExternalCode)
        .HasMaxLength(12)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Fax)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Invoice).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.InvoiceForAdvance).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.LastName)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.LegalRepresentative)
        .HasMaxLength(1)
        .IsUnicode(false)
        .IsFixedLength()
        .HasDefaultValueSql("('0')");

    entity.Property(e => e.Name)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.NonCollectedReceipt).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.Notes)
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.PickingList).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.ProformaInvoice).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.PurchaseOrder).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.Receipt).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.ReturnFromCustomer).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.ReturnToSupplier).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.SaleOrder).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.SkypeId)
        .HasColumnName("SkypeID")
        .HasMaxLength(64)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.SubcontrDeliveryNote).HasDefaultValueSql("((12451840))");

    entity.Property(e => e.SupplierQuotation).HasDefaultValueSql("((12451840))");

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

    entity.Property(e => e.Telephone1)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Telephone2)
        .HasMaxLength(20)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.Telex)
        .HasMaxLength(16)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.TitleCode)
        .HasMaxLength(8)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.Property(e => e.WorkingPosition)
        .HasMaxLength(32)
        .IsUnicode(false)
        .HasDefaultValueSql("('')");

    entity.HasOne(d => d.CustSuppNavigation)
        .WithMany(p => p.MaCustSuppPeople)
        .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_CustSuppPe_CustSupp_01");
});
            modelBuilder.Entity<MaCustSuppSupplierOptions>(entity =>
            {
                entity.HasKey(e => new { e.CustSuppType, e.Supplier })
                    .HasName("PK_CustSuppSupplierOptions")
                    .IsClustered(false);

                entity.ToTable("MA_CustSuppSupplierOptions");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlockPayments)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Blocked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Carrier1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier3)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashOnDeliveryLevel).HasDefaultValueSql("((0))");

                entity.Property(e => e.CashOnDeliveryLevelDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Category)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ChargesType).HasDefaultValueSql("((25559040))");

                entity.Property(e => e.CreditFreeSamplesTaxAmount).HasDefaultValueSql("((3276802))");

                entity.Property(e => e.CustomTariff)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExemptFromTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GoodsOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GroupCollectionCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.GroupPymtOrders)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.GroupStampCharges)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastDocDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastDocTotal).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastPaymentTerm)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaximumCredit).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaximumCreditCheckType).HasDefaultValueSql("((11599872))");

                entity.Property(e => e.MaximumCreditDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.NoDngeneration)
                    .HasColumnName("NoDNGeneration")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Package)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferencesPrintType).HasDefaultValueSql("((524293))");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServicesOffset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Shipping)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShowPricesOnDn)
                    .HasColumnName("ShowPricesOnDN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SupplierClassification)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierSpecification)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SupplierType).HasDefaultValueSql("((7733248))");

                entity.Property(e => e.SuspendedTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TaxCode)
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

                entity.Property(e => e.Transport)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.MaCustSupp)
                    .WithOne(p => p.MaCustSuppSupplierOptions)
                    .HasForeignKey<MaCustSuppSupplierOptions>(d => new { d.CustSuppType, d.Supplier })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustSuppSu_CustSupp_00");
            });
            modelBuilder.Entity<MaPlafond>(entity =>
            {
                entity.HasKey(e => new { e.BalanceYear, e.BalanceMonth })
                    .HasName("PK_Plafond")
                    .IsClustered(false);

                entity.ToTable("MA_Plafond");

                entity.Property(e => e.Eupurchases)
                    .HasColumnName("EUPurchases")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastEupurchases)
                    .HasColumnName("ForecastEUPurchases")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastImporting).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForecastInside).HasDefaultValueSql("((0))");

                entity.Property(e => e.Importing).HasDefaultValueSql("((0))");

                entity.Property(e => e.Inside).HasDefaultValueSql("((0))");

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
            modelBuilder.Entity<MaSddmandate>(entity =>
            {
                entity.HasKey(e => e.MandateCode)
                    .HasName("PK_SDDMandate")
                    .IsClustered(false);

                entity.ToTable("MA_SDDMandate");

                entity.Property(e => e.MandateCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerCa)
                    .HasColumnName("CustomerCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerIban)
                    .HasColumnName("CustomerIBAN")
                    .HasMaxLength(34)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerIbanisManual)
                    .HasColumnName("CustomerIBANIsManual")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Ddmandate)
                    .HasColumnName("DDMandate")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Draft)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MandateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.MandateFirstDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.MandateLastDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.MandateOneOff)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MandateType).HasDefaultValueSql("((2686997))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PrintDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Printed)
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

                entity.Property(e => e.Umrcode)
                    .HasColumnName("UMRCode")
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<ImCustSuppPolicies>(entity =>
            {
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp })
                    .IsClustered(false);

                entity.ToTable("IM_CustSuppPolicies");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmailBcc)
                    .HasColumnName("EMailBcc")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmailCc)
                    .HasColumnName("EMailCc")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EmailTo)
                    .HasColumnName("EMailTo")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceRefType).HasDefaultValueSql("((17039360))");

                entity.Property(e => e.InvoiceType).HasDefaultValueSql("((16449536))");

                entity.Property(e => e.Policy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SoarefType)
                    .HasColumnName("SOARefType")
                    .HasDefaultValueSql("((16973824))");

                entity.Property(e => e.SoawithDescriptions)
                    .HasColumnName("SOAWithDescriptions")
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

                entity.Property(e => e.WrbyEmail)
                    .HasColumnName("WRByEmail")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.CustSuppNavigation)
                    .WithOne(p => p.ImCustSuppPolicies)
                    .HasForeignKey<ImCustSuppPolicies>(d => new { d.CustSuppType, d.CustSupp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IM_CustSuppPolicies_MA_CustSupp");
            });
            modelBuilder.Entity<ImSuppliersDiscounts>(entity =>
            {
                entity.HasKey(e => new { e.CustSuppType, e.CustSupp, e.Producer, e.ProductCtg, e.ProductSubCtg })
                    .IsClustered(false);

                entity.ToTable("IM_SuppliersDiscounts");

                entity.HasIndex(e => new { e.Producer, e.ProductCtg, e.ProductSubCtg, e.CustSuppType, e.CustSupp })
                    .HasName("IM_SuppliersDiscounts_2");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211265))");

                entity.Property(e => e.CustSupp)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Producer)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductSubCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CalcolateStandardCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CalculationBase).HasDefaultValueSql("((19005440))");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
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

                entity.HasOne(d => d.CustSuppNavigation)
                    .WithMany(p => p.ImSuppliersDiscounts)
                    .HasForeignKey(d => new { d.CustSuppType, d.CustSupp })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IM_SuppliersDiscounts_MA_CustSupp");
            });
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

            #endregion
            #region MaSaleOrd
            modelBuilder.Entity<MaSaleOrd>(entity =>
            {
                entity.HasKey(e => e.SaleOrdId)
                    .HasName("PK_SaleOrd")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrd");

                entity.HasIndex(e => e.Allocated)
                    .HasName("MA_SaleOrd7");

                entity.HasIndex(e => e.Delivered)
                    .HasName("MA_SaleOrd5");

                entity.HasIndex(e => e.InternalOrdNo)
                    .HasName("MA_SaleOrd2");

                entity.HasIndex(e => e.Invoiced)
                    .HasName("MA_SaleOrd6");

                entity.HasIndex(e => e.PreShipped)
                    .HasName("MA_SaleOrd8");

                entity.HasIndex(e => new { e.Customer, e.OrderDate })
                    .HasName("MA_SaleOrd3");

                entity.HasIndex(e => new { e.OrderDate, e.InternalOrdNo })
                    .HasName("MA_SaleOrd4");

                entity.Property(e => e.SaleOrdId).ValueGeneratedNever();

                entity.Property(e => e.AccGroup)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccrualPercAtInvoiceDate).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AccrualType).HasDefaultValueSql("((3473408))");

                entity.Property(e => e.ActiveSubcontracting)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Allocated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllocationArea)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Archived)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Area)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaManager)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaManagerCommAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AreaManagerCommPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerCommPercAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.AreaManagerCommTot).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerPolicy)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BankAuthorization)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BaseAreaManager).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BaseSalesperson).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BlockType).HasDefaultValueSql("((28180480))");

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Carrier1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyCa)
                    .HasColumnName("CompanyCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompanyPymtCa)
                    .HasColumnName("CompanyPymtCA")
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CompulsoryDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ConfirmedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ContractCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContractNo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ContractType).HasDefaultValueSql("((25690113))");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustSuppType).HasDefaultValueSql("((3211264))");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerBank)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Delivered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ExternalOrdNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fixing).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FixingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FixingIsManual)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FromExternalProgram).HasDefaultValueSql("((32505856))");

                entity.Property(e => e.InstallmStartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.InstallmStartDateIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.InternalOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceFollows)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Invoiced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoicingCustomer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsBlocked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.NetOfTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NonStandardPayment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                //entity.Property(e => e.Notes)
                //    .HasColumnType("nvarchar(max)")
                //    .HasDefaultValueSql("('')");

                entity.Property(e => e.OpenOrder)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.OurReference)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Package)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Picked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PreShipped)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Presentation).HasDefaultValueSql("((1376256))");

                entity.Property(e => e.PriceList)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PriceListFromDeliveryDate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PriceListValidityDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Printed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleType).HasDefaultValueSql("((3670020))");

                entity.Property(e => e.SaleTypeByLine)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Salesperson)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SalespersonCommAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SalespersonCommPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SalespersonCommPercAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SalespersonCommTot).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SalespersonPolicy)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SendDocumentsTo)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SentByEmail)
                    .HasColumnName("SentByEMail")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SentByPostaLite)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShipToAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingReason)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SingleDelivery)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Specificator1Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.Specificator2Type).HasDefaultValueSql("((6750211))");

                entity.Property(e => e.SpecificatorPhase1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StubBook)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubIdAttivita).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubIdContratto).HasDefaultValueSql("((0))");

                entity.Property(e => e.SubIdDescrizione).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxCommunicationGroup)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxJournal)
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

                entity.Property(e => e.Transport)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UnblockDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.UnblockWorker).HasDefaultValueSql("((0))");

                entity.Property(e => e.UseBusinessYear)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.YourReference)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaSaleOrdComponents>(entity =>
            {
                entity.HasKey(e => new { e.SaleOrdId, e.SaleOrdSubId, e.Line })
                    .HasName("PK_SaleOrdComponents")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdComponents");

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FixedQty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NeededQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NeededQtyWaste).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Waste)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WasteUnitValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.WasteUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.MaSaleOrdComponents)
                    .HasForeignKey(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdCom_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdDetails>(entity =>
            {
                entity.HasKey(e => new { e.SaleOrdId, e.Line })
                    .HasName("PK_SaleOrdDetails")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdDetails");

                entity.HasIndex(e => e.Allocated)
                    .HasName("MA_SaleOrdDetails6");

                entity.HasIndex(e => new { e.Item, e.ExpectedDeliveryDate })
                    .HasName("MA_SaleOrdDetails3");

                entity.HasIndex(e => new { e.SaleOrdId, e.Position })
                    .HasName("MA_SaleOrdDetails7");

                entity.HasIndex(e => new { e.Delivered, e.ExpectedDeliveryDate, e.Item })
                    .HasName("MA_SaleOrdDetails2");

                entity.HasIndex(e => new { e.ProductionPlanId, e.ProductionPlanLine, e.Item })
                    .HasName("MA_SaleOrdDetails8");

                entity.HasIndex(e => new { e.ExpectedDeliveryDate, e.Item, e.LineType, e.Delivered, e.Cancelled })
                    .HasName("MA_SaleOrdDetails5");

                entity.HasIndex(e => new { e.Item, e.ExpectedDeliveryDate, e.LineType, e.Delivered, e.Cancelled })
                    .HasName("MA_SaleOrdDetails4");

                entity.Property(e => e.AdditionalQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalQty1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalQty2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalQty3).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AllCanoniDataF)
                    .HasColumnName("ALL_CanoniDataF")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.AllCanoniDataI)
                    .HasColumnName("ALL_CanoniDataI")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.AllNrCanoni)
                    .HasColumnName("ALL_NrCanoni")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Allocated)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.AllocatedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerComm).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerCommAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AreaManagerCommCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AreaManagerCommCtgAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.AreaManagerCommPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AreaManagerCommPercAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.BaseAreaManager).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.BaseSalesperson).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Bomitem)
                    .HasColumnName("BOMItem")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BookedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CommPerc).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CommPercAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CommissionCtg)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfirmationLevel)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ConfirmedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ContractCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCenter)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CrossDocking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CrrefId)
                    .HasColumnName("CRRefID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefSubId)
                    .HasColumnName("CRRefSubID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CrrefType)
                    .HasColumnName("CRRefType")
                    .HasDefaultValueSql("((27066368))");

                entity.Property(e => e.Customer)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustomerLotNo)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Delivered)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DeliveredQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Department)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Drawing)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InEi)
                    .HasColumnName("InEI")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InternalOrdNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Invoiced)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InvoicedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Job)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.KitQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.LineType).HasDefaultValueSql("((3538947))");

                entity.Property(e => e.NetPrice).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NetPriceIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NetWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NoDn)
                    .HasColumnName("NoDN")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoPrint)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Offset)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.PacksUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Picked)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PickedAndDeliveredQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PickedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PreShipped)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreShippedAndDeliveredQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PreShippedQty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PriceList)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductLine)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductionJobId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionJobNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductionJobSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionPlanId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionPlanNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Qty).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ReferenceDocId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceDocNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenceQuotation)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReferenceQuotationId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceQuotationSubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferredPosition).HasDefaultValueSql("((0))");

                entity.Property(e => e.SaleType).HasDefaultValueSql("((3670020))");

                entity.Property(e => e.SalespersonComm).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SalespersonCommAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SalespersonCommCtgAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.SalespersonDiscount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.SpecificatorPhase1)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecificatorPhase2)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoragePhase2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubId).HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.MaSaleOrdDetails)
                    .HasForeignKey(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdDet_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdNotes>(entity =>
            {
                entity.HasKey(e => e.SaleOrdId)
                    .HasName("PK_SaleOrdNotes")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdNotes");

                entity.Property(e => e.SaleOrdId).ValueGeneratedNever();

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

                entity.HasOne(d => d.SaleOrd)
                    .WithOne(p => p.MaSaleOrdNotes)
                    .HasForeignKey<MaSaleOrdNotes>(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdNot_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdPymtSched>(entity =>
            {
                entity.HasKey(e => new { e.SaleOrdId, e.InstallmentNo })
                    .HasName("PK_SaleOrdPymtSched")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdPymtSched");

                entity.Property(e => e.Amount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DueDateDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.InstallmStartDate).HasDefaultValueSql("((7602177))");

                entity.Property(e => e.InstallmentType).HasDefaultValueSql("((5505024))");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0.00))");

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

                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.MaSaleOrdPymtSched)
                    .HasForeignKey(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdPym_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdReferences>(entity =>
            {
                entity.HasKey(e => new { e.SaleOrdId, e.Line })
                    .HasName("PK_SaleOrdReferences")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdReferences");

                entity.Property(e => e.DocumentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.DocumentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.DocumentNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DocumentType).HasDefaultValueSql("((6684681))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
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

                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.MaSaleOrdReferences)
                    .HasForeignKey(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdRef_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdShipping>(entity =>
            {
                entity.HasKey(e => e.SaleOrdId)
                    .HasName("PK_SaleOrdShipping")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdShipping");

                entity.Property(e => e.SaleOrdId).ValueGeneratedNever();

                entity.Property(e => e.Appearance)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Carrier3)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossVolumeIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GrossWeightIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NetWeight).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.NetWeightIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NoOfPacksIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Package)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Port)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PortAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ShipToAddress)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Shipping)
                    .HasMaxLength(16)
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

                entity.Property(e => e.Transport)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UseOrderPort)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.HasOne(d => d.SaleOrd)
                    .WithOne(p => p.MaSaleOrdShipping)
                    .HasForeignKey<MaSaleOrdShipping>(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdShi_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdSummary>(entity =>
            {
                entity.HasKey(e => e.SaleOrdId)
                    .HasName("PK_SaleOrdSummary")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdSummary");

                entity.Property(e => e.SaleOrdId).ValueGeneratedNever();

                entity.Property(e => e.AdditionalCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.AdditionalChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Advance).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Allowances).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CashOnDeliveryCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CashOnDeliveryPercentage).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CollectionCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CollectionChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CollectionChargesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiscountOnGoods).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountOnServices).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Discounts).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DiscountsIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.FreeSamples).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.FreeSamplesDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GoodsAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.GoodsAmountWithTax).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InsuranceCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InsuranceChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PackagingCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PackagingChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PayableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PayableAmountInBaseCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.PostAdvancesToAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReturnedMaterial).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServiceAmounts).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ServiceAmountsWithTax).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShippingCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ShippingChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.ShippingChargesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StampsCharges).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.StampsChargesIsAuto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.StampsChargesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmountDocCurr).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.TotalAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.SaleOrd)
                    .WithOne(p => p.MaSaleOrdSummary)
                    .HasForeignKey<MaSaleOrdSummary>(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdSum_SaleOrd_00");
            });
            modelBuilder.Entity<MaSaleOrdTaxSummary>(entity =>
            {
                entity.HasKey(e => new { e.SaleOrdId, e.TaxCode })
                    .HasName("PK_SaleOrdTaxSummary")
                    .IsClustered(false);

                entity.ToTable("MA_SaleOrdTaxSummary");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.TaxAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmount).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.TaxableAmountDocCurr).HasDefaultValueSql("((0.00))");

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

                entity.Property(e => e.TotalAmountDocCurr).HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.SaleOrd)
                    .WithMany(p => p.MaSaleOrdTaxSummary)
                    .HasForeignKey(d => d.SaleOrdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SaleOrdTax_SaleOrd_00");
            });
            #endregion
            #region Item
            modelBuilder.Entity<MaItems>(entity =>
             {
                 entity.HasKey(e => e.Item)
                     .HasName("PK_Items")
                     .IsClustered(false);

                 entity.ToTable("MA_Items");

                 entity.HasIndex(e => new { e.Disabled, e.Item })
                     .HasName("IX_MA_Items_3");

                 entity.HasIndex(e => new { e.IsGood, e.Item })
                     .HasName("IX_MA_Items_2");

                 entity.HasIndex(e => new { e.Item, e.IsGood })
                     .HasName("IX_MA_Items_1");

                 entity.HasIndex(e => new { e.SaleBarCode, e.Item })
                     .HasName("IX_MA_Items_4");

                 entity.Property(e => e.Item)
                     .HasMaxLength(21)
                     .IsUnicode(false);

                 entity.Property(e => e.AdditionalCharge)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("((0))");

                 entity.Property(e => e.Allcadenza)
                     .HasColumnName("ALLCadenza")
                     .HasDefaultValueSql("((2009399296))");

                 entity.Property(e => e.AllesplodiInOrdine)
                     .HasColumnName("ALLEsplodiInOrdine")
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.AllisCanone)
                     .HasColumnName("ALLIsCanone")
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.Allperiodo)
                     .HasColumnName("ALLPeriodo")
                     .HasDefaultValueSql("((1094254592))");

                 entity.Property(e => e.AuthorCode)
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.AvailabilityDate)
                     .HasColumnType("datetime")
                     .HasDefaultValueSql("('17991231')");

                 entity.Property(e => e.BarcodeSegment)
                     .HasMaxLength(21)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.BasePrice).HasDefaultValueSql("((0))");

                 entity.Property(e => e.BasePriceWithTax)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.BaseUoM)
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.CanBeDisabled)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.CommissionCtg)
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.CommodityCtg)
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.ConsuptionOffset)
                     .HasMaxLength(16)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.CostCenter)
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.CoverPrice).HasDefaultValueSql("((0))");

                 entity.Property(e => e.CreationDate)
                     .HasColumnType("datetime")
                     .HasDefaultValueSql("('17991231')");

                 entity.Property(e => e.Description)
                     .HasMaxLength(128)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.DescriptionText)
                     .HasMaxLength(64)
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

                 entity.Property(e => e.Draft)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.EiadminstrativeRef)
                     .HasColumnName("EIAdminstrativeRef")
                     .HasMaxLength(20)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.EitypeCode)
                     .HasColumnName("EITypeCode")
                     .HasMaxLength(35)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.EivalueCode)
                     .HasColumnName("EIValueCode")
                     .HasMaxLength(35)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.HasCustomers)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.HasSuppliers)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.HomogeneousCtg)
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.ImGroupCode)
                     .HasColumnName("IM_GroupCode")
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.ImMacroGroupCode)
                     .HasColumnName("IM_MacroGroupCode")
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.ImPappAskValue)
                     .HasColumnName("IM_PAppAskValue")
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.ImPappDontShow)
                     .HasColumnName("IM_PAppDontShow")
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.ImSubGroupCode)
                     .HasColumnName("IM_SubGroupCode")
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.ImSubcontractService)
                     .HasColumnName("IM_SubcontractService")
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.InternalNote)
                     .HasMaxLength(128)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.IsGood)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.Isbn)
                     .HasColumnName("ISBN")
                     .HasMaxLength(15)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.ItemCodes)
                     .HasMaxLength(16)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.ItemType)
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.Job)
                     .HasMaxLength(10)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.KitExpansion)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.Markup).HasDefaultValueSql("((0))");

                 entity.Property(e => e.ModificationDate)
                     .HasColumnType("datetime")
                     .HasDefaultValueSql("('17991231')");

                 entity.Property(e => e.Nature).HasDefaultValueSql("((22413314))");

                 entity.Property(e => e.NoAddDiscountInSaleDoc)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.NoUoMsearch)
                     .HasColumnName("NoUoMSearch")
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.NotPostable)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.OldItem)
                     .HasMaxLength(21)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.Picture)
                     .HasMaxLength(128)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.PostKitComponents)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.Producer)
                     .HasMaxLength(16)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.ProductCtg)
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.ProductLine)
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.ProductSubCtg)
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.PublicNote)
                     .HasMaxLength(128)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.PurchaseOffset)
                     .HasMaxLength(16)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.PurchaseType).HasDefaultValueSql("((3670020))");

                 entity.Property(e => e.RctaxCode)
                     .HasColumnName("RCTaxCode")
                     .HasMaxLength(4)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.RetailCtg)
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.ReverseCharge)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.SaleBarCode)
                     .HasMaxLength(21)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.SaleOffset)
                     .HasMaxLength(16)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.SaleType).HasDefaultValueSql("((3670020))");

                 entity.Property(e => e.SalespersonComm).HasDefaultValueSql("((0))");

                 entity.Property(e => e.SecondRate)
                     .HasMaxLength(21)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.SecondRateUoM)
                     .HasMaxLength(8)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.ShortDescription)
                     .HasMaxLength(40)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.StandardCostDate)
                     .HasColumnType("datetime")
                     .HasDefaultValueSql("('17991231')");

                 entity.Property(e => e.SubjectToWithholdingTax)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.TaxCode)
                     .HasMaxLength(4)
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

                 entity.Property(e => e.TschargeType)
                     .HasColumnName("TSChargeType")
                     .HasMaxLength(2)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.TschargeTypeFlag)
                     .HasColumnName("TSChargeTypeFlag")
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .HasDefaultValueSql("('')");

                 entity.Property(e => e.UseSerialNo)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('0')");

                 entity.Property(e => e.Valorize)
                     .HasMaxLength(1)
                     .IsUnicode(false)
                     .IsFixedLength()
                     .HasDefaultValueSql("('1')");

                 entity.HasMany(d => d.AllordCliContratto)
                     .WithOne(p => p.MaItems)
                     .HasForeignKey(d => d.Servizio)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_AllordCliContratto_Servizio_00");

                 entity.HasMany(d => d.AllordCliContrattoDistinta)
                    .WithOne(p => p.MaItems)
                    .HasForeignKey(d => d.Servizio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllordCliContrattoDistinta_Servizio_00");

                 entity.HasMany(d => d.AllordCliContrattoDistintaServAgg)
                    .WithOne(p => p.MaItems)
                    .HasForeignKey(d => d.Servizio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllordCliContrattoDistintaServAgg_Servizio_00");

             });
            modelBuilder.Entity<MaItemsGoodsData>(entity =>
            {
                entity.HasKey(e => e.Item)
                    .HasName("PK_ItemsGoodsData")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsGoodsData");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Appearance)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DefaultLocation)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Department)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0))");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.ImWeeeamount)
                    .HasColumnName("IM_WEEEAmount")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.InsertAnalParam)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IssueUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LastIssueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastReceiptDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.LastSupplier)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Location)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LotPreexpiringDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.LotValidityDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.ManageSample)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MaxUnsoldMonths).HasDefaultValueSql("((0))");

                entity.Property(e => e.MaximumStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinimumSaleQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinimumStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.NetWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoAbc)
                    .HasColumnName("NoABC")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoOfPacks).HasDefaultValueSql("((0))");

                entity.Property(e => e.OnInventoryLevel)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OnInventorySheets)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PacksIssueUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PacksReceiptUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PercSample).HasDefaultValueSql("((100))");

                entity.Property(e => e.PostToInspection)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReceiptUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReorderingLotSize).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReportUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SampleQty).HasDefaultValueSql("((0))");

                // entity.Property(e => e.SpecificationsForSupplier)
                //    .HasColumnType("nvarchar(max)")
                //    .HasDefaultValueSql("('')");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(12)
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

                entity.Property(e => e.TraceabilityCritical)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseLots)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UseSupplierLotAsNewLotNumber).HasDefaultValueSql("((28311552))");

                entity.Property(e => e.Weeeamount)
                    .HasColumnName("WEEEAmount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Weeeamount2)
                    .HasColumnName("WEEEAmount2")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Weeectg)
                    .HasColumnName("WEEECtg")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Weeectg2)
                    .HasColumnName("WEEECtg2")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.ItemNavigation)
                    .WithOne(p => p.MaItemsGoodsData)
                    .HasForeignKey<MaItemsGoodsData>(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsGoods_Items_00");
            });
            modelBuilder.Entity<MaItemsIntrastat>(entity =>
            {
                entity.HasKey(e => e.Item)
                    .HasName("PK_ItemsIntrastat")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsIntrastat");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.CombinedNomenclature)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CountyOfOrigin)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cpacode)
                    .HasColumnName("CPACode")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IntrastatSupplyType).HasDefaultValueSql("((589824))");

                entity.Property(e => e.IsoofOrigin)
                    .HasColumnName("ISOOfOrigin")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Prodcom)
                    .HasColumnName("PRODCOM")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SpecWeightNetMass).HasDefaultValueSql("((0))");

                entity.Property(e => e.SuppUnitDescription)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuppUnitSpecWeight).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ItemNavigation)
                    .WithOne(p => p.MaItemsIntrastat)
                    .HasForeignKey<MaItemsIntrastat>(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsIntra_ItemsIntra_00");
            });
            modelBuilder.Entity<MaItemsManufacturingData>(entity =>
            {
                entity.HasKey(e => e.Item)
                    .HasName("PK_ItemsManufacturingData")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsManufacturingData");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.AnticipationDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bomcost)
                    .HasColumnName("BOMCost")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ConfirmIntegratePl)
                    .HasColumnName("ConfirmIntegratePL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfirmMajorPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfirmMinorPicking)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ConfirmReturnMaterial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.EconomicOrderQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ExtraordinaryMaintenance)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Factory)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InhouseProcessingCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsKanban)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.IsTool)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ItemManQtyDigit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ItemManQtyRounding).HasDefaultValueSql("((786432))");

                entity.Property(e => e.ItemManufStorage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ItemPickAlsoShortages)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.KanbanCardSize).HasDefaultValueSql("((0))");

                entity.Property(e => e.KanbanCardsNum).HasDefaultValueSql("((0))");

                entity.Property(e => e.KanbanCardsToReorder).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastProductionCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.LeadTime).HasDefaultValueSql("((0))");

                entity.Property(e => e.LoadingCriterionValuation).HasDefaultValueSql("((20643840))");

                entity.Property(e => e.LotGenerationMoment).HasDefaultValueSql("((25821186))");

                entity.Property(e => e.MakeOrBuy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MakeOrBuyType).HasDefaultValueSql("((2032140288))");

                entity.Property(e => e.Maker)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaxProductionQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinProductionQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Model)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MrpconfirmationRank)
                    .HasColumnName("MRPConfirmationRank")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Mrppolicy)
                    .HasColumnName("MRPPolicy")
                    .HasDefaultValueSql("((22609920))");

                entity.Property(e => e.MultipleLots)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MultipleRoundQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.NetByJobMopurchOrd)
                    .HasColumnName("NetByJobMOPurchOrd")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NetByMoconfirmed)
                    .HasColumnName("NetByMOConfirmed")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NetByMoemptyJob)
                    .HasColumnName("NetByMOEmptyJob")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoMrp)
                    .HasColumnName("NoMRP")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OrderReleaseDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrdinaryMaintenance)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutsourcedProcessingCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductionCostLastChange)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.ProductionCostMono)
                    .HasColumnName("ProductionCostMONo")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProductionLot).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProportionalLeadTime)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReferenceLot).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReorderPoint).HasDefaultValueSql("((0))");

                entity.Property(e => e.Rmcost)
                    .HasColumnName("RMCost")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RoundQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SamplesQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SetupCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.StockLevelHorizon).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.TimeRoundingType).HasDefaultValueSql("((22544384))");

                entity.Property(e => e.UseItemManufParameters)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.VariantCost).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ItemNavigation)
                    .WithOne(p => p.MaItemsManufacturingData)
                    .HasForeignKey<MaItemsManufacturingData>(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsManuf_Items_00");
            });
            modelBuilder.Entity<MaItemNotes>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.Line })
                    .HasName("PK_ItemNotes")
                    .IsClustered(false);

                entity.ToTable("MA_ItemNotes");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShowInPurchases)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ShowInSales)
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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemNotes)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemNo_Item_09");
            });
            modelBuilder.Entity<MaItemsComparableUoM>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.ComparableUoM })
                    .HasName("PK_ItemsComparableUoM")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsComparableUoM");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ComparableUoM)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.BaseUoMqty)
                    .HasColumnName("BaseUoMQty")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CompUoMqty)
                    .HasColumnName("CompUoMQty")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor1).HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor1Description)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Factor2).HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor2Description)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Factor3).HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor3Description)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Factor4).HasDefaultValueSql("((1))");

                entity.Property(e => e.Factor4Description)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GrossVolume).HasDefaultValueSql("((0))");

                entity.Property(e => e.GrossWeight).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDisabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoOfPacksCompUoM).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Packaging)
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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsComparableUoM)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsCompa_Items_00");
            });
            modelBuilder.Entity<MaItemsFifo>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.FiscalYear })
                    .HasName("PK_ItemsFIFO")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsFIFO");

                entity.HasIndex(e => new { e.FiscalYear, e.Item })
                    .HasName("IX_MA_ItemsFIFO_1");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.FinalBookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalBookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProducedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.RevaluationDone)
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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsFifo)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsFIFO_Items_00");
            });
            modelBuilder.Entity<MaItemsFifodomCurr>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.FiscalYear })
                    .HasName("PK_ItemsFIFODomCurr")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsFIFODomCurr");

                entity.HasIndex(e => new { e.FiscalYear, e.Item })
                    .HasName("IX_MA_ItemsFIFODomCurr_1");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.FinalBookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesValue).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsFifodomCurr)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsFIFOD_Items_00");
            });
            modelBuilder.Entity<MaItemsFiscalData>(entity =>
            {
                entity.HasKey(e => new { e.FiscalYear, e.FiscalPeriod, e.Storage, e.Item })
                    .HasName("PK_ItemsFiscalData")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsFiscalData");

                entity.HasIndex(e => e.ValueType)
                    .HasName("IX_MA_ItemsFiscalData");

                entity.Property(e => e.FiscalPeriod).HasDefaultValueSql("((1))");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.AllocatedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ApprovedPurchaseReq).HasDefaultValueSql("((0))");

                entity.Property(e => e.Bailment).HasDefaultValueSql("((0))");

                entity.Property(e => e.BookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.BookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cigvalue)
                    .HasColumnName("CIGValue")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty1).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty2).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty3).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty4).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty5).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue1).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue2).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue3).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue4).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue5).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalOnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForRepairing).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForSubcontracting).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialBailment).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialBookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialBookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomQty1).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomQty2).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomQty3).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomQty4).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomQty5).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomValue1).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomValue2).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomValue3).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomValue4).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialCustomValue5).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialForRepairing).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialForSubcontracting).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialOnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialOnHandStorageTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialReservedCustQuota).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialReservedStorageTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialReturnedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialSampleGoods).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialSampling).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialSubcontracting).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialUsedByProduction).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialUsedInProductionValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.InventoryValueCriteria).HasDefaultValueSql("((4259840))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastLotNo).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoAbcvalue)
                    .HasColumnName("NoABCValue")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.OnHandStorageTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedPurchOrd).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedToProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedToProdIe)
                    .HasColumnName("OrderedToProdIE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PickedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickingValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedByProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedCustQuota).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedSaleOrd).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedStorageTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SampleGoods).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sampling).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapsValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SecondLastCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.StandardCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.Subcontracting).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UsedByProduction).HasDefaultValueSql("((0))");

                entity.Property(e => e.UsedInProductionValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ValueType).HasDefaultValueSql("((11272194))");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsFiscalData)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsFisca_Items_00");
            });
            modelBuilder.Entity<MaItemsFiscalDataDomCurr>(entity =>
            {
                entity.HasKey(e => new { e.FiscalYear, e.FiscalPeriod, e.Item })
                    .HasName("PK_ItemsFiscalDataDomCurr")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsFiscalDataDomCurr");

                entity.Property(e => e.FiscalPeriod).HasDefaultValueSql("((1))");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.BookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.InitialBookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapsValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SecondLastCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.StandardCost).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsFiscalDataDomCurr)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsFisca_Items_01");
            });
            modelBuilder.Entity<MaItemsKit>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.Line })
                    .HasName("PK_ItemsKit")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsKit");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.BasePrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.Component)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Discount1).HasDefaultValueSql("((0))");

                entity.Property(e => e.Discount2).HasDefaultValueSql("((0))");

                entity.Property(e => e.DiscountFormula)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.NoPrint)
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

                entity.Property(e => e.Variant)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsKit)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsKit_Items_00");
            });
            modelBuilder.Entity<MaItemsLanguageDescri>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.Language })
                    .HasName("PK_ItemsLanguageDescri")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsLanguageDescri");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescriptionText)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PublicNote)
                    .HasMaxLength(64)
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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsLanguageDescri)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsLangu_Items_00");
            });
            modelBuilder.Entity<MaItemsLifo>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.FiscalYear })
                    .HasName("PK_ItemsLIFO")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsLIFO");

                entity.HasIndex(e => new { e.FiscalYear, e.Item })
                    .HasName("IX_MA_ItemsLIFO_1");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.FinalBookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalBookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevaluationDone)
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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsLifo)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsLIFO_Items_00");
            });
            modelBuilder.Entity<MaItemsLifodomCurr>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.FiscalYear })
                    .HasName("PK_ItemsLIFODomCurr")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsLIFODomCurr");

                entity.HasIndex(e => new { e.FiscalYear, e.Item })
                    .HasName("IX_MA_ItemsLIFODomCurr_1");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.FinalBookInvValue).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsLifodomCurr)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsLIFOD_Items_00");
            });
            modelBuilder.Entity<MaItemsMonthlyBalances>(entity =>
            {
                entity.HasKey(e => new { e.Storage, e.Item, e.FiscalYear, e.BalanceYear, e.Balance, e.BalanceMonth })
                    .HasName("PK_ItemsMonthlyBalances")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsMonthlyBalances");

                entity.HasIndex(e => new { e.FiscalYear, e.Item })
                    .HasName("IX_MA_ItemsMonthlyBalances_1");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('-')");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Bailment).HasDefaultValueSql("((0))");

                entity.Property(e => e.BookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.BookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.Cigvalue)
                    .HasColumnName("CIGValue")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CigvalueForFiscalPeriod)
                    .HasColumnName("CIGValueForFiscalPeriod")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty1).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty2).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty3).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty4).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomQty5).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue1).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue2).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue3).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue4).HasDefaultValueSql("((0))");

                entity.Property(e => e.CustomValue5).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalBookInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalBookInvValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.FinalOnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForRepairing).HasDefaultValueSql("((0))");

                entity.Property(e => e.ForSubcontracting).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.OnHandStorageTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedToProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickingValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickingValueForFiscalPeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProducedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PurchasesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedByProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedStorageTot).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReturnedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesQtyForFiscalPeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesValueForFiscalPeriod).HasDefaultValueSql("((0))");

                entity.Property(e => e.SampleGoods).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sampling).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ScrapsValue).HasDefaultValueSql("((0))");

                entity.Property(e => e.SecondLastCost).HasDefaultValueSql("((0))");

                entity.Property(e => e.Subcontracting).HasDefaultValueSql("((0))");

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

                entity.Property(e => e.UsedInProductionQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.UsedInProductionValue).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsMonthlyBalances)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsMonth_Items_00");
            });
            modelBuilder.Entity<MaItemsPriceLists>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.PriceList, e.ValidityStartingDate, e.Qty })
                    .HasName("PK_ItemsPriceLists")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsPriceLists");

                entity.HasIndex(e => new { e.PriceList, e.Item, e.ValidityStartingDate, e.Qty })
                    .HasName("IX_MA_ItemsPriceLists_1");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.PriceList)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.ValidityStartingDate).HasColumnType("datetime");

                entity.Property(e => e.AlwaysShow)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

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

                entity.Property(e => e.Discounted)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LastModificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Price).HasDefaultValueSql("((0))");

                entity.Property(e => e.PriceListUoM)
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

                entity.Property(e => e.ValidityEndingDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.WithTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsPriceLists)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsPrice_Items_00");
            });
            modelBuilder.Entity<MaItemsPurchaseBarCode>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.BarCode })
                    .HasName("PK_ItemsPurchaseBarCode")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsPurchaseBarCode");

                entity.HasIndex(e => e.BarCode)
                    .HasName("IX_MA_ItemsPurchaseBarCode_");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.BarCode)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.BarCodeType).HasDefaultValueSql("((5636117))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsPurchaseBarCode)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsPurch_Items_00");
            });
            modelBuilder.Entity<MaItemsStorageQty>(entity =>
            {
                entity.HasKey(e => new { e.FiscalYear, e.FiscalPeriod, e.Item, e.Storage, e.Specificator, e.SpecificatorType })
                    .HasName("PK_ItemsStorageQty")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsStorageQty");

                entity.HasIndex(e => new { e.FiscalYear, e.FiscalPeriod, e.Storage, e.Item })
                    .HasName("IX_MA_ItemsStorageQty_1");

                entity.HasIndex(e => new { e.FiscalYear, e.FiscalPeriod, e.Storage, e.SpecificatorType, e.Specificator, e.Item })
                    .HasName("IX_MA_ItemsStorageQty_2");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.AllocatedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ApprovedPurchaseReq).HasDefaultValueSql("((0))");

                entity.Property(e => e.DefaultLocation)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InitialQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.MathematicRounding)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.MaximumStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinimumStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedPurchOrd).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedToProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReorderingLotSize).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedByProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedSaleOrd).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsStorageQty)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsStora_Items_00");
            });
            modelBuilder.Entity<MaItemsStorageQtyMonthly>(entity =>
            {
                entity.HasKey(e => new { e.Storage, e.Specificator, e.SpecificatorType, e.Item, e.FiscalYear, e.BalanceYear, e.Balance, e.BalanceMonth })
                    .HasName("PK_ItemsStorageMonthly")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsStorageQtyMonthly");

                entity.HasIndex(e => new { e.FiscalYear, e.Storage, e.Item })
                    .HasName("IX_MA_ItemsStorageMonthly_1");

                entity.HasIndex(e => new { e.FiscalYear, e.Storage, e.SpecificatorType, e.Specificator, e.Item })
                    .HasName("IX_MA_ItemsStorageMonthly_2");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Specificator)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedPurchaseReq).HasDefaultValueSql("((0))");

                entity.Property(e => e.IssuedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedPurchOrd).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderedToProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReceivedQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedByProd).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReservedSaleOrd).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsStorageQtyMonthly)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsStoraMonth_Items_00");
            });
            modelBuilder.Entity<MaItemsSubstitute>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.Substitute })
                    .HasName("PK_ItemsSubstitute")
                    .IsClustered(false);

                entity.ToTable("MA_ItemsSubstitute");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Substitute)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ItemQty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Notes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubstituteQty).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsSubstitute)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemsSubst_Items_00");
            });
            modelBuilder.Entity<MaItemsWmszones>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.Storage, e.Zone })
                    .IsClustered(false);

                entity.ToTable("MA_ItemsWMSZones");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Zone)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AutoReplenishment)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FixedBinPicking)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FixedBinPutaway)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MaxStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.MinStock).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaItemsWmszones)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MA_ItemsWMSZones_MA_Items");
            });
            #endregion

            modelBuilder.Entity<MaStandardCostHistorical>(entity =>
            {
                entity.HasKey(e => new { e.Item, e.ToValueDate })
                    .HasName("PK_StandardCostHistorical")
                    .IsClustered(false);

                entity.ToTable("MA_StandardCostHistorical");

                entity.Property(e => e.Item)
                    .HasMaxLength(21)
                    .IsUnicode(false);

                entity.Property(e => e.ToValueDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('17991231')");

                entity.Property(e => e.FiscalPeriod).HasDefaultValueSql("((1))");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.StandardCost).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.ItemNavigation)
                    .WithMany(p => p.MaStandardCostHistorical)
                    .HasForeignKey(d => d.Item)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StandardCostHi_00");
            });
            modelBuilder.Entity<MaUserDefaultSaleOrders>(entity =>
            {
                entity.HasKey(e => new { e.Branch, e.WorkerId })
                    .HasName("PK_UserDefaultSaleOrders")
                    .IsClustered(false);

                entity.ToTable("MA_UserDefaultSaleOrders");

                entity.Property(e => e.Branch)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

                entity.Property(e => e.EusaleOrderAccTpl)
                    .HasColumnName("EUSaleOrderAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtraEusaleOrderAccTpl)
                    .HasColumnName("ExtraEUSaleOrderAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOrderAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SaleOrderInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuspTaxSaleOrderAccTpl)
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
            });
            modelBuilder.Entity<MaUserDefaultSales>(entity =>
            {
                entity.HasKey(e => new { e.Branch, e.WorkerId })
                    .HasName("PK_UserDefaultSales")
                    .IsClustered(false);

                entity.ToTable("MA_UserDefaultSales");

                entity.Property(e => e.Branch)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

                entity.Property(e => e.AccompanyingInvoiceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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

                entity.Property(e => e.CollectionCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CollectionTaxAmount)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrAccInvoiceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrEuinvoiceAccTpl)
                    .HasColumnName("CorrEUInvoiceAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrExtraEuinvoiceAccTpl)
                    .HasColumnName("CorrExtraEUInvoiceAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrInvoiceAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrSuspInvoiceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrectionInvoiceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorrectionReceiptsAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditNoteAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditNoteAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditNoteInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitNoteAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitNoteAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitNoteEuaccTpl)
                    .HasColumnName("DebitNoteEUAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitNoteExtraEuaccTpl)
                    .HasColumnName("DebitNoteExtraEUAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitNoteInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitNoteSuspAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DninvRsn)
                    .HasColumnName("DNInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DummyCustomer)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EucreditNoteAccTpl)
                    .HasColumnName("EUCreditNoteAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EuinvoiceAccTpl)
                    .HasColumnName("EUInvoiceAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtraEucreditNoteAccTpl)
                    .HasColumnName("ExtraEUCreditNoteAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtraEuinvoiceAccTpl)
                    .HasColumnName("ExtraEUInvoiceAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FreeOfCharge)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FreeSamplesAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FreeSamplesAmount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FreeSamplesTaxAmount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.GoodsSalesAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceCorrectionRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceCorrectionRsnReturn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceForAdvanceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceForAdvanceAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceFromParagonAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoiceFromParagonTaxJournal)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IrnotOwnedStorageTransferIn)
                    .HasColumnName("IRNotOwnedStorageTransferIn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IrnotOwnedStorageTransferOut)
                    .HasColumnName("IRNotOwnedStorageTransferOut")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IrstorageTransfer)
                    .HasColumnName("IRStorageTransfer")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IrstorageTransferIn)
                    .HasColumnName("IRStorageTransferIn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IrstorageTransferOut)
                    .HasColumnName("IRStorageTransferOut")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IssueInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LoadDnrsn)
                    .HasColumnName("LoadDNRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NcreceiptsAccTpl)
                    .HasColumnName("NCReceiptsAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NcreceiptsTaxJournal)
                    .HasColumnName("NCReceiptsTaxJournal")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PackagingCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PickingListInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProtocolAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProtocolAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProtocolCnaccTpl)
                    .HasColumnName("ProtocolCNAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProtocolDnaccTpl)
                    .HasColumnName("ProtocolDNAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReceiptAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReceiptIsminvRsn)
                    .HasColumnName("ReceiptISMInvRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReceiptsAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnFromCustomerInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReturnedMaterialInvRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServicesSalesAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShippingTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StampsCharges)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StampsTaxAmount)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Storage)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SundryRevenuesAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuspCreditNoteAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuspInvoiceAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxBreakAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxBreakReason)
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
            });
            modelBuilder.Entity<MaAccountingDefaults>(entity =>
            {
                entity.HasKey(e => e.AccountingDefaultsId)
                    .HasName("PK_AccountingDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_AccountingDefaults");

                entity.Property(e => e.AccountingDefaultsId).ValueGeneratedNever();

                entity.Property(e => e.AccrualTransferAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccrualsAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccrualsTransferAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccruedChargesAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccruedIncomesAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ApprovalAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ApprovalAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillCollectionAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillCollectionAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillOfExchAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BillOfExchAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListPurchasesGoods1)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListPurchasesGoods2)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListPurchasesGoods3)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListPurchasesGoods4)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListPurchasesGoods5)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListPurchasesGoods6)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListPurchasesServices1)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListPurchasesServices2)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListPurchasesServices3)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListPurchasesServices4)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListPurchasesServices5)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListPurchasesServices6)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListSalesGoods1)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListSalesGoods2)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListSalesGoods3)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListSalesGoods4)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListSalesGoods5)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListSalesGoods6)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListSalesServices1)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListSalesServices2)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListSalesServices3)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListSalesServices4)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListSalesServices5)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListSalesServices6)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Cash)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashCurrency1)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashCurrency2)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashOrderAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashOrderAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClearingCustAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClearingSuppAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CollectionAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditDiscount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditNotesToBeIssuedAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreditNotesToBeReceivAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CurrencyCash1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CurrencyCash2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CurrencyRevalAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Customers)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DdaccRsn)
                    .HasColumnName("DDAccRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DdaccTpl)
                    .HasColumnName("DDAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitDiscount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DecreaseRevenue)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeferralsAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeferralsTransferAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeferralsTransferAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeferredChargesAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeferredIncomesAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Eucustomers)
                    .HasColumnName("EUCustomers")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Eusuppliers)
                    .HasColumnName("EUSuppliers")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExchangeRateLoss)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExchangeRateLossAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExchangeRateProfit)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExchangeRateProfitAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtraEucustomers)
                    .HasColumnName("ExtraEUCustomers")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExtraEusuppliers)
                    .HasColumnName("ExtraEUSuppliers")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FinStatClosingAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FinStatClosingAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FinStatOpeningAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.FinStatOpeningAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoicesToBeIssuedAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InvoicesToBeReceivedAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LossRounding)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NegAllowancesAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NegativeRoundingAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutstandingAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutstandingAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OutstandingReopeningAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaNaccRsn)
                    .HasColumnName("PaNAccRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaNaccTpl)
                    .HasColumnName("PaNAccTpl")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentOrdersAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PosAllowancesAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PositiveRoundingAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProfitLossClosingAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProfitLossClosingAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProfitRounding)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RetailCollection)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RetailCollectionAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevalExchangeRateLoss)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RevalExchangeRateProfit)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SummaryAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SummaryAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Suppliers)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxTransferAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxTransferAccTpl)
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

                entity.Property(e => e.TransferAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TransferAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VouchReopAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VouchReopAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.VouchersAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WindfallGain)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WindfallLoss)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WithholdingTaxCredit)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WtaxCreditTransferAccRsn)
                    .HasColumnName("WTaxCreditTransferAccRsn")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaChartOfAccounts>(entity =>
            {
                entity.HasKey(e => e.Account)
                    .HasName("PK_ChartOfAccounts")
                    .IsClustered(false);

                entity.ToTable("MA_ChartOfAccounts");

                entity.HasIndex(e => e.Description)
                    .HasName("MA_ChartOfAccounts2");

                entity.HasIndex(e => e.Ledger)
                    .HasName("MA_ChartOfAccounts3");

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.AccrualsAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AccrualsDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.Acgcode)
                    .HasColumnName("ACGCode")
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CashFlowType).HasDefaultValueSql("((8781828))");

                entity.Property(e => e.CodeType).HasDefaultValueSql("((3080194))");

                entity.Property(e => e.CostAccAccountGroup)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CostCentersDistribution).HasDefaultValueSql("((8060928))");

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DebitCreditSign).HasDefaultValueSql("((8192002))");

                entity.Property(e => e.DeferralsAccount)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DeferralsDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DirectCost).HasDefaultValueSql("((8257540))");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DocToBeIssRecType).HasDefaultValueSql("((30932992))");

                entity.Property(e => e.FullCost).HasDefaultValueSql("((8323077))");

                entity.Property(e => e.InCurrency)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.JobsDistribution).HasDefaultValueSql("((8126464))");

                entity.Property(e => e.Ledger)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OmniaintraCode)
                    .HasColumnName("OMNIAIntraCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OmniasubAccount)
                    .HasColumnName("OMNIASubAccount")
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostableInCostAcc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostableInJe)
                    .HasColumnName("PostableInJE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PreferredSignForBalance).HasDefaultValueSql("((544276480))");

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

                entity.Property(e => e.UoM)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });
            modelBuilder.Entity<MaChartOfAccountsBalances>(entity =>
            {
                entity.HasKey(e => new { e.Account, e.FiscalYear, e.BalanceYear, e.BalanceType, e.BalanceMonth, e.Nature, e.Currency })
                    .HasName("PK_ChartOfAccountsBalances")
                    .IsClustered(false);

                entity.ToTable("MA_ChartOfAccountsBalances");

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Credit).HasDefaultValueSql("((0))");

                entity.Property(e => e.Debit).HasDefaultValueSql("((0))");

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

                entity.HasOne(d => d.AccountNavigation)
                    .WithMany(p => p.MaChartOfAccountsBalances)
                    .HasForeignKey(d => d.Account)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChartOfAcc_ChartOfAcc_00");
            });
            modelBuilder.Entity<MaChartOfAccountsLang>(entity =>
            {
                entity.HasKey(e => new { e.Account, e.Language })
                    .HasName("PK_ChartOfAccountsLang")
                    .IsClustered(false);

                entity.ToTable("MA_ChartOfAccountsLang");

                entity.Property(e => e.Account)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
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

                entity.HasOne(d => d.AccountNavigation)
                    .WithMany(p => p.MaChartOfAccountsLang)
                    .HasForeignKey(d => d.Account)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChartOfAcc_Account_00");
            });
            modelBuilder.Entity<MaTaxCodesDefaults>(entity =>
            {
                entity.HasKey(e => e.TaxCodesDefaultsId)
                    .HasName("PK_TaxCodesDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_TaxCodesDefaults");

                entity.Property(e => e.TaxCodesDefaultsId).ValueGeneratedNever();

                entity.Property(e => e.DistributionTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExemptServicesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExemptedDedAllowTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExemptedDedNotAllowTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExemptedTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExemptedTaxCodeEuad)
                    .HasColumnName("ExemptedTaxCodeEUad")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExemptedTaxCodeEubc)
                    .HasColumnName("ExemptedTaxCodeEUbc")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ExemptionTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotSubjectServicesTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NotTaxableGoodsTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ReverseChargeTaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TaxCode)
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
            modelBuilder.Entity<MaTaxCodes>(entity =>
            {
                entity.HasKey(e => e.TaxCode)
                    .HasName("PK_TaxCodes")
                    .IsClustered(false);

                entity.ToTable("MA_TaxCodes");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Acgcode)
                    .HasColumnName("ACGCode")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.BlackListExempt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BlackListNonTaxable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.BuyerObligedToPayTax)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Disabled)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.DistributionPerc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Eicode)
                    .HasColumnName("EICode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EidataType)
                    .HasColumnName("EIDataType")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EisubCode)
                    .HasColumnName("EISubCode")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.EitextReference)
                    .HasColumnName("EITextReference")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Exempt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExemptInvoice)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FarmerTaxPerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.FixedAssets)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Gold)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InExportPlafond)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InPlafondTurnover)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.InProRataTurnover)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.LetterForFiscalPrinter)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NoChargesDistribution)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoIntrastat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NoTaxableAmount)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NonTaxable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.NotInBlackList)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Notes)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OmnialawCode)
                    .HasColumnName("OMNIALawCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OmniataxCode)
                    .HasColumnName("OMNIATaxCode")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Perc).HasDefaultValueSql("((0))");

                entity.Property(e => e.PlafondType).HasDefaultValueSql("((4325376))");

                entity.Property(e => e.ProRataExempt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PurchaseType).HasDefaultValueSql("((262145))");

                entity.Property(e => e.PurchasesNoTaxableAmount)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ReverseCharge)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SalesNoTaxableAmount)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Scrap)
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

                entity.Property(e => e.TravelAgencyVat)
                    .HasColumnName("TravelAgencyVAT")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TravelExtraUe)
                    .HasColumnName("TravelExtraUE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UndeductiblePerc).HasDefaultValueSql("((0))");

                entity.Property(e => e.UseSecondLumpSumRate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");
            });
            modelBuilder.Entity<MaTaxCodesLang>(entity =>
            {
                entity.HasKey(e => new { e.TaxCode, e.Language })
                    .HasName("PK_TaxCodesLang")
                    .IsClustered(false);

                entity.ToTable("MA_TaxCodesLang");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(64)
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

                entity.HasOne(d => d.TaxCodeNavigation)
                    .WithMany(p => p.MaTaxCodesLang)
                    .HasForeignKey(d => d.TaxCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaxCodesLang_TaxCodes_00");
            });
            modelBuilder.Entity<MaTaxCodesLists>(entity =>
            {
                entity.HasKey(e => e.TaxCode)
                    .HasName("PK_TaxCodesLists")
                    .IsClustered(false);

                entity.ToTable("MA_TaxCodesLists");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CustListColumn)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustListColumn1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CustListType).HasDefaultValueSql("((12320768))");

                entity.Property(e => e.Eupurchases)
                    .HasColumnName("EUPurchases")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ExtraEupurchases)
                    .HasColumnName("ExtraEUPurchases")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.SuppListColumn)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuppListColumn1)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SuppListType).HasDefaultValueSql("((12320768))");

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

                entity.HasOne(d => d.TaxCodeNavigation)
                    .WithOne(p => p.MaTaxCodesLists)
                    .HasForeignKey<MaTaxCodesLists>(d => d.TaxCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TaxCodes_TaxCodesLi_00");
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
            modelBuilder.Entity<MaPaymentTermsDefaults>(entity =>
            {
                entity.HasKey(e => new { e.PaymentTermsDefaultsId, e.PaymentTerm })
                    .HasName("PK_PaymentTermsDefaults")
                    .IsClustered(false);

                entity.ToTable("MA_PaymentTermsDefaults");

                entity.Property(e => e.CollectionAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CollectionAccTpl)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentAccRsn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PaymentAccTpl)
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
            });
            modelBuilder.Entity<MaPaymentTermsLang>(entity =>
            {
                entity.HasKey(e => new { e.Payment, e.Language })
                    .HasName("PK_PaymentTermsLang")
                    .IsClustered(false);

                entity.ToTable("MA_PaymentTermsLang");

                entity.Property(e => e.Payment)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Language)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescriptionText)
                    .HasMaxLength(64)
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

                entity.HasOne(d => d.PaymentNavigation)
                    .WithMany(p => p.MaPaymentTermsLang)
                    .HasForeignKey(d => d.Payment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentTer_PaymentTer_00");
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


        }
    }
}
