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

            if (!File.Exists(path))
            {
                // Si le fichier n'existe pas, créer-le avec le contenu de test
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                string defaultContent = "123 Bonjour, ceci est une chaîne de test 456.";
                File.WriteAllText(path, defaultContent, Encoding.UTF8);
            }

            // LIRE LE CONTENU
            string content = File.ReadAllText(path, Encoding.UTF8);

            // REMPLACER LES CHIFFRES
            // Version 1: Regex.Replace(content, @"\d", "#")
            // Version 2: Boucle manuelle
            StringBuilder result = new StringBuilder();
            foreach (char c in content)
            {
                if (char.IsDigit(c))
                {
                    result.Append('#');
                }
                else
                {
                    result.Append(c);
                }
            }

            // CHEMIN DE SORTIE
            string outputPath = path.Replace("InPutDataFileTask7V2.txt", "OutPutDataFileTask7V2.txt");

            // ÉCRIRE LE RÉSULTAT
            File.WriteAllText(outputPath, result.ToString(), Encoding.UTF8);

            return outputPath;
        }
    }
}