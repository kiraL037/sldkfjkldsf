using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    internal class Person
    {
        public string Name { get; set; }
        static Person()
        {
            Console.WriteLine("Выполняется статический конструктор!");
        }
        public Person(string name)
        {
			Name = name;
        }
        Profession prof;
        public Profession Prof
        {
            get { return (prof); }
            set { prof = value; }
        }
		public void Analysis()
		{
			switch (prof)
			{
				case Profession.businessman:
					Console.WriteLine("профессия: бизнесмен");
					break;
				case Profession.teacher:
					Console.WriteLine("профессия: учитель");
					break;
				case Profession.engineer:
					Console.WriteLine("профессия: инженер");
					break;
				default:
					Console.WriteLine("профессия: неизвестна");
					break;
			}
		}

	}
}
