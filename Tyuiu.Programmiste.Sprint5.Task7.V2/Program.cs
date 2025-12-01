using System;
using System.IO;
using System.Text;
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

        string path = @"C:\DataSprint5\InputDataFileTask7V2.txt";

        // Créer le fichier de test avec l'exemple fourni
        if (!File.Exists(path))
        {
            Console.WriteLine($"Файл {path} не найден!");
            Console.WriteLine("Создание тестового файла...");

            // Créer le dossier s'il n'existe pas
            Directory.CreateDirectory(@"C:\DataSprint5\");

            // Écrire le texte de test BASÉ SUR L'ERREUR
            // Texte d'entrée: "123 Bonjour, ceci est une chaîne de test 456."
            string testContent = "123 Bonjour, ceci est une chaîne de test 456.";
            File.WriteAllText(path, testContent, Encoding.UTF8);

            Console.WriteLine($"Создан тестовый файл: {path}");
            Console.WriteLine($"Содержимое: {testContent}");
        }
        else
        {
            Console.WriteLine($"Файл найден: {path}");
            Console.WriteLine($"Содержимое: {File.ReadAllText(path, Encoding.UTF8)}");
        }

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* РЕЗУЛЬТАТ:                                                             *");
        Console.WriteLine("***************************************************************************");

        string outputPath = ds.LoadDataAndSave(path);

        // Afficher le résultat final
        if (File.Exists(outputPath))
        {
            string finalResult = File.ReadAllText(outputPath, Encoding.UTF8);
            Console.WriteLine($"\nФинальный результат:");
            Console.WriteLine(finalResult);

            // Vérification
            string expected = "### Bonjour, ceci est une chaîne de test ###.";
            Console.WriteLine($"\nОжидаемый результат: {expected}");
            Console.WriteLine($"Совпадение: {finalResult == expected}");
        }

        Console.WriteLine("\nНажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}