using System;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Segundo => 10s = 10 segundos");
            Console.WriteLine("M = Minuto 1m => 1 minuto");
            Console.WriteLine("0s = Sair");
            Console.WriteLine("Quanto tempo deseja contar ?");

            string data = Console.ReadLine().ToLower();

            // Verifica se a entrada é nula, vazia, não inicia com número ou é muito curta.
            if (string.IsNullOrWhiteSpace(data) || !char.IsDigit(data[0]) || data.Length < 2)
            {
                Console.WriteLine("Entrada inválida. Por favor, insira um valor seguido por 's' ou 'm'");
                Thread.Sleep(2000);
                Menu();
                return;
            }

            // Obtém o último caractere da entrada para determinar o tipo de unidade de tempo ('s' para segundos, 'm' para minutos).
            char type = char.Parse(data.Substring(data.Length - 1, 1));
            // Converte a parte numérica da entrada (sem o último caractere) para um inteiro.
            // Exemplo: se a entrada for "10s", o resultado será 10.
            int time = int.Parse(data.Substring(0, data.Length - 1));
            int multiplier = 1;

            if (type == 'm')
                multiplier = 60;
            else if (time == 0)
                System.Environment.Exit(0);

            PreStart(time * multiplier);
        }

        static void PreStart(int time)
        {
            Console.Clear();
            Console.WriteLine("Ready ...");
            Thread.Sleep(1000);

            Console.WriteLine("Set ...");
            Thread.Sleep(1000);

            Console.WriteLine("Go ...");
            Thread.Sleep(2500);

            Start(time);
        }
        static void Start(int time)
        {
            int currentTime = 0;

            while (currentTime !=  time /*>= 0*/)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);
                // Console.WriteLine(time); Contagem regressiva
                Thread.Sleep(1000);
                // time--; Contagem regressiva
            }

            Console.Clear();
            Console.WriteLine("Stopwatch finalizado");
            // Console.WriteLine("Contagem regressiva finalizada");
            Thread.Sleep(2500);
            Menu();
        }
    }
}
