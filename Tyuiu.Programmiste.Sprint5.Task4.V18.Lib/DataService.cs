
using System;
using System.Globalization;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;
namespace Tyuiu.Programmiste.Sprint5.Task4.V18.Lib
{
    //Étant donné un fichier C:\DataSprint5\InPutDataFileTask4V0.txt (récupérez le fichier depuis l’archive selon votre option. 
    //Créez manuellement un dossier C:\DataSprint5\ et copiez-y le fichier) contenant une valeur réelle, lisez cette valeur 
    //et remplacez X dans la formule y = cos(x)+x^2/2
    //Calculez la valeur à l’aide de la formule (arrondissez le résultat à trois décimales) et affichez-le dans la console.

    public class DataService : ISprint5Task4V18
    {
        public double LoadFromDataFile(string path)
        {
            string fileContent = File.ReadAllText(path);

            // Nettoyer et convertir la valeur en double
            fileContent = fileContent.Replace(',', '.'); // Remplacer la virgule par un point pour le format invariant
            double x = double.Parse(fileContent, CultureInfo.InvariantCulture);

            // Calculer y = cos(x) + x²/2
            double y = Math.Cos(x) + (Math.Pow(x, 2)) / 2;

            // Arrondir à trois décimales
            y = Math.Round(y, 3);

            // Afficher le résultat dans la console
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"y = cos({x}) + ({x}²)/2 = {y}");

            return y;
        }
    }
}
