using System;
using System.Collections.Generic;
using System.Text;

namespace pattern_command
{
    interface ICommand1
    {
        void Execute1();
        void Undo1();
    }
    class MacroCommand : ICommand1
    {
        List<ICommand1> commands1;
        public MacroCommand(List<ICommand1> coms)
        {
            commands1 = coms;
        }
        public void Execute1()
        {
            foreach (ICommand1 c in commands1)
                c.Execute1();
        }
        public void Undo1()
        {
            foreach (ICommand1 c in commands1)
                c.Undo1();
        }
    }
    class Programmer
    {
        public void StartCoding()
        {
            Console.WriteLine("Программист начинает писать код");
        }
        public void StopCoding()
        {
            Console.WriteLine("Программист завершает писать код");
        }
    }
    class Tester
    {
        public void StartTest()
        {
            Console.WriteLine("Тестировщик начинает тестирование");
        }
        public void StopTest()
        {
            Console.WriteLine("Тестировщик завершает тестирование");
        }
    }
    class Marketolog
    {
        public void StartAdvertize()
        {
            Console.WriteLine("Маркетолог начинает рекламировать продукт");
        }
        public void StopAdvertize()
        {
            Console.WriteLine("Маркетолог прекращает рекламную кампанию");
        }
    }
    class CodeCommand : ICommand1
    {
        Programmer programmer;
        public CodeCommand(Programmer p)
        {
            programmer = p;
        }
        public void Execute1()
        {
            programmer.StartCoding();
        }
        public void Undo1()
        {
            programmer.StopCoding();
        }
    }
    class TestCommand : ICommand1
    {
        Tester tester;
        public TestCommand(Tester t)
        {
            tester = t;
        }
        public void Execute1()
        {
            tester.StartTest();
        }
        public void Undo1()
        {
            tester.StopTest();
        }
    }
    class AdvertizeCommand : ICommand1
    {
        Marketolog marketolog;
        public AdvertizeCommand(Marketolog m)
        {
            marketolog = m;
        }
        public void Execute1()
        {
            marketolog.StartAdvertize();
        }

        public void Undo1()
        {
            marketolog.StopAdvertize();
        }
    }
    class Manager
    {
        ICommand1 command1;
        public void SetCommand(ICommand1 com)
        {
            command1 = com;
        }
        public void StartProject()
        {
            if (command1 != null)
                command1.Execute1();
        }
        public void StopProject()
        {
            if (command1 != null)
                command1.Undo1();
        }
    }
}

