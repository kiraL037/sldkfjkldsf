using System;

namespace ConsoleApp_18
{
    class Program
    {
        static void Main()
        {
            var p = new Program();
            p.TestClientSupplier();
        }
        public void TestClientSupplier()
        {
            ClassB objB = new ClassB("AA", 22, "BB", 33);
            objB.MethodB1();
            objB.MethodB2();
            objB.MethodB3();
        }
    }
}
