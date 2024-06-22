using System;

namespace ConsoleApp1_haha
{
    class Program
    {
        static void Main(string[] args)
        {
            TestPersonChildren();
        }
        public static void TestPersonProps()
        {
            Person pers1 = new Person();
            pers1.Fam = "Петров";
            pers1.Age = 21;
            pers1.Salary = 1000;
            Console.WriteLine("Фам={0}, возраст={1}, статус={2}",
                pers1.Fam, pers1.Age, pers1.Status);
            pers1.Fam = "Иванов"; pers1.Age += 1;
            Console.WriteLine("Фам={0}, возраст={1}, статус={2}",
                pers1.Fam, pers1.Age, pers1.Status);
        }//TestPersonProps
        public static void TestPersonChildren()
        {
            Person pers1 = new Person(), pers2 = new Person();
            pers1.Fam = "Петров"; pers1.Age = 42;
            pers1.Salary = 10000;
            pers1[pers1.Count_children] = pers2;
            pers2.Fam = "Петров"; pers2.Age = 21; pers2.Salary = 1000;
            Person pers3 = new Person();
            pers3.Fam = "Петрова";
            pers1[pers1.Count_children] = pers3;
            pers3.Fam = "Петрова"; pers3.Age = 5;
            Console.WriteLine("Фам={0}, возраст={1}, статус={2}",
                pers1.Fam, pers1.Age, pers1.Status);
            Console.WriteLine("Сын={0}, возраст={1}, статус={2}",
                pers2.Fam, pers2.Age, pers2.Status);
            Console.WriteLine("Дочь={0}, возраст={1}, статус={2}",
                pers3.Fam, pers3.Age, pers3.Status);
        }

    }
}
