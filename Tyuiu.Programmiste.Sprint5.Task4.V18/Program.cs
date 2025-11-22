using Tyuiu.Programmiste.Sprint5.Task4.V18.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        string path = @"C:\DataSprint5\InPutDataFileTask4V0.txt";

        // Vérifier si le fichier existe
        if (!File.Exists(path))
        {
            Console.WriteLine($"Le fichier {path} n'existe pas.");
            Console.WriteLine("Veuillez créer le dossier C:\\DataSprint5\\ et y copier le fichier InPutDataFileTask4V0.txt");
            return;
        }

        DataService service = new DataService();

        try
        {
            double result = service.LoadFromDataFile(path);
            Console.WriteLine($"Résultat final : {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur lors du traitement : {ex.Message}");
        }
    }
}