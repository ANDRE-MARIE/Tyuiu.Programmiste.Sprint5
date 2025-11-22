
using Tyuiu.Programmiste.Sprint5.Task6.V27.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        DataService ds = new DataService();

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* ИСХОДНЫЕ ДАННЫЕ:                                                       *");
        Console.WriteLine("***************************************************************************");

        string path = @"C:\DataSprint5\InPutDataFileTask6V27.txt";

        // Vérifier si le fichier existe
        if (!File.Exists(path))
        {
            Console.WriteLine($"Файл {path} не найден!");
            Console.WriteLine("Создайте папку C:\\DataSprint5\\ и скопируйте в нее файл InPutDataFileTask6V27.txt");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Данные находятся в файле: " + path);

        // Lire et afficher le contenu du fichier
        string fileContent = File.ReadAllText(path);
        Console.WriteLine("Содержимое файла: " + fileContent);

        Console.WriteLine("***************************************************************************");
        Console.WriteLine("* РЕЗУЛЬТАТ:                                                             *");
        Console.WriteLine("***************************************************************************");

        int res = ds.LoadFromDataFile(path);
        Console.WriteLine("Количество трехзначных чисел в строке = " + res);
        Console.ReadKey();
    }
}