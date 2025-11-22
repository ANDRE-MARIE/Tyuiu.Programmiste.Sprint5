

using Tyuiu.Programmiste.Sprint5.Task5.V18.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        DataService ds = new DataService();

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                       *");
        Console.WriteLine("***************************************************************************");

        string path = @"C:\DataSprint5\InPutDataFileTask5V18.txt";

        // Vérifier si le fichier existe
        if (!File.Exists(path))
        {
            Console.WriteLine($"Файл {path} не найден!");
            Console.WriteLine("Создайте папку C:\\DataSprint5\\ и скопируйте в нее файл InPutDataFileTask5V18.txt");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Данные находятся в файле: " + path);
        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* РЕЗУЛЬТАТ:                                                             *");
        Console.WriteLine("***************************************************************************");

        double res = ds.LoadFromDataFile(path);
        Console.WriteLine("Произведение всех двузначных чисел в файле = " + res);
        Console.ReadKey();
    }
}