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

            string outputPath = "";

            try
            {
                // 1. Lire le contenu du fichier
                string content;
                using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
                {
                    content = reader.ReadToEnd();
                }

                Console.WriteLine("Содержимое исходного файла:");
                Console.WriteLine(content);
                Console.WriteLine();

                // 2. Remplacer tous les chiffres par '#'
                string result = Regex.Replace(content, "[0-9]", "#");

                Console.WriteLine("Содержимое после замены цифр на '#':");
                Console.WriteLine(result);
                Console.WriteLine();

                // 3. Créer le chemin du fichier de sortie
                // Dans le même dossier que le fichier d'entrée
                string outputDir = Path.GetDirectoryName(path);

                // Si le répertoire est null ou n'existe pas, utiliser le répertoire temporaire
                if (string.IsNullOrEmpty(outputDir) || !Directory.Exists(outputDir))
                {
                    outputDir = Path.GetTempPath();
                }

                outputPath = Path.Combine(outputDir, "OutPutDataFileTask7V2.txt");

                // 4. Écrire le résultat dans le fichier de sortie
                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
                {
                    writer.Write(result);
                }

                Console.WriteLine($"Результат сохранен в файл: {outputPath}");

                return outputPath;
            }
            catch (Exception ex)
            {
                // En cas d'erreur, créer un fichier de sortie minimal
                outputPath = Path.Combine(Path.GetTempPath(), "OutPutDataFileTask7V2.txt");
                try
                {
                    File.WriteAllText(outputPath, "Ошибка обработки файла: " + ex.Message, Encoding.UTF8);
                }
                catch
                {
                    // Si même ça échoue, retourner un chemin vide
                    return "";
                }

                return outputPath;
            }
        }
    }
}