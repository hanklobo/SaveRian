using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveRian
{
    public class GameEngine : IGameEngine
    {
        // How much tries until finish?
        private const int Tries = 2;
        // Testing control
        private readonly bool _testing;
        public GameEngine(bool testing = false)
        {
            _testing = testing;
        }
        private void Init()
        {
            if (_testing)
                return;
            Console.Clear();
            Console.WriteLine("==== Salve Rian ====");
            Console.WriteLine("Digite 0 para encerrar. Três tentativas inválidas encerram a execução.");
        }
        public int LoadUserInput(string forcedInput = "")
        {
            for (var i = 1; i <= (_testing ? 1 : Tries); i++)
            {
                Write("Soldados: ");
                var input = _testing ? forcedInput : Console.ReadLine();
                if (int.TryParse(input, out var totalSoldiers))
                    return totalSoldiers;
                WriteLine($"Informe um número válido. Tentativa {i}/{Tries}.");
            }
            return 0;
        }
        private void Write(string text)
        {
            if (!_testing)
                Console.Write(text);
        }
        private void WriteLine(string text)
        {
            if (!_testing)
                Console.WriteLine(text);
        }
        public int DesiredPosition(int totalSoldiers)
        {
            var listSoldiers = new List<int>(Enumerable.Range(1, totalSoldiers));
            while (listSoldiers.Count() > 1)
                for (var i = 0; i < listSoldiers.Count(); i++)
                    listSoldiers.RemoveAt((i+1 < listSoldiers.Count() ? i : i-listSoldiers.Count()) + 1);

            return listSoldiers.ElementAt(0);
        }
        public void Run()
        {
            Init();
            while (true)
            {
                var totalSoldados = LoadUserInput();
                if (totalSoldados == 0)
                    return;

                var posicaoDesejada = DesiredPosition(totalSoldados);
                WriteLine($"Posição: {posicaoDesejada}");
                WriteLine("---");
            }
        }
    }
}