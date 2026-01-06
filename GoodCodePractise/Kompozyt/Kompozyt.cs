using System;
using System.Collections.Generic;

namespace GoodCodePractise.Composite
{

    public abstract class Pojazd
    {
        protected string Name;

        protected Pojazd(string name)
        {
            Name = name;
        }

        public abstract void Opisz();
    }


    public class Auto : Pojazd
    {
        public Auto(string name) : base(name) { }

        public override void Opisz()
        {
            Console.WriteLine("Auto: " + Name);
        }
    }

    public class Rower : Pojazd
    {
        public Rower(string name) : base(name) { }

        public override void Opisz()
        {
            Console.WriteLine("Rower: " + Name);
        }
    }


    public class Skuter : Pojazd
    {
        public Skuter(string name) : base(name) { }

        public override void Opisz()
        {
            Console.WriteLine("Skuter: " + Name);
        }
    }


    public class FlotaPojazdow : Pojazd
    {
        private List<Pojazd> pojazdy = new();

        public FlotaPojazdow(string name) : base(name) { }

        public void Dodaj(Pojazd pojazd)
        {
            pojazdy.Add(pojazd);
        }

        public void Usun(Pojazd pojazd)
        {
            pojazdy.Remove(pojazd);
        }

        public override void Opisz()
        {
            Console.WriteLine("Flota: " + Name);
            foreach (var pojazd in pojazdy)
            {
                pojazd.Opisz(); // REKURENCJA
            }
        }
    }

 
}
