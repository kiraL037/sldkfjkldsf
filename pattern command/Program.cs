using System;
using System.Collections.Generic;

namespace pattern_command
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Телевизор с двумя кнопками на пульте");
            Pult pult = new Pult();
            TV tv = new TV();
            pult.SetCommand(new TVOnCommand(tv));
            pult.PressButton();
            pult.PressUndo();

            Console.WriteLine("\nМикроволновка");
            Pult1 pult1 = new Pult1();
            Microwave microwave = new Microwave();
            pult1.SetCommand(new MicrowaveCommand(microwave, 5000));
            pult1.PressButton();

            Console.WriteLine("\nТелевизор с пультом");
            Volume volume = new Volume();
            MultiPult mPult = new MultiPult();
            mPult.SetCommand(0, new TVOnCommand(tv));
            mPult.SetCommand(1, new VolumeCommand(volume));
            mPult.PressButton(0);
            mPult.PressButton(1);
            mPult.PressButton(1);
            mPult.PressButton(1);
            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();
            mPult.PressUndoButton();

            Console.WriteLine("\nСоздание программного продукта");
            Programmer programmer = new Programmer();
            Tester tester = new Tester();
            Marketolog marketolog = new Marketolog();
            List<ICommand1> commands1 = new List<ICommand1>
            {
            new CodeCommand(programmer),
            new TestCommand(tester),
            new AdvertizeCommand(marketolog)
            };
            Manager manager = new Manager();
            manager.SetCommand(new MacroCommand(commands1));
            manager.StartProject();
            manager.StopProject();

            Console.Read();
        }
    }
    interface ICommand
    {
        void Execute();
        void Undo();
    }
    class TV
    {
        public void On()
        {
            Console.WriteLine("Телевизор включен!");
        }

        public void Off()
        {
            Console.WriteLine("Телевизор выключен...");
        }
    }
    class TVOnCommand : ICommand
    {
        TV tv;
        public TVOnCommand(TV tvSet)
        {
            tv = tvSet;
        }
        public void Execute()
        {
            tv.On();
        }
        public void Undo()
        {
            tv.Off();
        }
    }
    class Pult
    {
        ICommand command;

        public Pult() { }

        public void SetCommand(ICommand com)
        {
            command = com;
        }
        public void PressButton()
        {
            if (command != null)
                command.Execute();
        }
        public void PressUndo()
        {
            if (command != null)
                command.Undo();
        }
    }
}
