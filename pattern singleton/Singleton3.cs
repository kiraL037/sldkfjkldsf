using System;
using System.Collections.Generic;
using System.Text;

namespace pattern_singleton
{
    public class Singleton3
    {
        private static readonly Lazy<Singleton3> lazy = new Lazy<Singleton3>(() => new Singleton3());

        public string Name { get; private set; }

        private Singleton3()
        {
            Name = Guid.NewGuid().ToString();
        }

        public static Singleton3 GetInstance()
        {
            return lazy.Value;
        }
    }
}
