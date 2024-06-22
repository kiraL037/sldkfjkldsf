using System;
using System.Collections.Generic;
using System.Text;

namespace pattern_command
{
    class Pult1
    {
        ICommand command;

        public Pult1()
        {
            command = new NoCommand();
        }

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void PressButton()
        {
            command.Execute();
        }
        public void PressUndo()
        {
            command.Undo();
        }
    }
}
