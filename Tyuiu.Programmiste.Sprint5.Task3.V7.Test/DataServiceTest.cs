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
            DataService service = new DataService();
            string filePath = service.SaveToFileTextData(2);

            // Attendre un peu pour s'assurer que le fichier est libéré
            System.Threading.Thread.Sleep(100);

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

            // Attendre un peu pour s'assurer que le fichier est libéré
            System.Threading.Thread.Sleep(100);

            // Lecture du fichier binaire avec FileShare.ReadWrite
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                double valeur = reader.ReadDouble();
                double expected = 1.6 * Math.Pow(2, 3) - 2.1 * Math.Pow(2, 2) + 7 * 2;
                expected = Math.Round(expected, 3);

                Assert.AreEqual(expected, valeur, 0.001);
            }
        }
    }
}