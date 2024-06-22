using System;
using System.Text.RegularExpressions;

namespace ConsoleAppdolg_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст: ");
            string text = Console.ReadLine();
            string Text = Regex.Replace(text, "[-.,?!():;]", "");
            Console.WriteLine("\nТекст без знаков препинания и пробелов\n" + Text);
            Console.ReadLine();
        }
    }
}
