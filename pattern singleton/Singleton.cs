using System;
using System.Collections.Generic;
using System.Text;

namespace pattern_singleton
{
    public class Singleton1
    {
        private static readonly Singleton1 instance = new Singleton1();

        public string Date { get; private set; }

        private Singleton1()
        {
            Date = System.DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton1 GetInstance()
        {
            return instance;
        }
    }
}
