using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using tyuiu.cources.programming.interfaces.Sprint5;


namespace Tyuiu.Programmiste.Sprint5.Task7.V2.Lib
{
    public class DataService : ISprint5Task7V2
    {
        public string LoadDataAndSave(string path)
        {

            {
                try
                {
                    // 1. Lire le fichier d'entrée
                    string content = File.ReadAllText(path, Encoding.UTF8);

                    // 2. Afficher le contenu original (pour débogage)
                    Console.WriteLine("Содержимое исходного файла:");
                    Console.WriteLine(content);
                    Console.WriteLine();

                    // 3. Remplacer TOUS les chiffres par '#' - CORRECTION ICI
                    // Utilisation de [0-9] ou \d pour matcher tous les chiffres
                    string result = Regex.Replace(content, "[0-9]", "#");

                    // 4. Afficher le résultat
                    Console.WriteLine("Содержимое после замены цифр на '#':");
                    Console.WriteLine(result);
                    Console.WriteLine();

                    // 5. Déterminer le chemin de sortie
                    // Dans le même dossier que le fichier d'entrée
                    string outputDir = Path.GetDirectoryName(path);
                    string outputPath = Path.Combine(outputDir, "OutPutDataFileTask7V2.txt");

                    // 6. Sauvegarder le résultat
                    File.WriteAllText(outputPath, result, Encoding.UTF8);

                    Console.WriteLine($"Результат сохранен в файл: {outputPath}");

                    return outputPath;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
