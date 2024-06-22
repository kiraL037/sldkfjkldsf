using System;

namespace Qaaaa
{
    public class Program
    {
        static void Main(string[] args)
        {
            double[] result = Qaaa(2, -5, 3);
            Console.WriteLine(result);
            Console.ReadLine();
        }
        public static double[] Qaaa(double a, double b, double c)
        {
            double[] result=new double[0];
            double D = Math.Pow(b, 2) - 4 * a * c;
            if (D > 0)
            {
                result = new double[] { (-b + Math.Sqrt(D)) / (2 * a), (-b - Math.Sqrt(D)) / (2 * a) };
            }
            else if (D == 0)
            {
                result = new double[] { -b / 2 * a };
            }
            return result;
        }
    }
}
