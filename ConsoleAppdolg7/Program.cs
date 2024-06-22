using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleAppdolg7
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                StreamReader reader = new StreamReader("C:\\Users\\Анастас\\Desktop\\text.txt");
                string text = reader.ReadLine();
                Console.WriteLine(text);
                while (text != null)
                {
                    Console.WriteLine(text);
                    text = reader.ReadLine();
                    string Text = Regex.Replace(text, "[-.,?!():;]", "");
                    Console.WriteLine(Text);
                    Console.ReadLine();
                }
                reader.Close();
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
