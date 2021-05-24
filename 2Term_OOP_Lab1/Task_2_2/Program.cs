using System;

namespace Task_2_2 // Задание 2го уровня № 9
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double result;
            double bestResult = int.MaxValue; // as I got the task than less than better 
            Console.WriteLine("Enter amount of sportsmen");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter the result of sportman #{i + 1}");
                result = double.Parse(Console.ReadLine());
                if (result < bestResult)
                {
                    bestResult = result;
                } else
                {
                    continue;
                }
            }
            Console.WriteLine($"The best result is {bestResult}");

        }
    }
}
