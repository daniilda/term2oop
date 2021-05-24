using System;

namespace Task_2_1 // Задание 2го уровня № 4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int n;
            double r1;
            double r2;
            int count = 0;
            double x;
            double y;
            Console.WriteLine("Enter amount of points (n)");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter internal radious (r1)");
            r1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter external radious (r2)");
            r2 = double.Parse(Console.ReadLine());
            if (r1 > r2)
            {
                Console.WriteLine("This is a wrong input pal");
            }
            for (int i=0; i<n; i++)
            {
                Console.WriteLine($"Enter X of point №{i + 1}");
                x = double.Parse(Console.ReadLine());
                Console.WriteLine($"Enter Y of point №{i + 1}");
                y = double.Parse(Console.ReadLine());
                if ((Math.Pow(x,2) + Math.Pow(y,2) >= Math.Pow(r1,2)) && (Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(r2, 2)))
                {
                    count++;
                } else
                {
                    continue;
                }
            }
            Console.WriteLine($"{count} of entered points are in the ring");
        }
        
    }
}
