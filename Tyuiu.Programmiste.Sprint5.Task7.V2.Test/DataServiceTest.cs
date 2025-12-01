using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.RegularExpressions;

using Tyuiu.Programmiste.Sprint5.Task7.V2.Lib;
namespace Tyuiu.Programmiste.Sprint5.Task7.V2.Test
{
    [TestClass]
    public sealed class DataServiceTest
    {
        [TestMethod]
        public void CheckedExistsInputFile()
        {
            // Utiliser un fichier temporaire au lieu d'un chemin fixe
            string testPath = Path.GetTempFileName();
            File.WriteAllText(testPath, "Test content for file existence check.");

            DataService service = new DataService();
            string outputPath = service.LoadDataAndSave(testPath);

            // Vérifier que le fichier de sortie a été créé
            Assert.IsTrue(File.Exists(outputPath));

            // Nettoyer
            File.Delete(testPath);
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
        }

        [TestMethod]
        public void CheckedPunctuationRemoval()
        {
            // Créer un fichier de test temporaire avec de la ponctuation
            string testInputPath = Path.GetTempFileName();
            File.WriteAllText(testInputPath, "Hello, World! This is a test... with? punctuation; marks: \"quotes\" and (brackets).");

            DataService service = new DataService();
            string outputPath = service.LoadDataAndSave(testInputPath);

            // Attendre un peu pour s'assurer que le fichier est libéré
            Thread.Sleep(100);

            // Vérifier que le fichier de sortie existe
            Assert.IsTrue(File.Exists(outputPath));

            // Lire le contenu du fichier de sortie avec FileShare
            string outputContent;
            using (FileStream fs = new FileStream(outputPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader reader = new StreamReader(fs))
            {
                outputContent = reader.ReadToEnd();
            }

            // Vérifier qu'il n'y a pas de ponctuation
            string pattern = @"[^\w\s]|_";
            MatchCollection matches = Regex.Matches(outputContent, pattern);

            Assert.AreEqual(0, matches.Count);

            // Nettoyer
            File.Delete(testInputPath);
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
        }

        [TestMethod]
        public void CheckedOutputFileCreation()
        {
            string testInputPath = Path.GetTempFileName();
            File.WriteAllText(testInputPath, "Test content without punctuation");

            DataService service = new DataService();
            string outputPath = service.LoadDataAndSave(testInputPath);

            // Attendre un peu pour s'assurer que le fichier est libéré
            Thread.Sleep(100);

            // Vérifier que le fichier de sortie a été créé dans le répertoire temporaire
            Assert.IsTrue(outputPath.Contains(Path.GetTempPath()));
            Assert.IsTrue(outputPath.Contains("OutPutDataFileTask7V21"));
            Assert.IsTrue(File.Exists(outputPath));

            // Nettoyer
            File.Delete(testInputPath);
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
        }

        [TestMethod]
        public void CheckedRussianText()
        {
            string testInputPath = Path.GetTempFileName();
            File.WriteAllText(testInputPath, "Привет, мир! Это тест... с? знаками; препинания: \"кавычки\" и (скобки).");

            DataService service = new DataService();
            string outputPath = service.LoadDataAndSave(testInputPath);

            // Attendre un peu
            Thread.Sleep(100);

            // Lire le contenu du fichier de sortie
            string outputContent;
            using (FileStream fs = new FileStream(outputPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader reader = new StreamReader(fs))
            {
                outputContent = reader.ReadToEnd();
            }

            // Vérifier que la ponctuation est supprimée mais les lettres russes restent
            Assert.IsTrue(outputContent.Contains("Привет"));
            Assert.IsTrue(outputContent.Contains("мир"));
            Assert.IsTrue(outputContent.Contains("Это"));
            Assert.IsFalse(outputContent.Contains("!"));
            Assert.IsFalse(outputContent.Contains("?"));
            Assert.IsFalse(outputContent.Contains("."));

            // Nettoyer
            File.Delete(testInputPath);
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }
        }
    }
}
