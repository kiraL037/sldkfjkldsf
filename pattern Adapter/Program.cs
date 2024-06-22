using System;

namespace pattern_Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Rndm();
            rnd.Rnd();

            Console.Read();
        }
    }
    class Rndm
    {
        public void Rnd()
        {
            Driver driver = new Driver();
            Random random = new Random();
            string[] TravelPath = { "дороге", "пустыне", "морю" };
            int TrPathIndex = random.Next(TravelPath.Length);
            Console.WriteLine("Путь лежит по {0}", TravelPath[TrPathIndex]);
            if (TrPathIndex==1)
            {
                Auto auto = new Auto();
                driver.Travel(auto);
            }
            else if (TrPathIndex == 2)
            {
                Camel camel = new Camel();
                ITransport camelTransport = new CamelToTransportAdapter(camel);
                driver.Travel(camelTransport);
            }
            else
            {
                Boat boat = new Boat();
                ITransport boatTransport = new BoatToTransportAdapter(boat);
                driver.Travel(boatTransport);
            }
        }
    }
    interface ITransport
    {
        void Drive();
    }
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Машина едет по дороге");
        }
    }
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    interface IShip
    {
        void Sail();
    }
    class Boat : IShip
    {
        public void Sail()
        {
            Console.WriteLine("Лодка плывет по морю");
        }
    }
    class BoatToTransportAdapter : ITransport
    {
        Boat boat;
        public BoatToTransportAdapter(Boat b)
        {
            boat = b;
        }
        public void Drive()
        {
            boat.Sail();
        }
    }
    interface IAnimal
    {
        void Move();
    }
    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Верблюд идет по пескам пустыни");
        }
    }
    class CamelToTransportAdapter : ITransport
    {
        Camel camel;
        public CamelToTransportAdapter(Camel c)
        {
            camel = c;
        }
        public void Drive()
        {
            camel.Move();
        }
    }
}
