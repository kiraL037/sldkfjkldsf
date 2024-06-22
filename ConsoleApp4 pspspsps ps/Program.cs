using System;

namespace ConsoleApp4_pspspsps_ps
{
    class Program
	{
		static void Main(string[] args)
        {
			var p = new Program();
			p.TestDebugPrint();
		}
        int state = 1; 
		public void TestDebugPrint()
		{
			DebugPrint.PrintEntry("Testing.TestDebugPrint");
			PubMethod();
			DebugPrint.PrintObject(state, "Testing.state");
			DebugPrint.PrintExit("Testing.TestDebugPrint");
		}
		void InMethod1()
		{
			DebugPrint.PrintEntry("InMethod1");
			DebugPrint.PrintExit("InMethod1");
		}
		void InMethod2()
		{
			DebugPrint.PrintEntry("InMethod2");
			DebugPrint.PrintExit("InMethod2");
		}
		public void PubMethod()
		{
			DebugPrint.PrintEntry("PubMethod");
			InMethod1();
			state++;
			InMethod2();
			DebugPrint.PrintExit("PubMethod");
		}
	}
}
