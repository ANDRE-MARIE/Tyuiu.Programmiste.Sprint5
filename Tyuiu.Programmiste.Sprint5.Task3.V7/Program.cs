using Tyuiu.Programmiste.Sprint5.Task3.V7.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        int x = 2;

        DataService service = new DataService();
        string cheminFichier = service.SaveToFileTextData(x);

        Console.WriteLine($"Fichier sauvegardé : {cheminFichier}");
        Console.WriteLine("Vérifiez dans le dossier le fichier binaire OutPutFileTask3.bin");

        // Lecture et affichage du contenu du fichier binaire pour vérification
        using (BinaryReader reader = new BinaryReader(File.Open(cheminFichier, FileMode.Open)))
        {
            double valeurLue = reader.ReadDouble();
            Console.WriteLine($"Valeur lue depuis le fichier binaire : {valeurLue}");
        }
    }
}