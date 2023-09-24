using System;
using System.Linq;

namespace CSharp_LAB_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Task123();
        }

        /// <summary>
        /// Генерирует случайный массив целых чисел в указанном диапазоне.
        /// </summary>
        /// <param name="minValue">Минимальное значение (по умолчанию 1).</param>
        /// <param name="maxValue">Максимальное значение (по умолчанию 100).</param>
        /// <param name="length">Длина массива (по умолчанию 10).</param>
        /// <returns>Случайный массив целых чисел.</returns>
        static int[] GenerateRandomArray(int minValue = 1, int maxValue = 100, int length = 10)
        {
            Random random = new();
            //check input valu
            if (minValue > maxValue)
            {
                throw new ArgumentException("The minimum value must be less than or equal to the maximum value.");
            }

            if (length <= 0)
            {
                throw new ArgumentException("Array length must be a positive number.");
            }

            int[] array = new int[length];
            Console.Write("Array: [ ");
            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(minValue, maxValue + 1);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("]");

            return array;
        }

        /// <summary>
        ///  123 : Дана последовательность целых положительных чисел.
        ///        Найти произведение только тех из них, которые больше заданного числа М.
        ///        Если таких чисел нет, то выдать сообщение об этом.
        /// </summary>
        static void Task123()
        {
            int[] sequence = GenerateRandomArray();
            int M = 4;


            int[] filteredNumbers = new int[sequence.Length];
            int filteredCount = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] > M)
                {
                    filteredNumbers[filteredCount] = sequence[i];
                    filteredCount++;
                }
            }

            if (filteredCount > 0)
            {
                long product = 1;
                for (int i = 0; i < filteredCount; i++)
                {
                    product *= filteredNumbers[i];
                }

                Console.WriteLine($"Product of numbers more {M}: {product}");
            }
            else
            {
                Console.WriteLine($"No more numbers {M} in the sequence.");
            }
        }
    }
}