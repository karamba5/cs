using System;
using System.IO;
using System.Linq;

namespace Lab1
{
    public class TextAnalyzer
    {
        private const int m = 33;

        public (double[] arr, int count) GetFrequency(string filePath)
        {
            double[] arr = new double[m];
            string text;
            using (StreamReader read = new StreamReader(filePath))
            {
                text = read.ReadToEnd();
            }

            var symCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (Enum.TryParse(text[i].ToString().ToLower(), out Alphabet alphabet))
                {
                    symCount++;
                    arr[(int)alphabet]++;
                }

            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] / symCount;
            }

            return (arr, symCount);
        }

        public (double H, int count) GetEntro(string filePath)
        {
            var frequency = GetFrequency(filePath);

            double h = 0;

            for (int i = 0; i < m; i++)
            {
                if (frequency.arr[i] > 0)
                    h += frequency.arr[i] * Math.Log(frequency.arr[i], 2);
            }

            return (h * -1, frequency.count);
        }

        public (double info, int fileSize) GetInfo(string filePath)
        {
            var entro = GetEntro(filePath);

            double infoL = entro.H * entro.count;

            return (info: infoL, fileSize: 2);
        }

        public void Display(string filePath)
        {
            double[] arr = GetFrequency(filePath).arr;

            double h = GetEntro(filePath).H;

            double info = GetInfo(filePath).info;


            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} = {1,-9:0.0000}", (Alphabet)i, arr[i]);
            }
            Console.WriteLine("\n\n");

            Console.WriteLine("Ентропія = {0:0.000}", h);
            Console.WriteLine("Кіл. інф = {0:0.000}", info / 8);
        }
    }
}
