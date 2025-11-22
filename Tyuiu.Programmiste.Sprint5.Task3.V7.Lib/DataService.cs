using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;
namespace Tyuiu.Programmiste.Sprint5.Task3.V7.Lib
{

    //Étant donné une expression f(X) = 1.6x^3-2.1x^2+7x , calculez sa valeur pour x = 2, enregistrez le résultat dans le fichier binaire
    //OutPutFileTask3.bin et affichez-le dans la console. Arrondissez à trois décimales.
    public class DataService : ISprint5Task3V7
    {
        public string SaveToFileTextData(int x)
        {
            // Calcul de l'expression f(x) = 1.6x³ - 2.1x² + 7x
            double result = 1.6 * Math.Pow(x, 3) - 2.1 * Math.Pow(x, 2) + 7 * x;

            // Arrondir à trois décimales
            result = Math.Round(result, 3);

            // Chemin du fichier binaire
            string path = $@"{Directory.GetCurrentDirectory()}\OutPutFileTask3.bin";

            // Créer le dossier output s'il n'existe pas
            string directoryPath = Path.GetDirectoryName(path);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Écrire le résultat dans le fichier binaire
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write(result);
            }

            // Afficher le résultat dans la console
            Console.WriteLine($"f({x}) = {result}");

            return path;
        }
    }
}
