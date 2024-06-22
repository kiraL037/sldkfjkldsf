using System;
using System.Windows;
using System.Collections.ObjectModel;

namespace project_Printer__strategy_
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
    }
    public interface IPrint
    {
        void Print();
    }
    public class Laser : IPrint
    {
        public void Print()
        {
            Console.WriteLine("Лазерная печать");
        }
    }
    public class Inkjet : IPrint
    {
        public void Print()
        {
            Console.WriteLine("Струйная печать");
        }
    }
    public class DotMatrix : IPrint
    {
        public void Print()
        {
            Console.WriteLine("Матричная  печать");
        }
    }
    public class Thermal : IPrint
    {
        public void Print()
        {
            Console.WriteLine("Термическая  печать");
        }
    }
    public class Plotter : IPrint
    {
        public void Print()
        {
            Console.WriteLine("Широкоформатная печать");
        }
    }
    public class Printer
    {
        public string Name { get; set; }
        public string OtherFeatures { get; set; }
        public IPrint Printing { get; set; }
        public void Print()
        {
            Printing.Print();
        }
    }

}
