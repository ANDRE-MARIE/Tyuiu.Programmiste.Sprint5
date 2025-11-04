using Tyuiu.Programmiste.Sprint5.Task0.V6.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            DataService ds = new DataService();
            DisplayHeader();

            int x = 3;
            Console.WriteLine($"Calcul de l'expression pour x = {x}");
            Console.WriteLine("Expression: y = x / sqrt(x² + x)");
            Console.WriteLine(new string('-', 50));

            string result = ds.SaveToFileTextData(x);
            string filePath = Path.Combine(Path.GetTempPath(), "OutPutFileTask0.txt");

            Console.WriteLine($"Résultat calculé: {result}");
            Console.WriteLine($"Fichier généré: {filePath}");
            Console.WriteLine(new string('-', 50));

            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine($"Contenu du fichier: {fileContent}");
                Console.WriteLine("✓ Sauvegarde réussie!");
            }

            DisplayFooter();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erreur: {ex.Message}");
            Console.ResetColor();
        }

        Console.WriteLine("Appuyez sur une touche pour quitter...");
        Console.ReadKey();
    }

    static void DisplayHeader()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===============================================");
        Console.WriteLine("    CALCULATRICE D'EXPRESSION MATHÉMATIQUE    ");
        Console.WriteLine("===============================================");
        Console.ResetColor();
    }

    static void DisplayFooter()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Opération terminée avec succès!");
        Console.ResetColor();
    }
}