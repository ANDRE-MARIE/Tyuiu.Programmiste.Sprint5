
using Tyuiu.Programmiste.Sprint5.Task2.V9.Lib;
namespace Tyuiu.Programmiste.Sprint5.Task2.V9.Test
{
    [TestClass]
    public sealed class MatrixProcessorTests
    {
        [TestMethod]
        public void Test_SaveToFileTextData()
        {
            int[,] matrix = {
                { 6, 8, 3 },
                { 2, 6, 8 },
                { 1, 7, 1 }
            };

            MatrixProcessor processor = new MatrixProcessor();

            string filePath = processor.SaveToFileTextData(matrix);

            // Vérification que le fichier a été créé
            Assert.IsTrue(System.IO.File.Exists(filePath));

            // Vérification du contenu (optionnel)
            string[] lines = System.IO.File.ReadAllLines(filePath);
            Assert.AreEqual("6 ; 8 ; 0", lines[0]);
            Assert.AreEqual("2 ; 6 ; 8", lines[1]);
            Assert.AreEqual("0 ; 0 ; 0", lines[2]);
        }
    }
}