using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp_LAB_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTask: 123");
            Console.ResetColor(); // Сброс цвета текста в стандартный (белый)
            Task123();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTask: 130");
            Console.ResetColor();
            Task130();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTask: 149");
            Console.ResetColor();
            Task149();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTask: 186");
            Console.ResetColor();
            Task186();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTask: 37");
            Console.ResetColor();
            Task37();
        }

        /// <summary>
        /// Генерирует случайный массив целых чисел в указанном диапазоне.
        /// </summary>
        /// <param name="minValue">Минимальное значение (по умолчанию 1).</param>
        /// <param name="maxValue">Максимальное значение (по умолчанию 100).</param>
        /// <param name="length">Длина массива (по умолчанию 10).</param>
        /// <param name="allowDuplicates">Разрешить повторение элементов (по умолчанию true)</param>
        /// <returns>Случайный массив целых чисел.</returns>
        static int[] GenerateRandomArray(int minValue = 1, int maxValue = 100, int length = 10,
            bool allowDuplicates = true)
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
            for (int i = 0; i < length; i++)
            {
                if (allowDuplicates)
                {
                    array[i] = random.Next(minValue, maxValue + 1);
                }
                else //check repeating elements
                {
                    int value;
                    do
                    {
                        value = random.Next(minValue, maxValue + 1);
                    } while (Array.IndexOf(array, value, 0, i) != -1);

                    array[i] = value;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Array : [" + string.Join(", ", array) + "]");
            Console.ResetColor();
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

        /// <summary>
        ///  130 : Даны целые положительные числа а1, а2, ..., an.
        ///        Найти среди них те, которые являются квадратами некоторого числа m.
        /// </summary>
        static void Task130()
        {
            int[] a = GenerateRandomArray();

            int[] squareNumbers = FindSquareNumbers(a);

            if (squareNumbers.Length > 0)
            {
                Console.WriteLine("Numbers that are squares of a number m:");
                Console.WriteLine(string.Join(", ", squareNumbers));
            }
            else
            {
                Console.WriteLine("There are no numbers in the array that are squares of some number m.");
            }
        }

        ///<summary>
        ///принимает массив целых положительных чисел numbers и находит числа, являющиеся квадратами
        ///</summary>
        static int[] FindSquareNumbers(int[] numbers)
        {
            int[] squares = new int[numbers.Length];
            int count = 0;

            foreach (int num in numbers)
            {
                int sqrt = (int)Math.Sqrt(num);
                if (sqrt * sqrt == num)
                {
                    squares[count] = num;
                    count++;
                }
            }

            // Create a new array with the actual size and copy numbers
            int[] result = new int[count];
            Array.Copy(squares, result, count);

            return result;
        }

        /// <summary>
        ///  149: Даны две последовательности а1, а2, ..., an и b1, b2, ..., bm (m < n).
        ///       В каждой из них члены различны.
        ///       Верно ли, что все члены второй последовательности входят в первую последовательность?
        /// </summary>
        static void Task149()
        {
            Console.Write("1 ");
            int[] sequenceA = GenerateRandomArray(1, 15, 15, false);
            Console.Write("2 ");
            int[] sequenceB = GenerateRandomArray(1, 10, 5, false); //(m < n)

            bool allInSequenceA = sequenceB.All(x => sequenceA.Contains(x));

            if (allInSequenceA)
            {
                Console.WriteLine("All members of the second sequence enter the first sequence.");
            }
            else
            {
                Console.WriteLine("Not all members of the second sequence are in the first sequence.");
            }
        }

        /// <summary>
        ///  186: В одномерном массиве все отрицательные элементы переместить в начало массива,
        ///       а остальные — в конец с сохранением порядка следования.
        ///       Дополнительный массив использовать не разрешается
        /// </summary>
        static void Task186()
        {
            int[] array = GenerateRandomArray(-50, 50);

            int negativeIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    (array[i], array[negativeIndex]) = (array[negativeIndex], array[i]);
                    negativeIndex++;
                }
            }

            Console.WriteLine("Array with negative elements at the beginning:");
            Console.WriteLine(string.Join(", ", array));
        }

        /// <summary>
        ///  37: Даны натуральные числа а1, а2, ..., an.
        ///      Указать те из них, у кот. остаток от деления на М равен L (0 ≤ L ≤ M – 1).
        /// </summary>
        static void Task37()
        {
            int[] array = GenerateRandomArray();
            int M = 5;
            int L = 2;

            Console.WriteLine(
                $"The remainder of division by {M} is {L}: {string.Join(", ", FindNumbersWithRemainder(array, M, L))}");
        }

        ///<summary>
        ///метод для нахождения чисел, удовлетворяющих условию остатка от деления на M равного L
        ///</summary>
        static int[] FindNumbersWithRemainder(int[] array, int M, int L)
        {
            int[] result = new int[array.Length];
            int count = 0;

            foreach (int num in array)
            {
                if (num % M == L)
                {
                    result[count] = num;
                    count++;
                }
            }

            int[] filteredNumbers = new int[count];
            Array.Copy(result, filteredNumbers, count);

            return filteredNumbers;
        }
    }
}