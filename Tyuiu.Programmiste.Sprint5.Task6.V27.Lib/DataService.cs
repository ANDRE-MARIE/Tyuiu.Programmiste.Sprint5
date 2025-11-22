

using System.Text.RegularExpressions;
using tyuiu.cources.programming.interfaces.Sprint5;
namespace Tyuiu.Programmiste.Sprint5.Task6.V27.Lib
{
    public class DataService : ISprint5Task6V27
    {
        public int LoadFromDataFile(string path)
        {
            // Lire tout le contenu du fichier
            string text = File.ReadAllText(path);

            // Afficher le texte original pour vérification
            Console.WriteLine($"Texte du fichier: {text}");

            // Utiliser une expression régulière pour trouver tous les nombres à trois chiffres
            // \b indique une limite de mot, \d{3} cherche exactement 3 chiffres
            string pattern = @"\b\d{3}\b";
            MatchCollection matches = Regex.Matches(text, pattern);

            // Afficher les nombres trouvés
            if (matches.Count > 0)
            {
                Console.WriteLine("Nombres à trois chiffres trouvés:");
                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Value);
                }
            }
            else
            {
                Console.WriteLine("Aucun nombre à trois chiffres trouvé.");
            }

            // Retourner le nombre total
            return matches.Count;
        }
    }
}