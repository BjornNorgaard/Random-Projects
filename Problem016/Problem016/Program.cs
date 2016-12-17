using System;
using System.Numerics;

namespace Problem016
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger numbers = (BigInteger)Math.Pow(2, 1000);
            string text = numbers.ToString();
            var sum = 0;

            foreach (char c in text)
            {
                sum += c - '0';
            }

            Console.WriteLine(sum);
        }
    }
}
