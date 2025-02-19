using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text.RegularExpressions;

public class DatabaseObjectProcessor
{
     public static void ProcessDatabaseObjects(string sourceDirectory, string solutionFilePath)
    {
        try
        {
            // 1. Leggi il file di soluzione e determina la directory di ricerca
            string searchDirectory = sourceDirectory;

            if (string.IsNullOrEmpty(searchDirectory))
            {
                Console.WriteLine("Directory di ricerca non trovata nel file di soluzione.");
                return;
            }

            // 2. Cerca ricorsivamente i file databaseobject.xml
            string[] files = Directory.GetFiles(searchDirectory,"*.xml", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                if (Path.GetFileName(file).Equals("DatabaseObjects.xml", StringComparison.OrdinalIgnoreCase))
                {
                    // Estrai il nome della directory di destinazione dal file XML
                    string destinationDirectoryName = GetDestinationDirectoryNameFromXml(file);
                    Console.WriteLine (destinationDirectoryName);
                    if (!string.IsNullOrEmpty(destinationDirectoryName))
                    {
                        string destinationDirectory = Path.Combine(solutionFilePath, destinationDirectoryName);

                        // 3. Crea la directory di destinazione se non esiste
                        if (!Directory.Exists(destinationDirectory))
                        {
                            Directory.CreateDirectory(destinationDirectory);
                        }

                        ProcessDatabaseObjectFile(file, solutionFilePath, destinationDirectory);
                    }
                    else
                    {
                        Console.WriteLine($"Impossibile determinare la directory di destinazione per {file}");
                    }
                               
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore principale: {ex.Message}");
        }
    }

    private static string GetSearchDirectoryFromSolution(string solutionFilePath)
    {
        // TODO: Implementa la logica per leggere il file .sln e trovare la directory di ricerca.
        // Puoi usare espressioni regolari o parsing XML se il file ha una struttura adatta.
        // Questo è un esempio molto semplice che cerca una riga contenente "SearchFolder":
        try
        {
            foreach (string line in File.ReadLines(solutionFilePath))
            {
                if (line.Contains("SearchFolder"))
                {
                    // Estrai il percorso della directory (potrebbe essere necessario adattarlo)
                    return Path.Combine(Path.GetDirectoryName(solutionFilePath), "SearchFolder");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore lettura file di soluzione: {ex.Message}");
        }

        return null; // Restituisci null se la directory non viene trovata
    }

    private static void ProcessDatabaseObjectFile(string databaseObjectFile, string searchDirectory, string destinationDirectory)
    {
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(databaseObjectFile);

            XmlNodeList tableNodes = doc.SelectNodes("//Table");
            if (tableNodes != null)
            {
                foreach (XmlNode tableNode in tableNodes)
                {
                    string namespaceValue = tableNode.Attributes["namespace"]?.Value;
                    if (!string.IsNullOrEmpty(namespaceValue))
                    {
                        string tableName = namespaceValue.Substring(namespaceValue.LastIndexOf('.') + 1).Replace("_", "");
                        string tableFile = FindTableFile(searchDirectory, tableName);

                        if (!string.IsNullOrEmpty(tableFile))
                        {
                            MoveTableFile(tableFile, destinationDirectory, tableName);
                        }
                        else
                        {
                            Console.WriteLine($"Nessun file trovato per {tableName}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore elaborazione {databaseObjectFile}: {ex.Message}");
        }
    }

    private static string FindTableFile(string searchDirectory, string tableName)
    {
        // Usa una ricerca più robusta con espressioni regolari per trovare il file
        try
        {
            foreach (string file in Directory.GetFiles(searchDirectory, "*.*", SearchOption.AllDirectories))
            {
                if (Regex.IsMatch(Path.GetFileName(file), $"^{tableName}\\..*$", RegexOptions.IgnoreCase))
                {
                    return file;
                }
            }  
            return null;   
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore: {ex.Message}");
            return null;
        }
    }

    private static void MoveTableFile(string sourceFile, string destinationDirectory, string tableName)
    {
        string destinationFile = Path.Combine(destinationDirectory, Path.GetFileName(sourceFile));
        try
        {
            File.Move(sourceFile, destinationFile, true); // Sovrascrivi se esiste già
            Console.WriteLine($"Spostato {tableName} in {destinationDirectory}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Errore spostamento file {sourceFile}: {ex.Message}");
        }
    }
 private static string GetDestinationDirectoryNameFromXml(string xmlFile)
{
    try
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlFile);

        // Estrai il valore del nodo Signature
        XmlNode signatureNode = doc.SelectSingleNode("//Signature");

        if (signatureNode != null)
        {
            // Estrai il namespace dal primo nodo Table (puoi scegliere un altro nodo Table se necessario)
            XmlNode tableNode = doc.SelectSingleNode("//Table"); // Ottiene il primo nodo <Table>

            if (tableNode != null)
            {
                string namespaceValue = tableNode.Attributes["namespace"]?.Value;
                if (!string.IsNullOrEmpty(namespaceValue))
                {
                    // Estrai la parte "ERP" dal namespace
                    string[] parts = namespaceValue.Split('.');
                    if (parts.Length >= 2) // Assicurati che ci siano almeno due parti (ERP e il resto)
                    {
                        string area = parts[0]; // La prima parte è "ERP" (o simile)
                        return $"{area}\\{signatureNode.InnerText}"; // Combina "ERP" e "Accounting_BG"
                    }
                    else
                    {
                        Console.WriteLine($"Namespace nel file XML {xmlFile} in formato non valido.");
                        return signatureNode.InnerText; //restituisco solo il signature
                    }
                }
                else
                {
                    Console.WriteLine($"Attributo 'namespace' non trovato nel nodo Table in {xmlFile}.");
                    return signatureNode.InnerText; //restituisco solo il signature
                }
            }
            else
            {
                Console.WriteLine($"Nessun nodo Table trovato in {xmlFile}.");
                return signatureNode.InnerText; //restituisco solo il signature
            }
        }
        else
        {
            Console.WriteLine($"Nodo Signature non trovato nel file XML {xmlFile}.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Errore lettura file XML {xmlFile}: {ex.Message}");
    }

    return null;
}

    public static void Main_NO(string[] args)
    {
         // Sostituisci con la tua directory di origine
        string sourceDirectory = @"C:\Program Files (x86)\Microarea\Magonet\Standard\Applications\";
        string solutionFilePath = @"D:\Progetti\ALLMigrazione\EFMago\Models\";// Sostituisci con il percorso del tuo file di soluzione
        ProcessDatabaseObjects(sourceDirectory, solutionFilePath);
        Console.WriteLine("Finito");
    }
}
