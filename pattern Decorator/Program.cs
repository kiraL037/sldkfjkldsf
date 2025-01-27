﻿using System;

namespace pattern_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza1 = new ItalianPizza();
            pizza1 = new TomatoPizza(pizza1); 
            Console.WriteLine("Название: {0}", pizza1.Name);
            Console.WriteLine("Цена: {0}", pizza1.GetCost(), "$");

            Pizza pizza2 = new ItalianPizza();
            pizza2 = new SalamiPizza(pizza2);
            pizza2 = new CheesePizza(pizza2);
            pizza2 = new MushroomPizza(pizza2);
            Console.WriteLine("Название: {0}", pizza2.Name);
            Console.WriteLine("Цена: {0}", pizza2.GetCost(), "$");

            Pizza pizza3 = new BulgerianPizza();
            pizza3 = new TomatoPizza(pizza3);
            pizza3 = new CheesePizza(pizza3);
            Console.WriteLine("Название: {0}", pizza3.Name);
            Console.WriteLine("Цена: {0}", pizza3.GetCost(), "$");

            Console.ReadLine();
        }
    }

    abstract class Pizza
    {
        public Pizza(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Итальянская пицца")
        { }
        public override int GetCost()
        {
            return 5;
        }
    }
    class BulgerianPizza : Pizza
    {
        public BulgerianPizza()
            : base("Болгарская пицца")
        { }
        public override int GetCost()
        {
            return 4;
        }
    }

    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            this.pizza = pizza;
        }
    }

    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza p)
            : base(p.Name + ", с томатами", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 1;
        }
    }
    class SalamiPizza : PizzaDecorator 
    {
        public SalamiPizza(Pizza p) : base(p.Name + ", с салями", p) { }
        public override int GetCost()
        {
            return pizza.GetCost() + 2;
        }
    }
    class MushroomPizza : PizzaDecorator
    {
        public MushroomPizza(Pizza p):base (p.Name + ", с грибами", p) { }
        public override int GetCost()
        {
            return pizza.GetCost() + 1;
        }
    }
    class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza p) : base(p.Name + ", с сыром", p) { }

        public override int GetCost()
        {
            return pizza.GetCost() + 1;
        }
    }
}
