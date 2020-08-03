using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            ClaseImplementa objeto2 = new ClaseImplementa();
            MiClase<ClaseImplementa> objeto = new MiClase<ClaseImplementa>();
            objeto.Set(objeto2);

            MiClase2<ClaseNoImplementa> objeto3 = new MiClase2<ClaseNoImplementa>();

            ClaseImplementaTesto objeto4 = new ClaseImplementaTesto();

            objeto.Get().Tres();
            objeto3.GetNewItem().Tres();
            objeto3.GetNewItem().Cuatro(objeto4, x => Console.WriteLine(x.Cinco()));
        }

        
    }

    class Test
    {
        public static int Gospel {get; set;}
        public int newGospel { get; set; }
    }

    class MiClase<ITest> //where T: ITest
    {
        private ITest t;

        public void Set(ITest t)
        {
            this.t = t;
        }
        public ITest Get()
        {
            return t;
        }
    }

    class MiClase2<T> where T : ITest, new()
    {
        public T GetNewItem()
        {
            return new T();
        }
    }

    class ClaseImplementa : ITest
    {
        public int Uno { get; set; }
        public int Dos { get; set; }

        public void Tres()
        {
            Console.WriteLine("Soy el Metodo3");
        }

        public void Cuatro(ITesto f, Action<ITesto> q)
        {
            q(f);
        }
    }

    class ClaseNoImplementa : ITest
    {
        public int Uno { get; set; }
        public int Dos { get; set; }

        public void Tres()
        {
            Console.WriteLine("Soy el Metodo4");
        }

        public void Cuatro(ITesto f, Action<ITesto> q)
        {
            q(f);
        }
    }

    class ClaseImplementaTesto : ITesto
    {
        public string Cinco()
        {
            return "soy ITesto";
        }
    }

    interface ITest
    {
        int Uno { get; set; }
        int Dos { get; set; }

        void Tres();
        void Cuatro(ITesto f, Action<ITesto> q);
    }

    interface ITesto
    {
        string Cinco();
    }
}
