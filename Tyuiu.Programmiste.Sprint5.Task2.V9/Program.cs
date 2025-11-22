
using Tyuiu.Programmiste.Sprint5.Task2.V9.Lib;
internal class Program
{
    public string SaveToFileTextData(int[,] matrix)
    {
        // Crée le dossier "output" si il n'existe pas
        string directoryPath = "output";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Chemin complet vers le fichier dans le dossier "output"
        string filename = Path.Combine(directoryPath, "OutPutFileTask2.csv");

        // Remplacer les éléments impairs par 0
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] % 2 != 0)
                {
                    matrix[i, j] = 0;
                }
            }
        }

        // Écrire dans le fichier
        using (StreamWriter sw = new StreamWriter(filename))
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string line = "";
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    line += matrix[i, j];
                    if (j < matrix.GetLength(1) - 1)
                        line += " ; ";
                }
                sw.WriteLine(line);
            }
        }

        // Afficher le contenu dans la console
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string line = "";
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                line += matrix[i, j];
                if (j < matrix.GetLength(1) - 1)
                    line += " ; ";
            }
            Console.WriteLine(line);
        }

        // Retourne le chemin du fichier créé
        return filename;
    }
}
