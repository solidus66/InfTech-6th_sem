using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите число столбцов в матрице: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введите число колонок в матрице: ");
        int cols = int.Parse(Console.ReadLine());

        int[,] matrix = new int[rows, cols];

        Console.WriteLine("Введите элементы матрицы:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Введите элемент [{i}, {j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            int min = matrix[i, 0]; 
            int colIndex = 0;

            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                    colIndex = j;
                }
            }

            bool isSaddlePoint = true;

            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                if (matrix[k, colIndex] > min)
                {
                    isSaddlePoint = false;
                    break;
                }
            }

            if (isSaddlePoint)
            {
                Console.WriteLine($"Седловая точка найдена на ({i}, {colIndex}) со значением {min}");
            }
        }
        Console.ReadKey();
    }
}