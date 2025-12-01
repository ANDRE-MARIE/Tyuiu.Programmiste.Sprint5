using System;
using System.IO;
using System.Text.RegularExpressions;
using Tyuiu.Programmiste.Sprint5.Task7.V2.Lib;

internal class Program
{
    private static void Main(string[] args)
    {
        DataService ds = new DataService();

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                       *");
        Console.WriteLine("***************************************************************************");

        // Chemin correct selon l'énoncé
        string path = @"C:\DataSprint5\InputDataFileTask7V2.txt";

        // Si le fichier n'existe pas, créer un exemple avec ponctuation et chiffres
        if (!File.Exists(path))
        {
            Console.WriteLine($"Файл {path} не найден!");
            Console.WriteLine("Создание тестового файла...");

            // Créer le dossier s'il n'existe pas
            Directory.CreateDirectory(@"C:\DataSprint5\");

            // Créer un fichier de test avec ponctuation ET chiffres
            string testContent = "Тестовый текст 12345 с цифрами! А также: знаки препинания? Да, конечно...";
            File.WriteAllText(path, testContent, System.Text.Encoding.UTF8);

            Console.WriteLine($"Создан тестовый файл: {path}");
        }

        Console.WriteLine($"Данные находятся в файле: {path}");
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* РЕЗУЛЬТАТ:                                                             *");
        Console.WriteLine("***************************************************************************");

        string outputPath = ds.LoadDataAndSave(path);

        // Afficher le contenu du fichier de sortie
        if (File.Exists(outputPath))
        {
            string outputContent = File.ReadAllText(outputPath, System.Text.Encoding.UTF8);
            Console.WriteLine($"\nСодержимое выходного файла ({outputPath}):");
            Console.WriteLine(outputContent);

            // Vérifier si la ponctuation a été supprimée
            var punctuationPattern = @"[^\w\s]|_";
            var punctuationMatches = Regex.Matches(outputContent, punctuationPattern);
            Console.WriteLine($"\nЗнаков препинания в выходном файле: {punctuationMatches.Count}");
        }

        Console.WriteLine("\nНажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}