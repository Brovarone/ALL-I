using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbContextSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDbContextPath = @"D:\Progetti\ALLMigrazione\bin\Release\EFMago.dll";
            string outputDirectory = @"D:\Progetti\ALLMigrazione\EFMago\Models\Context"; // Directory di output per i nuovi DbContext

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Carica il DbContext originale tramite reflection
            Assembly assembly = Assembly.LoadFrom(sourceDbContextPath); // Assicurati che il path sia corretto
            Type originalDbContextType = assembly.GetTypes().FirstOrDefault(t => t.BaseType == typeof(DbContext));

            if (originalDbContextType == null)
            {
                Console.WriteLine("DbContext principale non trovato.");
                return;
            }

            // Ottieni le proprietà DbSet dal DbContext originale
            var dbSetProperties = originalDbContextType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .ToList();

             // Raggruppa le entità per cartella (usando la nuova logica)
            var entitiesByFolder = dbSetProperties
                .Where(p => IsEntityInFolder(p.PropertyType.GenericTypeArguments[0].Name, @"D:\Progetti\ALLMigrazione\EFMago\Models\ERP")) // Filtra le entità in base alla cartella
                .GroupBy(p => GetFolderNameFromEntityName(p.PropertyType.GenericTypeArguments[0].Name, @"D:\Progetti\ALLMigrazione\EFMago\Models\ERP")); // Raggruppa per cartella

            foreach (var folderGroup in entitiesByFolder)
            {
                string folderName = folderGroup.Key;
                if(string.IsNullOrEmpty(folderName)) continue; //se non trova una cartella per l'entity salta

                string contextName = $"{folderName}DbContext";
                string contextFilePath = Path.Combine(outputDirectory, $"{contextName}.cs");

                using (StreamWriter writer = new StreamWriter(contextFilePath))
                {
                    writer.WriteLine("using System;");
                    writer.WriteLine("using Microsoft.EntityFrameworkCore;");
                    writer.WriteLine("using Microsoft.EntityFrameworkCore.Metadata;");
                    writer.WriteLine("using System.ComponentModel.DataAnnotations.Schema;");
                    writer.WriteLine("");
                    writer.WriteLine($"//Ultimo adeguamento mago.net 3.14.21"); // Mantieni la nota

                    writer.WriteLine($"namespace EFMago.Models"); // Mantieni il namespace

                    writer.WriteLine("{");
                    writer.WriteLine($"\tpublic partial class {contextName} : DbContext");
                    writer.WriteLine("\t{");
                    writer.WriteLine($"\t\tpublic {contextName}()");
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t}");

                    writer.WriteLine($"\t\tpublic {contextName}(DbContextOptions<{contextName}> options)");
                    writer.WriteLine("\t\t\t: base(options)");
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine("");

                    foreach (var dbSetProperty in folderGroup)
                    {
                        writer.WriteLine($"\t\tpublic virtual DbSet<{dbSetProperty.PropertyType.GenericTypeArguments[0].Name}> {dbSetProperty.Name} {{ get; set; }}");
                    }
                    writer.WriteLine("");

                    writer.WriteLine("\t\tprotected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)");
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\t// if (!optionsBuilder.IsConfigured)");
                    writer.WriteLine("\t\t\t// {");
                    writer.WriteLine("\t\t\t//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.");
                    writer.WriteLine("\t\t\t//\t\t optionsBuilder.UseSqlServer(\"Server=ACERBO\\\\SQLEXPRESS; Database=DEMON;User Id=sa;Password=euroufficio\");");
                    writer.WriteLine("\t\t\t// }");
                    writer.WriteLine("\t\t}");


                    writer.WriteLine("\t\tprotected override void OnModelCreating(ModelBuilder modelBuilder)");
                    writer.WriteLine("\t\t{");

                    // Codice per OnModelCreating (da estrarre dal DbContext originale)
                    MethodInfo onModelCreatingMethod = originalDbContextType.GetMethod("OnModelCreating", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (onModelCreatingMethod != null)
                    {
                        // Crea un'istanza di ModelBuilder
                        var modelBuilder = new ModelBuilder(); // Questo è l'oggetto ModelBuilder corretto

                        // Invocazione del metodo OnModelCreating originale tramite reflection.
                        // Questo richiede un'istanza del DbContext originale.  Dato che non hai un costruttore senza parametri, dovrai gestire la creazione di questa istanza.
                        var originalDbContextInstance = Activator.CreateInstance(originalDbContextType, new object[] { new DbContextOptionsBuilder().Options }); // Esempio: crea un'istanza con opzioni vuote.  Dovrai probabilmente passare le opzioni corrette.
                        onModelCreatingMethod.Invoke(originalDbContextInstance, new object[] { modelBuilder });

                        // Filtra le configurazioni delle entità in base a quelle presenti nel gruppo corrente.
                        foreach(var dbSetProperty in folderGroup)
                        {
                           Type entityType = dbSetProperty.PropertyType.GenericTypeArguments[0];
                           foreach (var entityTypeBuilder in modelBuilder.Model.GetEntityTypes().Where(x => x.Name == entityType.Name))
                           {
                               //Scrivi la configurazione solo per le entità del context corrente
                               writer.WriteLine($"\t\t\t{entityTypeBuilder.Name}(entity =>");
                               writer.WriteLine("\t\t\t{");
                               foreach (var property in entityTypeBuilder.GetProperties())
                               {
                                   //Scrivi le configurazioni per le proprietà
                                   //Puoi usare entityTypeBuilder per recuperare le configurazioni
                               }
                               writer.WriteLine("\t\t\t});");
                           }
                        }
                    }

                    writer.WriteLine("\t\t}");
                    writer.WriteLine("\t}");
                    writer.WriteLine("}");

                }
            }

            Console.WriteLine("DbContexts suddivisi con successo.");
         }
         static string GetFolderNameFromEntityName(string entityName, string rootFolderPath)
        {
            foreach (string folderPath in Directory.GetDirectories(rootFolderPath))
            {
                string fileName = entityName + ".cs"; // Costruisci il nome del file
                string filePath = Path.Combine(folderPath, fileName);

                if (File.Exists(filePath))
                {
                    return Path.GetFileName(folderPath); // Restituisci il nome della cartella
                }
            }

            return null; // Restituisci null se l'entità non è stata trovata in nessuna cartella
        }

        // Funzione di supporto per filtrare le entità
        static bool IsEntityInFolder(string entityName, string rootFolderPath)
        {
            return GetFolderNameFromEntityName(entityName, rootFolderPath) != null;
        }
    }
}