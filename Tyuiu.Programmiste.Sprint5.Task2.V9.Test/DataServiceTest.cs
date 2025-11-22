using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Tyuiu.Programmiste.Sprint5.Task2.V9.Lib;
namespace Tyuiu.Programmiste.Sprint5.Task2.V9.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void CheskedExistsFile()
        {
            string path = @"C:\Users\пользователь\source\repos\Tyuiu.Programmiste.Sprint5\Tyuiu.Programmiste.Sprint5.Task2.V9\Bin\Debung\OutPutFileTask2.csv";
            FileInfo fileInfo = new FileInfo(path);
            bool fileExists = fileInfo.Exists;
            bool wait = true;
            Assert.AreEqual(wait, fileExists);
        }
    }
}