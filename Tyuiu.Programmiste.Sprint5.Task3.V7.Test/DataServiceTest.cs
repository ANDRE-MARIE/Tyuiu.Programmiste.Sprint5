using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.Programmiste.Sprint5.Task3.V7.Lib;
namespace Tyuiu.Programmiste.Sprint5.Task3.V7.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void CheckedExistsFile()
        {
            string path = $@"{Directory.GetCurrentDirectory()}\OutPutFileTask3.bin";

            DataService service = new DataService();
            string filePath = service.SaveToFileTextData(2);

            FileInfo fileInfo = new FileInfo(filePath);
            bool fileExists = fileInfo.Exists;
            bool wait = true;

            Assert.AreEqual(wait, fileExists);
        }

        [TestMethod]
        public void CheckedCalculation()
        {
            DataService service = new DataService();
            string filePath = service.SaveToFileTextData(2);

            // Lecture du fichier binaire pour vérifier le calcul
            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                double valeur = reader.ReadDouble();
                double expected = 1.6 * Math.Pow(2, 3) - 2.1 * Math.Pow(2, 2) + 7 * 2;
                expected = Math.Round(expected, 3);

                Assert.AreEqual(expected, valeur, 0.001);
            }
        }
    }
}
