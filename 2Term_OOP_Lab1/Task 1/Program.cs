using System;

namespace Task_1 // Задание 1го уровня, № 7
{
    class Program
    {
        static void Main(string[] args)
        {
            double y;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Введите x");
            double x = double.Parse(Console.ReadLine());
            if (Math.Abs(x) > 1)
            {
                y = 1;
            } else
            {
                y = Math.Abs(x);
            }
            Console.WriteLine($"y = {y}");
        }
    }
}
