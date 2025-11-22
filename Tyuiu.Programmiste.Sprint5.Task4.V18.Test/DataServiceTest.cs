
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.Programmiste.Sprint5.Task4.V18.Lib;
namespace Tyuiu.Programmiste.Sprint5.Task4.V18.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void CheckedWithDifferentValues()
        {
            string testFilePath = @"C:\DataSprint5\test_input2.txt";
            string directory = Path.GetDirectoryName(testFilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Tester avec une autre valeur
            File.WriteAllText(testFilePath, "1.0");

            DataService service = new DataService();
            double result = service.LoadFromDataFile(testFilePath);

            double expected = Math.Cos(1.0) + (Math.Pow(1.0, 2)) / 2;
            expected = Math.Round(expected, 3);

            Assert.AreEqual(expected, result, 0.001);

            File.Delete(testFilePath);
        }
    }
}