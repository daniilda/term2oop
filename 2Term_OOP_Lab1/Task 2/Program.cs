using System;

namespace Task_2 // Задание 1го уровня № 2
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            double y;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Введите x");
            x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите y");
            y = double.Parse(Console.ReadLine());
            if ((y >= 0) && (y + Math.Abs(x) <= 1)) {
                Console.WriteLine("Принадлежит");
            } else
            {
                Console.WriteLine("Не принадлежит");
            }
        }
    }
}
