
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
                results.Add("x\t\tF(x)");
                results.Add("----------------------");

                for (int x = startValue; x <= stopValue; x++)
                {
                    double result = CalculateFunction(x);
                    results.Add($"{x}\t\t{result:F2}");
                }

                // Sauvegarde dans le fichier
                File.WriteAllLines("OutPutFileTask1.txt", results);

                return "Données sauvegardées avec succès dans OutPutFileTask1.txt";
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

        public List<string> GetTabulatedData(int startValue, int stopValue)
        {
            List<string> results = new List<string>();

            for (int x = startValue; x <= stopValue; x++)
            {
                double result = CalculateFunction(x);
                results.Add($"{x}\t\t{result:F2}");
            }

            return results;
        }
    }
}