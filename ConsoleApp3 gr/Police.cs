using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3_gr
{
    public class Police : Receiver
    {
        public Police(NewTown town) : base(town) { }
        public override void It_is_Fire(object sender, FireEventArgs e)
        {
            Console.WriteLine("Пожар в доме {0}. День {1}-й."+ " Милиция ищет виновных!", e.Build, e.Day);
            e.Permit &= true;
        }
    }

}
