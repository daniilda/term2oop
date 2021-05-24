using System;

namespace Task_3_1 // Задание 3го уровня сделанное на основе задания № 5 2го уровня.
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            bool isItDouble = true;
            double result;
            double bestResult = int.MaxValue; // as I got the task than less than better 
            do
            {
                Console.WriteLine($"Enter the result of sportman #{i + 1} (to stop entering results enter NOT a number)");
                isItDouble = double.TryParse(Console.ReadLine(), out result);
                i++;
                if ((result < bestResult) && isItDouble)
                {
                    bestResult = result;
                }
                else
                {
                    continue;
                }
            } while (isItDouble);
            Console.WriteLine($"The best result is {bestResult}");

        }
    }
}
