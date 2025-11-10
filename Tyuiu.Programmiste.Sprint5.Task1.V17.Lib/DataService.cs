
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
                    string formattedResult = FormatResult(result);
                    results.Add(formattedResult);
                }

                return string.Join("\\n", results);
            }
            catch (Exception ex)
            {
                return $"Erreur: {ex.Message}";
            }
        }

        private string FormatResult(double value)
        {
            if (Math.Abs(value - Math.Round(value)) < 0.001)
            {
                return ((int)Math.Round(value)).ToString(CultureInfo.GetCultureInfo("fr-FR"));
            }
            else
            {
                return value.ToString("F2", CultureInfo.GetCultureInfo("fr-FR"));
            }
        }

        public double CalculateFunction(int x)
        {
            try
            {
                double denominator = Math.Sin(x) + 1;

                if (Math.Abs(denominator) < 1e-10)
                    return 0;

                return (2 * x - 4) + (2 * x - 1) / denominator;
            }
            catch
            {
                return 0;
            }
        }
    }
}