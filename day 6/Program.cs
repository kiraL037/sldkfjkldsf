using System;

namespace day_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1, p2;
            p1 = new Person();
            p2 = new Person();
            p1.name = "taro";
            p1.age = 19;
            p2.SetAgeAndName("hanako", 23);
            p1.ShowAgeAndName();
            p2.ShowAgeAndName();
        }
    }
}
