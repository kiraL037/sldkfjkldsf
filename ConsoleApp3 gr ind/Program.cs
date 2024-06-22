using System;

namespace ConsoleApp3_gr
{
    class Program
    {
        static void Main()
        {
            var p = new Program();
            p.TestLifeTown();
        }
        public void TestLifeTown()
        {
            NewTown sometown = new NewTown(100, 100);
            sometown.LifeOurTown();
        }
    }
}
