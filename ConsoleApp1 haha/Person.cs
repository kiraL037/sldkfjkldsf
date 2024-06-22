using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1_haha
{
		public class Person
		{
		const int Child_Max = 20; //максимальное число детей
		Person[] children = new Person[Child_Max];
		int count_children = 0; //число детей
		public Person this[int i] //индексатор
		{
			get
			{
				if (i >= 0 && i < count_children) return (children[i]);
				else return (children[0]);
			}
			set
			{
				if (i == count_children && i < Child_Max)
				{ children[i] = value; count_children++; }
			}
		}

		//поля (все закрыты)
		string fam = "", status = "", health = "";
			int age = 0, salary = 0;
			//методы - свойства
			/// <summary>
			///стратегия: Read,Write-once (Чтение, запись при 
			///первом обращении)
			/// </summary>
			public string Fam
			{
				set { if (fam == "") fam = value; }
				get { return (fam); }
			}
			/// <summary>
			///стратегия: Read-only(Только чтение)
			/// </summary>
			public string Status
			{
				get { return (status); }
			}
			/// <summary>
			///стратегия: Read,Write (Чтение, запись)
			/// </summary>
			public int Age
			{
				set
				{
					age = value;
					if (age < 7) status = "ребенок";
					else if (age < 17) status = "школьник";
					else if (age < 22) status = "студент";
					else status = "служащий";
				}
				get { return (age); }
			}
			/// <summary>
			///стратегия: Write-only (Только запись)
			/// </summary>
			public int Salary
			{
				set { salary = value; }
			}

        public int Count_children { get; internal set; }
    }
}
