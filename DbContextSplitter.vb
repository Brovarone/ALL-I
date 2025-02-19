Imports System
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Text.RegularExpressions
Imports Microsoft.EntityFrameworkCore
Imports Microsoft.EntityFrameworkCore.Metadata
Imports EFMago.Models ' Assicurati che questo namespace sia corretto

Module DbContextSplitter
    Sub Dividi()

        Dim sourceDbContextPath As String = "D:\Progetti\ALLMigrazione\bin\Release\EFMago.dll"
        Dim outputDirectory As String = "D:\Progetti\ALLMigrazione\EFMago\Models\Context"

        If Not Directory.Exists(outputDirectory) Then
            Directory.CreateDirectory(outputDirectory)
        End If

        Dim assembly As Assembly = Assembly.LoadFrom(sourceDbContextPath)

        If assembly Is Nothing Then
            Console.WriteLine("DbContext principale non trovato.")
            Return
        End If

        Dim originalDbContextType As Type = assembly.GetType("EFMago.Models.MagoContext")
        If originalDbContextType Is Nothing Then
            Console.WriteLine("DbContext principale non trovato.")
            Return
        End If

        ' Leggi il contenuto del file magoContext.cs
        Dim magoContextFilePath As String = "D:\Progetti\ALLMigrazione\EFMago\Models\Context\Miei\magoContext.cs"
        Dim magoContextContent As String = File.ReadAllText(magoContextFilePath)

        ' *** CODICE ESEGUITO UNA SOLA VOLTA ***
        Dim contextType As Type = assembly.GetType("EFMago.Models.MagoContext") ' Usa il nome completo del tipo
        Dim optionsBuilder As New DbContextOptionsBuilder(Of MagoContext)() ' Usa MagoContext qui
        optionsBuilder.UseSqlServer("Server=ACERBO\SQLEXPRESS; Database=DEMON;User Id=sa;Password=euroufficio") ' Sostituisci con la tua stringa di connessione
        Dim options = optionsBuilder.Options
        Debug.Print("Creo l'istanza")

        Dim originalDbContextInstance = Activator.CreateInstance(originalDbContextType, New Object() {options})

        Dim onModelCreatingMethod As MethodInfo = originalDbContextType.GetMethod("OnModelCreating", BindingFlags.NonPublic Or BindingFlags.Instance)
        Dim modelBuilder As ModelBuilder = Nothing ' Inizializza modelBuilder qui

        If onModelCreatingMethod IsNot Nothing Then ' Verifica se il metodo esiste
            Dim conventions As Conventions.ConventionSet = New Conventions.ConventionSet() ' Crea l'istanza di ModelBuilder *passando* le conventions
            modelBuilder = New ModelBuilder(conventions)
            onModelCreatingMethod.Invoke(originalDbContextInstance, New Object() {modelBuilder})
        End If
        ' *** FINE CODICE ESEGUITO UNA SOLA VOLTA ***
        Debug.Print("Modello creato")


        Dim dbSetProperties = originalDbContextType.GetProperties(BindingFlags.Public Or BindingFlags.Instance) _
            .Where(Function(p) p.PropertyType.IsGenericType AndAlso p.PropertyType.GetGenericTypeDefinition() Is GetType(DbSet(Of ))) _
            .ToList()

        Dim entitiesByFolder = dbSetProperties _
            .Where(Function(p) IsEntityInFolder(p.PropertyType.GenericTypeArguments(0).Name, "D:\Progetti\ALLMigrazione\EFMago\Models\ERP")) _
            .GroupBy(Function(p) GetFolderNameFromEntityName(p.PropertyType.GenericTypeArguments(0).Name, "D:\Progetti\ALLMigrazione\EFMago\Models\ERP"))

        For Each folderGroup In entitiesByFolder

            Dim folderName As String = folderGroup.Key
            If String.IsNullOrEmpty(folderName) Then Continue For

            Dim contextName As String = $"{folderName}DbContext"
            Dim contextFilePath As String = Path.Combine(outputDirectory, $"{contextName}.cs")
            Debug.Print(contextName)

            Using writer As New StreamWriter(contextFilePath, False)

                ' Scrivi *codice C#* nel file .cs
                writer.WriteLine("using System;")
                writer.WriteLine("using Microsoft.EntityFrameworkCore;")
                writer.WriteLine("using Microsoft.EntityFrameworkCore.Metadata;")
                writer.WriteLine("using System.ComponentModel.DataAnnotations.Schema;")
                writer.WriteLine("")
                writer.WriteLine("//Ultimo adeguamento mago.net 3.14.21")

                writer.WriteLine($"namespace EFMago.Models")
                writer.WriteLine("{")
                writer.WriteLine($"    public partial class {contextName} : DbContext")
                writer.WriteLine("    {")
                writer.WriteLine($"        public {contextName}()")
                writer.WriteLine("        {")
                writer.WriteLine("        }")

                writer.WriteLine($"        public {contextName}(DbContextOptions<{contextName}> options)")
                writer.WriteLine("            : base(options)")
                writer.WriteLine("        {")
                writer.WriteLine("        }")
                writer.WriteLine("")

                For Each dbSetProperty In folderGroup
                    writer.WriteLine($"        public virtual DbSet<{dbSetProperty.PropertyType.GenericTypeArguments(0).Name}> {dbSetProperty.Name} {{ get; set; }}")
                Next
                writer.WriteLine("")

                writer.WriteLine("        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)")
                writer.WriteLine("        {")
                writer.WriteLine("            // Se necessario, configura la stringa di connessione qui")
                writer.WriteLine("        }")

                writer.WriteLine("        protected override void OnModelCreating(ModelBuilder modelBuilder)")
                writer.WriteLine("        {")

                For Each dbSetProperty In folderGroup
                    Dim entityType As Type = dbSetProperty.PropertyType.GenericTypeArguments(0)
                    Dim entityName As String = entityType.Name

                    Dim startString As String = $"modelBuilder.Entity<{entityName}>(entity =>"

                    Dim startIndex As Integer = magoContextContent.IndexOf(startString)

                    If startIndex > -1 Then
                        startIndex += startString.Length

                        Dim bracketCount As Integer = 0 ' Contatore per l'annidamento delle parentesi
                        Dim endIndex As Integer = -1

                        For i As Integer = startIndex To magoContextContent.Length - 1
                            Select Case magoContextContent(i)
                                Case "{"
                                    bracketCount += 1 ' Incrementa il contatore per ogni parentesi aperta
                                Case "}"
                                    bracketCount -= 1 ' Decrementa il contatore per ogni parentesi chiusa

                                    If bracketCount = 0 Then ' Se il contatore torna a 0, abbiamo trovato la parentesi di chiusura corrispondente
                                        endIndex = i
                                        Exit For
                                    End If
                            End Select
                        Next

                        If endIndex > -1 Then
                            Dim entityConfigurationBlock As String = magoContextContent.Substring(startIndex, endIndex - startIndex).Trim()

                            writer.WriteLine($"            modelBuilder.Entity<{entityName}>(entity =>")
                            writer.WriteLine(entityConfigurationBlock) ' Scrivi il codice di configurazione estratto
                            writer.WriteLine("            });")
                        Else
                            writer.WriteLine($"            // Fine Braccetto non trovata per l'entità {entityName}") ' Gestisci il caso in cui non viene trovata la configurazion
                        End If
                    Else
                        writer.WriteLine($"            // Configurazione non trovata per l'entità {entityName}") ' Gestisci il caso in cui non viene trovata la configurazione
                    End If
                Next

                writer.WriteLine("        }")
                writer.WriteLine("    }")
                writer.WriteLine("}")

            End Using

        Next

        Console.WriteLine("DbContexts suddivisi con successo.")

    End Sub

    Private Function GetFolderNameFromEntityName(entityName As String, rootFolderPath As String) As String
        For Each folderPath As String In Directory.GetDirectories(rootFolderPath)
            Dim fileName As String = entityName & ".cs"
            Dim filePath As String = Path.Combine(folderPath, fileName)

            If File.Exists(filePath) Then
                Return Path.GetFileName(folderPath)
            End If
        Next

        Return Nothing
    End Function

    Private Function IsEntityInFolder(entityName As String, rootFolderPath As String) As Boolean
        Return GetFolderNameFromEntityName(entityName, rootFolderPath) IsNot Nothing
    End Function

End Module
