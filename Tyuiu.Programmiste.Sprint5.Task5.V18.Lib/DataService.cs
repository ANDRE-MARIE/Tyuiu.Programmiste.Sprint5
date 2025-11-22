
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tyuiu.cources.programming.interfaces.Sprint5;
namespace Tyuiu.Programmiste.Sprint5.Task5.V18.Lib
{
    public class DataService : ISprint5Task5V18
    {
        public double LoadFromDataFile(string path)
        {
            double product = 1.0; // Initialiser à 1 pour la multiplication
            bool foundTwoDigitNumber = false;

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Ignorer les lignes vides
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Traiter chaque valeur séparée par des espaces ou autres séparateurs
                    string[] values = line.Split(new char[] { ' ', '\t', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string value in values)
                    {
                        if (double.TryParse(value.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                        {
                            // Vérifier si c'est un nombre à deux chiffres (entre 10 et 99 inclus)
                            if (number >= 10 && number < 100 && number == Math.Floor(number))
                            {
                                product *= number;
                                foundTwoDigitNumber = true;
                                Console.WriteLine($"Nombre à deux chiffres trouvé: {number}");
                            }
                        }
                    }
                }
            }

            // Si aucun nombre à deux chiffres n'a été trouvé, retourner 0
            if (!foundTwoDigitNumber)
            {
                Console.WriteLine("Aucun nombre à deux chiffres trouvé dans le fichier.");
                return 0;
            }

            // Arrondir le résultat à trois décimales
            product = Math.Round(product, 3);
            return product;
        }
    }
}