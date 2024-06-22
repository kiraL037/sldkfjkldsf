using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3_gr
{
    public abstract class Receiver
    {
        public abstract void It_is_Fire(object sender, FireEventArgs e);
        private NewTown town;
        public Receiver(NewTown town)
        { this.town = town; }
        public void On()
        {
            town.Fire += new FireEventHandler(It_is_Fire);
        }
        public void Off()
        {
            town.Fire -= new FireEventHandler(It_is_Fire);
            town = null;
        }
    }
}
