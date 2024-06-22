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
            int other = 30;
            int affected, tarrival, fire = 100;
            int tcombat = rnd.Next(3, 5);
            int tfirenotif = rnd.Next(1, 2);
            double rout = rnd.Next(1, 20);
            double v = rnd.Next(25, 45);
            double trout = 60 * (rout / v);
            int tfirestart = rnd.Next(1, 15);
            tarrival = tcombat + tfirenotif + Convert.ToInt32(Math.Round(trout));
            if (rout < 5 || tarrival < 5)
                affected = rnd.Next(0, 2);
            else if (rnd.Next(fire) > other && (tarrival > 40 || tfirestart > 10))
            {
                affected = rnd.Next(0, 6);
                Console.WriteLine("Возгорание в жилом секторе");
            }
            else affected = rnd.Next(0, 2);
            Console.WriteLine("\nВремя с начала пожара до его обнаружения " + tfirestart + " мин");
            Console.WriteLine("Расстояние от пожарной станции до места возгорания " + rout + " км");
            Console.WriteLine("Время, прошедшее с момента вызова пожарных " + tarrival + " мин");
            Console.WriteLine("Количество пострадавших " + affected);
        }
    }
}
