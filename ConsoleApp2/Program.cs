using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            ImportTours();
        }

        private static void ImportTours()
        {
            var fileData = File.ReadAllLines(@"C:\Users\Анастас\Downloads\Туры (1) - Лист1 — копия");
            var images = Directory.GetFIles(@"C:\Users\Анастас\Downloads\Туры (1) - Лист1 — копия");

            foreach (var line in fileData)
            {
                var data = new Tour
                {
                    Name=dat
                }
            }
        }
    }
}
