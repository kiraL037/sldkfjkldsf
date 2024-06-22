using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace pattern_singleton
{
    public class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        public static string text = "hello";
        public string Date { get; private set; }

        private Singleton()
        {
            Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
            Date = System.DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton GetInstance()
        {
            Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
            return instance;
        }
    }
}
