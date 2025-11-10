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
        public void TestFormatResult()
        {
            // Arrange
            DataService ds = new DataService();

            // Test via reflection ou méthode publique si disponible
            // Pour tester le formatage, on peut utiliser CalculateFunction et vérifier le format
            double testValue1 = -5.0;
            double testValue2 = -1.46;

            // Utiliser la méthode privée via reflection ou rendre FormatResult publique pour le test
        }
    }
}