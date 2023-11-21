using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк (n): ");
            int n = int.Parse(Console.ReadLine());

            double[][] matrix = new double[n][];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите значения для строки {i + 1}, разделенные пробелами: ");
                string[] input = Console.ReadLine().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                matrix[i] = new double[input.Length];
                for (int j = 0; j < input.Length; j++)
                {
                    if (double.TryParse(input[j], out double value))
                    {
                        matrix[i][j] = value;
                    }
                    else
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                double min = 0, max = 0, sum = 0;
                FindMinMaxAndSum(matrix[i], ref min, ref max, out sum);

                Console.WriteLine(
                    $"Строка {i + 1}: Минимальное значение = {min}, Максимальное значение = {max}, Сумма = {sum}");
            }
        }

        static void FindMinMaxAndSum(double[] array, ref double min, ref double max, out double sum)
        {
            if (array.Length == 0)
            {
                min = 0;
                max = 0;
                sum = 0;
                return;
            }

            min = max = array[0];
            sum = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }

                if (array[i] > max)
                {
                    max = array[i];
                }

                sum += array[i];
            }
        }
    }
}