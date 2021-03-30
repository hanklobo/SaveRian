using System;
using System.Collections.Generic;
using System.Linq;

namespace SaveRian
{
    public class GameEngine : IGameEngine
    {
        // How much tries until finish?
        private const int Tries = 2;
        private readonly IIo _io;
        
        public GameEngine(IIo io)
        {
            _io = io;
        }
        
        private void Init()
        {
            _io.Clear();
            _io.WriteLine("==== Salve Rian ====");
            _io.WriteLine($"Digite 0 para encerrar ou {Tries} tentativas inválidas encerram a execução.");
        }
        
        public int LoadUserInput()
        {
            for (var i = 1; i <= Tries; i++)
            {
                _io.Write("Soldados: ");
                var input = _io.Read();
                
                if (int.TryParse(input, out var totalSoldiers))
                    return totalSoldiers;
                
                _io.WriteLine($"Informe um número válido. Tentativa {i}/{Tries}.");
            }
            
            return 0;
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
                _io.WriteLine($"Posição: {posicaoDesejada}");
                _io.WriteLine("---");
            }
        }
    }
}