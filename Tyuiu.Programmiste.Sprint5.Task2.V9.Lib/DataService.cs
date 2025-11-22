using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Programmiste.Sprint5.Task2.V9.Lib
{
    //Étant donné un tableau d'entiers bidimensionnel 3x3 rempli de valeurs de clavier,  
    //remplacez les éléments impairs du tableau par 0.
    //Enregistrez le résultat dans le fichier OutPutFileTask2.csv et affichez-le sur la console.

    //6 ; 8 ; 3

    //2 ; 6 ; 8

    //1; 7; 1
    public class DataService : ISprint5Task2V9
    {
        public string SaveToFileTextData(int[,] matrix)
        {
            string path = $@"{Directory.GetCurrentDirectory()}\OutPutFileTask2.csv";

            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "output");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
     
            // Si le fichier existe, le supprimer
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            int rows = matrix.GetUpperBound(0) + 1;
            int columns = matrix.GetLength(1); // plus simple

            // Remplacer les impairs par 0
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] % 2 != 0)
                        matrix[i, j] = 0;
                }
            }

            // Écrire dans le fichier
            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < rows; i++)
                {
                    string line = "";
                    for (int j = 0; j < columns; j++)
                    {
                        line += matrix[i, j];
                        if (j < columns - 1)
                            line += " ; ";
                    }
                    sw.WriteLine(line);
                }
            }

            // Afficher dans la console
            for (int i = 0; i < rows; i++)
            {
                string line = "";
                for (int j = 0; j < columns; j++)
                {
                    line += matrix[i, j];
                    if (j < columns - 1)
                        line += " ; ";
                }
                Console.WriteLine(line);
            }

            // Retourne le chemin complet du fichier créé
            return path;
        }
    }
}
