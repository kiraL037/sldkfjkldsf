using System;

namespace Liskov_Substitution_Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new MicroAccount();
            InitializeAccount(acc);

            Console.Read();
        }

        public static void InitializeAccount(Account account)
        {
            account.SetCapital(200);
            Console.WriteLine(account.Capital);
        }

    }
    class Account
    {
        public int Capital { get; protected set; }

        public virtual void SetCapital(int money)
        {
            if (money < 0)
                throw new Exception("Нельзя положить на счет меньше 0");
            this.Capital = money;
        }
    }

    class MicroAccount : Account
    {
        public override void SetCapital(int money)
        {
            if (money < 0)
                throw new Exception("Нельзя положить на счет меньше 0");

            if (money > 100)
                throw new Exception("Нельзя положить на счет больше 100");

            this.Capital = money;
        }
    }


}
