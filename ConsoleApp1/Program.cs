using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Решение системы уравнений методом Крамера");
            int[,] A = { { 2, -4, 1 }, { 1, -5, 3 }, { 1, -1, 1 } };
            int rows = A.GetUpperBound(0) + 1;
            int columns = A.GetUpperBound(1) + 1;
            Console.Write("Свободные члены B =");
            for (int l = 0; l < columns; l++)
            {
                int[] b = { 3, -1, 1 };
                Console.Write($" {b[l]} ");
            }
            Console.Write("\n");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{A[i, j]}\t");
                }
                Console.WriteLine();
            }
            int detA, main, side;
            main = A[0, 0] * A[1, 1] * A[2, 2] + A[0, 1] * A[1, 2] * A[2, 0] + A[0, 2] * A[2, 1] * A[1, 0];
            side = A[0, 0] * A[1, 2] * A[2, 1] + A[0, 2] * A[1, 1] * A[2, 0] + A[0, 1] * A[1, 0] * A[2, 2];
            detA = main - side;
            Console.WriteLine($"Значение определителя матрицы A = {detA}");
            int
            if (columns < 0 || column >=)
                Console.Read();
        }
    } 
}
