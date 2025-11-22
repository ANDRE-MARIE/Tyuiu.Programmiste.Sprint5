using System;
using Tyuiu.Programmiste.Sprint5.Task2.V9.Lib;

internal class Program
{
    static void Main()
    {
        int[,] matrix = {
            { 6, 8, 3 },
            { 2, 6, 8 },
            { 1, 7, 1 }
        };

        DataService service = new DataService();
        string cheminFichier = service.SaveToFileTextData(matrix);
        Console.WriteLine($"Fichier sauvegardé : {cheminFichier}");
        Console.WriteLine("Vérifiez dans le dossier 'output' si le fichier est correct.");
    }
}