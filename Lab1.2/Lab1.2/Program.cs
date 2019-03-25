using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab1._2
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string text;
            string folder = @"";
            string file = "3.tar.bz2";

            using (StreamReader read = new StreamReader(folder + file))
            {
                text = read.ReadToEnd();
            }
            
            byte[] textInBytes = Encoding.ASCII.GetBytes(text);

            string base64 = new string(Base64.GetEncoded(textInBytes));
            Console.WriteLine("Мій алгоритм");
            Console.WriteLine(base64);
            Console.WriteLine();
            Console.WriteLine("Не мій алгоритм");
            Console.WriteLine(Convert.ToBase64String(textInBytes));

            using (StreamWriter write = new StreamWriter(folder + "base3.txt"))
            {
                write.Write(base64);
            }

            Console.ReadKey();
        }
    }
}
