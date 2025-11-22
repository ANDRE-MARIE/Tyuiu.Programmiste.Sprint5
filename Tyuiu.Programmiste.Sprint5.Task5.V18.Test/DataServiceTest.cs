

using Tyuiu.Programmiste.Sprint5.Task5.V18.Lib;
namespace Tyuiu.Programmiste.Sprint5.Task5.V18.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
       
        public void CheckedCalculation()
        {
            // Créer un fichier de test temporaire
            string testPath = @"C:\DataSprint5\test_file.txt";
            string path = @"C:\Users\пользователь\source\repos\Tyuiu.Programmiste.Sprint5\Tyuiu.Programmiste.Sprint5.Task5.V18\Bin\Debung\InPutFileTask5.txt";
            // S'assurer que le dossier existe
            Directory.CreateDirectory(Path.GetDirectoryName(testPath));

            // Écrire des données de test avec des nombres à deux chiffres
            File.WriteAllText(testPath, "15 25.5 35 8 105 45.2 75 99 5.5 88");

            DataService service = new DataService();
            double result = service.LoadFromDataFile(testPath);

            // Calcul attendu : 15 * 35 * 75 * 99 * 88
            double expected = 15 * 35 * 75 * 99 * 88;
            expected = Math.Round(expected, 3);

            Assert.AreEqual(expected, result, 0.001);

            // Nettoyer
            File.Delete(testPath);
        }

        [TestMethod]
        public void CheckedNoTwoDigitNumbers()
        {
            string testPath = @"C:\DataSprint5\test_file2.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(testPath));

            // Fichier sans nombres à deux chiffres
            File.WriteAllText(testPath, "5 8 105 256 3.14 9.5");

            DataService service = new DataService();
            double result = service.LoadFromDataFile(testPath);

            // Devrait retourner 0 car aucun nombre à deux chiffres
            Assert.AreEqual(0, result);

            File.Delete(testPath);
        }
    }
}