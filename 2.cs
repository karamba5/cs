using System;
using System.Text;

namespace Lab2._2
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Ціле значення діленого (A): ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Ціле значення дільник (B): ");
            int b = int.Parse(Console.ReadLine());

            string binary1 = Convert.ToString(a, 2);
            string binary2 = Convert.ToString(b, 2);
            Func(a, b);

            Console.ReadKey();
        }

        public static void Func(Int32 dividend, Int32 divisor)
        {
            int d = dividend;
            int r = divisor;

            while (r < dividend)
            {
                r <<= 1;
            }
            Console.WriteLine(dividend + " / " + divisor);
            Console.WriteLine(Convert.ToString(Convert.ToInt32(dividend), 2) + " / " + Convert.ToString(Convert.ToInt32(divisor), 2) + "\n");
            Console.WriteLine("Ділене  " + Convert.ToString(Convert.ToInt32(d), 2));
            Console.WriteLine("Дільник   " + Convert.ToString(Convert.ToInt32(r), 2) + "\n");
            string result = string.Empty;
            for (int i = 0; i < 128; i++)
            {
                Console.WriteLine("Крок " + (i + 1));
                if (d < divisor && r < divisor)
                {
                    break;
                }
                if (r > d)
                {
                    r >>= 1;
                    Console.WriteLine("Зсув");
                    result += "0";
                }
                else
                {
                    d -= r;
                    Console.WriteLine("Ділене - Дільник");
                    result += "1";
                    r >>= 1;
                }
                Console.WriteLine("Ділене  " + Convert.ToString(Convert.ToInt32(d), 2));
                Console.WriteLine("Дільник   " + Convert.ToString(Convert.ToInt32(r), 2));
                Console.WriteLine("Частка = " + result + "\n");

            }
            Console.WriteLine("Частка: " + Convert.ToInt32(result, 2) + " ( " + result + " ) " + "   залишок : " + d + " ( " + Convert.ToString(Convert.ToInt32(d), 2) + " ) ");

        }
    }
}