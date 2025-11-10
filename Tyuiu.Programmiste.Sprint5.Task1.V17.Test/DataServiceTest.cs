using Tyuiu.Programmiste.Sprint5.Task1.V17.Lib;
namespace Tyuiu.Programmiste.Sprint5.Task1.V17.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void TestCalculateFunction_NormalValues()
        {
            // Arrange
            DataService ds = new DataService();

            // Act & Assert
            // Correction : utiliser "ds" au lieu de "calculator"
            // Correction : "AreEqual" au lieu de "Arefqual"
            Assert.AreEqual(-12.00, ds.CalculateFunction(-5), 0.01);
            Assert.AreEqual(-10.00, ds.CalculateFunction(-4), 0.01);
            Assert.AreEqual(-8.00, ds.CalculateFunction(-3), 0.01);
        }

        [TestMethod]
        public void TestCalculateFunction_DivisionByZero()
        {
            // Arrange
            DataService ds = new DataService();

            // Act
            double result = ds.CalculateFunction(0);

            // Assert
            Assert.IsFalse(double.IsNaN(result));
            Assert.IsFalse(double.IsInfinity(result));
        }

        [TestMethod]
        public void TestSaveToFileTextData_Success()
        {
            // Arrange
            DataService ds = new DataService();

            // Act
            string result = ds.SaveToFileTextData(-2, 2);

            // Assert
            Assert.AreEqual("Données sauvegardées avec succès dans OutPutFileTask1.txt", result);
            Assert.IsTrue(System.IO.File.Exists("OutPutFileTask1.txt"));
        }
    }
}
