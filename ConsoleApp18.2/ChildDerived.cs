using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp18._2
{
    public class ChildDerived : Derived
    {
        public ChildDerived(string name, int cred, int deb) : base(name, cred, deb) { }
        public void Analysis(int level)
        {
            base.Analysis();
            Console.WriteLine("Анализ глубины {0}", level);
        }
        public override void VirtMethod()
        {
            Console.WriteLine("Внук: " + this.ToString());
        }

    }
}
