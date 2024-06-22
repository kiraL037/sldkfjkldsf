using System;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp4_ps____ps
{
    class Program
    {
        static void Main(string[] args)
        {
			var p = new Program();
			p.Optima();
		}
		public void Optima()
		{
			double x, y = 1;
			x = y - 2 * Math.Sin(y);
			FileStream f = new FileStream("Debuginfo.txt", FileMode.Create, FileAccess.Write);
			TextWriterTraceListener writer1 = new TextWriterTraceListener(f);
			TextWriterTraceListener writer2 = new TextWriterTraceListener(Console.Out);
			Trace.Listeners.Add(writer1);
			Trace.Listeners.Add(writer2);
            Debug.WriteLine("Число слушателей:" + Trace.Listeners.Count);
			Debug.WriteLine("автоматический вывод из буфера:" + Trace.AutoFlush);
			Trace.WriteLineIf(x < 0, "Trace: " + "x= " + x.ToString() + " y = " + y);
			Debug.WriteLine("Debug: " + "x= " + x.ToString() + " y = " + y);
			Trace.Flush();
			f.Close();
		}
	}
}
