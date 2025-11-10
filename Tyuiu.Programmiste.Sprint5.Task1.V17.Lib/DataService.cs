
using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;
namespace Tyuiu.Programmiste.Sprint5.Task1.V17.Lib
{
    public class DataService : ISprint5Task1V17
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {
            try
            {
                List<string> results = new List<string>();

                for (int x = startValue; x <= stopValue; x++)
                {
                    double result = CalculateFunction(x);
                    // Format avec virgule comme séparateur décimal
                    results.Add(result.ToString("F2", CultureInfo.GetCultureInfo("fr-FR")));
                }

                // Retourne la chaîne directement au lieu d'écrire dans un fichier
                return string.Join("\\n", results);
            }
            catch (Exception ex)
            {
                return $"Erreur: {ex.Message}";
            }
        }

        public double CalculateFunction(int x)
        {
            try
            {
                double denominator = Math.Sin(x) + 1;

                // Vérification division par zéro
                if (Math.Abs(denominator) < 1e-10)
                {
                    return 0;
                }

                double term1 = 2 * x - 4;
                double term2 = (2 * x - 1) / denominator;

                return term1 + term2;
            }
            catch
            {
                return 0;
            }
        }
    }
}