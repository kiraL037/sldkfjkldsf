using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3_gr
{
    public class FireDetect : Receiver
    {
        public FireDetect(NewTown town) : base(town) { }
        public override void It_is_Fire(object sender, FireEventArgs e)
        {
            Console.WriteLine("Пожар в доме {0}. День {1}-й." + " Пожарные тушат пожар!", e.Build, e.Day);
            Random rnd = new Random(e.Build);
            if (rnd.Next(10) > 5)
                e.Permit &= false;
            else e.Permit &= true;
        }
    }
}
