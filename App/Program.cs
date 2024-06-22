using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[][] segments = new int[][] {
                new int[] { 1, 4 },
                new int[] { 3, 8 },
                new int[] { 9, 11 }
            };

            int totalShadowLength = CalculateShadowLength(segments);
            Console.WriteLine($"Shadow length: {totalShadowLength}");
            Console.ReadLine();
        }
        public static int CalculateShadowLength(int[][] segments)
        {

            int totalLength = 0;

            foreach (var segment in segments)
            {
                int start = segment[0];
                int end = segment[1];

                totalLength += end - start;
            }

            return totalLength;
        }
    }
}
