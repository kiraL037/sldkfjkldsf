using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3_gr
{
    public delegate void FireEventHandler(object Sender, FireEventArgs args);
    public class NewTown
    { 
        private int build, BuildingNumber;  
        private int day, days; 
        private Police policeman;
        private Ambulance ambulanceman;
        private FireDetect fireman;
        public event FireEventHandler Fire;
        private Random rnd = new Random();
        private int m = 3, n = 10000;
        public NewTown(int TownSize, int Days)
        {
            BuildingNumber = rnd.Next(TownSize);
            days = Days;
            policeman = new Police(this);
            ambulanceman = new Ambulance(this);
            fireman = new FireDetect(this);
            policeman.On();
            ambulanceman.On();
            fireman.On();
        }
        protected virtual void OnFire(FireEventArgs e)
        {
            if (Fire != null)
                Fire(this, e);
        }
        public void LifeOurTown()
        {
            for (day = 1; day <= days; day++)
                for (build = 1; build <= BuildingNumber; build++)
                {
                    if (rnd.Next(n) <= m) 
                    {
                        FireEventArgs e = new FireEventArgs(build, day, true);
                        OnFire(e);
                        if (e.Permit)
                            Console.WriteLine("Пожар потушен!" + " Ситуация нормализована.");
                        else Console.WriteLine("Пожар продолжается." + " Требуются дополнительные средства!");
                    }
                }
        }
    }
}
