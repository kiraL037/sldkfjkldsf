using System;

namespace pattern_Fluent_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            User tom = new UserBuilder().SetName("Tom").SetCompany("Microsoft").SetAge(23);
            User alice = User.CreateBuilder().SetName("Alice").IsMarried.SetAge(25);

            Burger uglyBurger = new Burger(true, true, false, false, false); 
            BurgerBuilder burgerBuilder = new BurgerBuilder();
            Burger awesomeburger = burgerBuilder.WithCheese().WithBacon().Build();
        }
    }
    public class User
    {
        public string Name { get; set; }         
        public string Company { get; set; }     
        public int Age { get; set; }             
        public bool IsMarried { get; set; }      

        public static UserBuilder CreateBuilder()
        {
            return new UserBuilder();
        }
    }
    public class UserBuilder
    {
        private User user;
        public UserBuilder()
        {
            user = new User();
        }
        public UserBuilder SetName(string name)
        {
            user.Name = name;
            return this;
        }
        public UserBuilder SetCompany(string company)
        {
            user.Company = company;
            return this;
        }
        public UserBuilder SetAge(int age)
        {
            user.Age = age > 0 ? age : 0;
            return this;
        }
        public UserBuilder IsMarried
        {
            get
            {
                user.IsMarried = true;
                return this;
            }
        }
        public static implicit operator User(UserBuilder builder)
        {
            return builder.user;
        }
    }
    public class Burger
    {
        public int NumPatties { get; set; }
        public bool Cheese { get; set; }
        public bool Bacon { get; set; }
        public bool Pickles { get; set; }
        public bool Letuce { get; set; }
        public bool Tomato { get; set; }
        public Burger(int numPatties = 1)
        {
            NumPatties = numPatties;
        }
        public Burger(bool cheese, bool bacon, bool pickles, bool letuce, bool tomato, int numPatties = 1) { }
    }
    public class BurgerBuilder
    {
        private Burger _burger = new Burger();
        public Burger Build() => _burger;
        public BurgerBuilder WithPatties(int num)
        {
            _burger.NumPatties = num;
            return this;
        }
        public BurgerBuilder WithCheese()
        {
            _burger.Cheese = true;
            return this;
        }
        public BurgerBuilder WithBacon()
        {
            _burger.Bacon = true;
            return this;
        }
    }
}