using System;
using System.Threading;

namespace pattern_singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Singleton");
            Console.WriteLine("Multithreading problem"); 
            Computer comp = new Computer();
            comp.Launch("Windows 8.1");
            Console.WriteLine(comp.OS.Name);
            comp.OS = OS.GetInstance("Windows 10");
            Console.WriteLine(comp.OS.Name);
            Console.WriteLine("\nMultithreading realization without lock");
            (new Thread(() =>
            {
                Singleton1 singleton1 = Singleton1.GetInstance();
                Console.WriteLine(singleton1.Date);
            })).Start();
            Singleton1 singleton2 = Singleton1.GetInstance();
            Console.WriteLine(singleton2.Date);
            Console.WriteLine("\nLazy-реализация");
            Console.WriteLine("\nFirst problem");
            Console.WriteLine($"Main {DateTime.Now.TimeOfDay}");
            Console.WriteLine(Singleton.text); 
            Console.WriteLine("\nSolution to the first problem");
            Console.WriteLine($"Main {DateTime.Now.TimeOfDay}");
            Console.WriteLine(Singleton.text);
            Console.WriteLine("\nSolution to the second problem"); 
            Console.WriteLine($"Main {DateTime.Now.TimeOfDay}");
            Console.WriteLine(Singleton2.text);
            Singleton2 singleton1 = Singleton2.GetInstance();
            Console.WriteLine(singleton1.Date);
            Console.WriteLine("\nLazy<T>");
            Console.WriteLine($"Main {DateTime.Now.TimeOfDay}");
            Singleton3 singleton = Singleton3.GetInstance();
            Console.ReadLine();
        }
    }
    class Computer
    {
        public OS OS { get; set; }
        public void Launch(string osName)
        {
            OS = OS.GetInstance(osName);
        }
    }
    class OS
    {
        private static OS instance;

        public string Name { get; private set; }
        private static object syncRoot = new Object();

        protected OS(string name)
        {
            this.Name = name;
        }

        public static OS GetInstance(string name)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new OS(name);
                }
            }
            return instance;
        }
    }

}
