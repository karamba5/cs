using System;

namespace Lab1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string folder = @"";
            string file = "3.txt";

            TextAnalyzer analyzer = new TextAnalyzer();

            analyzer.Display(folder + file);

            Console.WriteLine("\n\n\n\nPress any key...");
            Console.ReadKey();
        }
    }
}
