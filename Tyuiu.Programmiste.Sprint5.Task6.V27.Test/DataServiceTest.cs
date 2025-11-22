
using Tyuiu.Programmiste.Sprint5.Task6.V27.Lib;
namespace Tyuiu.Programmiste.Sprint5.Task6.V27.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void CheckedExistsFile()
        {
            string path = @"C:\DataSprint5\InPutDataFileTask6V27.txt";
            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;
            bool wait = true;
            Assert.AreEqual(wait, fileExists);
        }

        [TestMethod]
        public void CheckedCalculationWithThreeDigitNumbers()
        {
            // Créer un fichier de test temporaire
            string testPath = @"C:\DataSprint5\test_file.txt";

            // S'assurer que le dossier existe
            Directory.CreateDirectory(Path.GetDirectoryName(testPath));

            // Écrire des données de test avec des nombres à trois chiffres
            File.WriteAllText(testPath, "abc 123 def 456 ghi 789 jkl 12 mno 3456 pqr");

            DataService service = new DataService();
            int result = service.LoadFromDataFile(testPath);

            // Devrait trouver 123, 456, 789 (3456 n'est pas compté car il a 4 chiffres)
            int expected = 3;
            Assert.AreEqual(expected, result);

            // Nettoyer
            File.Delete(testPath);
        }

        [TestMethod]
        public void CheckedNoThreeDigitNumbers()
        {
            string testPath = @"C:\DataSprint5\test_file2.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(testPath));

            // Fichier sans nombres à trois chiffres
            File.WriteAllText(testPath, "abc 12 def 4 ghi 7890 jkl 56 mno");

            DataService service = new DataService();
            int result = service.LoadFromDataFile(testPath);

            // Devrait retourner 0 car aucun nombre à trois chiffres
            Assert.AreEqual(0, result);

            File.Delete(testPath);
        }

        [TestMethod]
        public void CheckedMixedNumbers()
        {
            string testPath = @"C:\DataSprint5\test_file3.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(testPath));

            // Fichier avec différents types de nombres
            File.WriteAllText(testPath, "100 999 1000 99 1234 567 89 888 7777");

            DataService service = new DataService();
            int result = service.LoadFromDataFile(testPath);

            // Devrait trouver 100, 999, 567, 888
            int expected = 4;
            Assert.AreEqual(expected, result);

            File.Delete(testPath);
        }
    }
}