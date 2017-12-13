using System;
using KMatrix;

namespace TestMyClassMatrix
{
    class Program
    {
        static void Main()
        {
            Random rand = new Random();

            Matrix firstMatrix = new Matrix(2, 4);
            for (int i = 0; i < firstMatrix.Length;++i)
            {
                for (int j = 0; j < firstMatrix.Width; j++)
                {
                    firstMatrix.Elements[i, j] = rand.Next(0, 100);
                }
            }

            Matrix secondMatrix = new Matrix(2, 3);
            for (int i = 0; i < secondMatrix.Length; ++i)
            {
                for (int j = 0; j < secondMatrix.Width; j++)
                {
                    secondMatrix.Elements[i, j] = rand.Next(0, 100);
                }
            }
            Matrix trihMatrix = new Matrix(2, 4);
            for (int i = 0; i < trihMatrix.Length; ++i)
            {
                for (int j = 0; j < trihMatrix.Width; j++)
                {
                    trihMatrix.Elements[i, j] = rand.Next(0, 100);
                }
            }
            Console.WriteLine($"Матриця(A):\n{firstMatrix.ToString()}");
            Console.WriteLine($"Матриця(B):\n{secondMatrix.ToString()}");
            Console.WriteLine($"Матриця(C):\n{trihMatrix.ToString()}");
            try
            {
                Console.WriteLine($"Транспортування матрицi А :\n{firstMatrix.Transpose().ToString()}");
            }
            catch (Exception)
            {
                Console.WriteLine("Матрицю не вдалось транспортувати!");
            }
            Console.WriteLine(
                $"Порiвняння матриць (А==B)={firstMatrix.Equals(secondMatrix)} (А==A)={firstMatrix.Equals(firstMatrix)}.");
            try
            {
                var resultMatrix = firstMatrix - secondMatrix;
            Console.WriteLine($"Рiзниця матриць(A-B):\n {resultMatrix.ToString()};");
            }
            catch (Exception)
            {
                Console.WriteLine("\nМатрицi А i B не вдалось вiдняти!");
            }
           

            try
            {
                var resultMatrix = firstMatrix - trihMatrix;
                Console.WriteLine($"\nРiзниця матриць(A-C):\n{resultMatrix.ToString()}");
            }
            catch (Exception)
            {
                Console.WriteLine("Матрицi А i C не вдалось вiдняти!");
            }

            try
            {
                var resultMatrix = firstMatrix + trihMatrix;
                Console.WriteLine($"Сума матриць(A+C):\n{resultMatrix.ToString()}");
            }
            catch (Exception)
            {
                Console.WriteLine("Матрицi А i C не вдалось додати!");
            }

            try
            {
                int g = rand.Next(0, 10);
                var resultMatrix = firstMatrix *g ;
                Console.WriteLine($"Добуток матрицi на число(A*{g}):\n{resultMatrix.ToString()}");
            }
            catch (Exception)
            {
                Console.WriteLine("Матрицю не вдалось помножити на число!");
            }
            Console.ReadKey();
        }
    }
}
