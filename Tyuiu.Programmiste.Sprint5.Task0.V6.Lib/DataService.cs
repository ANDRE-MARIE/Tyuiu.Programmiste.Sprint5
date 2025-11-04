using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Programmiste.Sprint5.Task0.V6.Lib
{
    public class DataService : ISprint5Task0V6
    {
        public string SaveToFileTextData(int x)
        {
            double result = CalculateExpression(x);

            // Arrondir à trois décimales
            double roundedResult = Math.Round(result, 3);

            // Formater avec culture française
            string resultText = roundedResult.ToString("F3", CultureInfo.GetCultureInfo("fr-FR"));

            // Chemin du fichier utilisant Path.Combine() et Path.GetTempPath()
            string directoryPath = Path.GetTempPath();
            string filePath = Path.Combine(directoryPath, "OutPutFileTask0.txt");

            // Sauvegarder le résultat
            File.WriteAllText(filePath, resultText);

            return resultText;
        }

        private double CalculateExpression(int x)
        {
            // Expression: y = x / sqrt(x² + x)
            if (x < 0)
                throw new ArgumentException("x ne peut pas être négatif");

            double numerator = x;
            double denominator = Math.Sqrt(Math.Pow(x, 2) + x);

            if (denominator == 0)
                throw new DivideByZeroException("Le dénominateur ne peut pas être zéro.");

            return numerator / denominator;
        }
    }
}
