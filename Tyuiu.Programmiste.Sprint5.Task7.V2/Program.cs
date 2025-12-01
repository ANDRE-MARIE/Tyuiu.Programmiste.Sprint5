using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Tyuiu.Programmiste.Sprint5.Task7.V2.Lib;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            DataService ds = new DataService();

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                       *");
            Console.WriteLine("***************************************************************************");

            // Chemin du fichier d'entrée
            string path = @"C:\DataSprint5\InputDataFileTask7V2.txt";

            // Vérifier et créer le fichier de test si nécessaire
            if (!File.Exists(path))
            {
                Console.WriteLine($"Файл {path} не найден!");
                Console.WriteLine("Создание тестового файла...");

                // Créer le dossier s'il n'existe pas
                Directory.CreateDirectory(@"C:\DataSprint5");

                // Créer le contenu de test avec l'exemple de l'erreur
                string testContent = "123 Bonjour, ceci est une chaîne de test 456.";
                File.WriteAllText(path, testContent, Encoding.UTF8);

                Console.WriteLine($"Создан тестовый файл: {path}");
                Console.WriteLine($"Содержимое: {testContent}");
            }
            else
            {
                Console.WriteLine($"Файл найден: {path}");
                string existingContent = File.ReadAllText(path, Encoding.UTF8);
                Console.WriteLine($"Содержимое: {existingContent}");
            }

            Console.WriteLine("***************************************************************************");
            Console.WriteLine("* РЕЗУЛЬТАТ:                                                             *");
            Console.WriteLine("***************************************************************************");

            string outputPath = ds.LoadDataAndSave(path);

            if (string.IsNullOrEmpty(outputPath))
            {
                Console.WriteLine("Ошибка: Не удалось создать выходной файл.");
            }
            else if (!File.Exists(outputPath))
            {
                Console.WriteLine($"Ошибка: Выходной файл не создан: {outputPath}");
            }
            else
            {
                // Lire et afficher le résultat
                string finalResult = File.ReadAllText(outputPath, Encoding.UTF8);
                Console.WriteLine($"\nФинальный результат:");
                Console.WriteLine(finalResult);

                // Afficher le résultat attendu pour comparaison
                string expected = "### Bonjour, ceci est une chaîne de test ###.";
                Console.WriteLine($"\nОжидаемый результат: {expected}");
                Console.WriteLine($"Совпадение: {finalResult.Trim() == expected}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Критическая ошибка: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
        }

        Console.WriteLine("\nНажмите любую клавишу для завершения...");
        Console.ReadKey();
    }
}