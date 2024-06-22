using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3_gr
{
    public class FireEventArgs : EventArgs
    {
        private int build;
        private int day;
        private bool permit;
        public int Build
        {
            get { return (build); } 
        }
        public int Day
        {
            get { return (day); } 
        }
        public bool Permit
        {
            get { return (permit); }
            set { permit = value; }
        }
        public FireEventArgs(int build, int day, bool permit)
        {
            this.build = build; 
            this.day = day;
            this.permit = permit;
        }
    }

}
