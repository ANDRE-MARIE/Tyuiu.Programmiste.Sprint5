using System;
using Tyuiu.Programmiste.Sprint5.Task2.V9.Lib;

internal class Program
{
    private static void Main(string[] args)
    {
        int[,] matrix = {
            { 6, 8, 3 },
            { 2, 6, 8 },
            { 1, 7, 1 }
        };

        MatrixProcessor processor = new MatrixProcessor();
        string filePath = processor.SaveToFileTextData(matrix);

        Console.WriteLine($"Fichier sauvegardé : {filePath}");
        Console.WriteLine("Vérifiez dans le dossier 'output' si le fichier est correct.");
    }
}