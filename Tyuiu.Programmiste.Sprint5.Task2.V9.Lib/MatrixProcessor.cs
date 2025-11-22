using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Programmiste.Sprint5.Task2.V9.Lib
{
    //Étant donné un tableau d'entiers bidimensionnel 3x3 rempli de valeurs de clavier,  
    //remplacez les éléments impairs du tableau par 0.
    //Enregistrez le résultat dans le fichier OutPutFileTask2.csv et affichez-le sur la console.

    //6 ; 8 ; 3

    //2 ; 6 ; 8

    //1; 7; 1
    public class MatrixProcessor : ISprint5Task2V9
    {
        public string SaveToFileTextData(int[,] matrix)
        {
            string directoryPath = "output";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Chemin complet du fichier
            string filename = Path.Combine(directoryPath, "OutPutFileTask2.csv");

            // Remplacer les impairs par 0
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] % 2 != 0)
                        matrix[i, j] = 0;
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

            // Afficher dans la console
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

            return filename;
        }
    }
}
