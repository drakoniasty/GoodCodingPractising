using System;
using System.Collections.Generic;

namespace GoodCodePractise.Command
{
    public class PojazdReceiver
    {
        public void UruchomAuto(string name) => Console.WriteLine($"Uruchomiono auto: {name}");
        public void UruchomRower(string name) => Console.WriteLine($"Rozpoczęto jazdę rowerem: {name}");
        public void UruchomSkuter(string name) => Console.WriteLine($"Uruchomiono skuter: {name}");
    }

    public interface IPojazdCommand
    {
        void Wykonaj();
    }

    public class AutoCommand : IPojazdCommand
    {
        private readonly PojazdReceiver _receiver;
        private readonly string _name;

        public AutoCommand(PojazdReceiver receiver, string name)
        {
            _receiver = receiver;
            _name = name;
        }

        public void Wykonaj()
        {
            _receiver.UruchomAuto(_name);
        }
    }

    public class RowerCommand : IPojazdCommand
    {
        private readonly PojazdReceiver _receiver;
        private readonly string _name;

        public RowerCommand(PojazdReceiver receiver, string name)
        {
            _receiver = receiver;
            _name = name;
        }

        public void Wykonaj()
        {
            _receiver.UruchomRower(_name);
        }
    }

    public class SkuterCommand : IPojazdCommand
    {
        private readonly PojazdReceiver _receiver;
        private readonly string _name;

        public SkuterCommand(PojazdReceiver receiver, string name)
        {
            _receiver = receiver;
            _name = name;
        }

        public void Wykonaj()
        {
            _receiver.UruchomSkuter(_name);
        }
    }

    public class PojazdInvoker
    {
        private readonly List<IPojazdCommand> _komendy = new();

        public void DodajKomende(IPojazdCommand komenda)
        {
            _komendy.Add(komenda);
        }

        public void WykonajWszystkie()
        {
            foreach (var komenda in _komendy)
            {
                komenda.Wykonaj();
            }
        }
    }

