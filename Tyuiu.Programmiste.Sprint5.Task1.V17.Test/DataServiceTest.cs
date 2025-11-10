using Tyuiu.Programmiste.Sprint5.Task1.V17.Lib;
namespace Tyuiu.Programmiste.Sprint5.Task1.V17.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void TestSaveToFileTextData()
        {
            // Arrange
            DataService ds = new DataService();
            string expected = "-19,62\\n-17,12\\n-18,15\\n-63,13\\n-24,92\\n-5\\n-1,46\\n1,57\\n6,38\\n32,78\\n225,11";

            // Act
            string result = ds.SaveToFileTextData(-5, 5);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCalculateFunction_SpecificValues()
        {
            // Arrange
            DataService ds = new DataService();

            // Act & Assert - test de quelques valeurs spécifiques
            Assert.AreEqual(-19.62, ds.CalculateFunction(-5), 0.01);
            Assert.AreEqual(-17.12, ds.CalculateFunction(-4), 0.01);
            Assert.AreEqual(-18.15, ds.CalculateFunction(-3), 0.01);
            Assert.AreEqual(-63.13, ds.CalculateFunction(-2), 0.01);
            Assert.AreEqual(-24.92, ds.CalculateFunction(-1), 0.01);
            Assert.AreEqual(-5.00, ds.CalculateFunction(0), 0.01);
        }
    }
}