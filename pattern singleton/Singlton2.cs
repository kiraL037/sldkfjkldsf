using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace pattern_singleton
{
    public class Singleton2
    {
        public string Date { get; private set; }
        public static string text = "hello";
        private Singleton2()
        {
            Console.WriteLine($"Singleton ctor {DateTime.Now.TimeOfDay}");
            Date = DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton2 GetInstance()
        {
            Console.WriteLine($"GetInstance {DateTime.Now.TimeOfDay}");
            Thread.Sleep(500);
            return Nested.instance;
        }

        private class Nested
        {
            static Nested() { }
            internal static readonly Singleton2 instance = new Singleton2();
        }
    }
}
