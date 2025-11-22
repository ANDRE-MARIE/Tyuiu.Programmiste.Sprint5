using System;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Programmiste.Sprint5.Task3.V7.Lib
{
    public class DataService : ISprint5Task3V7
    {
        public string SaveToFileTextData(int x)
        {

            double result = 1.6 * Math.Pow(x, 3) - 2.1 * Math.Pow(x, 2) + 7 * x;
            result = Math.Round(result, 3);

            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(basePath, "OutPutFileTask3.bin");

            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Solution avec retry en cas de verrouillage
            int retryCount = 0;
            while (retryCount < 3)
            {
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        writer.Write(result);
                    }
                    break;
                }
                catch (IOException)
                {
                    retryCount++;
                    if (retryCount == 3) throw;
                    System.Threading.Thread.Sleep(100);
                }
            }

            Console.WriteLine($"f({x}) = {result}");
            return path;
        }
    }
}