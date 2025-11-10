
using Tyuiu.Programmiste.Sprint5.Task1.V17.Lib;
internal class Program
{
    private static void Main(string[] args)
    {
        DataService ds = new DataService();

        Console.WriteLine("Tabulation de la fonction F(x) = 2x - 4 + (2x-1)/(sin(x)+1)");
        Console.WriteLine("Intervalle: [-5; 5] avec pas de 1");
        Console.WriteLine("==============================================");

        // Calcul et sauvegarde
        string result = ds.SaveToFileTextData(-5, 5);
        Console.WriteLine(result);
        Console.WriteLine();

        // Affichage du tableau
        DisplayTable(ds, -5, 5);

        Console.WriteLine("\nAppuyez sur une touche pour quitter...");
        Console.ReadKey();
    }

    static void DisplayTable(DataService ds, int start, int stop)
    {
        Console.WriteLine("Tableau des résultats:");
        Console.WriteLine("x\t\tF(x)");
        Console.WriteLine("----------------------");

        var data = ds.GetTabulatedData(start, stop);
        foreach (string line in data)
        {
            Console.WriteLine(line);
        }
    }
}
