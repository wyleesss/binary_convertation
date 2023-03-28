using System;
using System.Text;

namespace binary_convertation
{
    internal class Program
    {
        static int[] FromDecimalToBinary255(int decimal_value)
        {
            int[] result = new int[8];

            if (decimal_value > 255)
                return result;

            for (int i = 128, it = 0; i > 0; i /= 2, it++) 
            {
                if (decimal_value >= i)
                {
                    result[it] = 1;
                    decimal_value -= i;
                }
                else
                    result[it] = 0;
            }

            return result;
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int DecimalValue;
            ConsoleKeyInfo for_exit;

            while (true)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("переведення числа з десяткової системи числення у двійкову\n");
                    Console.Write("введіть десяткове число (у діапазоні від 0 до 255):\n-> ");
                    DecimalValue = Convert.ToInt32(Console.ReadLine());
                }
                while (DecimalValue < 0 || DecimalValue > 255);

                Console.Write("\nрезультат:\n=> ");
                foreach (int i in FromDecimalToBinary255(DecimalValue))
                    Console.Write(i);

                Console.WriteLine("\n\nдля виходу натисніть ESC, для продовження - будь-яку іншу клавішу");

                if ((for_exit = Console.ReadKey()).Key == ConsoleKey.Escape)
                    break;
            }
        }
    }
}
