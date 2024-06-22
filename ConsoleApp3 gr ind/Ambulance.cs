using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3_gr
{
    public class Ambulance : Receiver
    {
        Random rnd = new Random();
        public Ambulance(NewTown town) : base(town) { }
        public override void It_is_Fire(object sender, FireEventArgs e)
        {
            Console.WriteLine("Пожар в доме {0}. День {1}-й." + " Скорая спасает пострадавших!", e.Build, e.Day);
            e.Permit &= true;
        }
    }

}
