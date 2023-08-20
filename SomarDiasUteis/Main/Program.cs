using System;
using System.Data;
using System.Globalization;

namespace Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? resposta = "";

            do
            {
                CriarFormulario();

                Console.WriteLine("Deseja sair do programa ? (S/N)");
                resposta = Console.ReadKey().Key.ToString();


            } while (resposta?.ToUpper() != "S");

        }

        static void CriarFormulario()
        {

            Console.Clear();
            Console.WriteLine("----- SOMAR DIAS UTEIS A UMA DATA -----");
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Informe a data incial: ");
            DateTime dataInicial = DateTime.Now;
            DateTime.TryParse (Console.ReadLine(), out dataInicial);

            Console.Write("Informe a quantidade de dias uteis: ");
            int numDiasUteis = 0;
            Int32.TryParse(Console.ReadLine(), out numDiasUteis);

            DateTime dataResultado = SomarDiasUteis(dataInicial, numDiasUteis); 

            Console.WriteLine("");
            Console.WriteLine("Data final: " + dataResultado.ToShortDateString() + " - " + dataResultado.ToString("dddd", new System.Globalization.CultureInfo("pt-BR")));

        }

        /// <summary>
        /// Adiciona dias uteis a uma data informada. Para isso faz uma iteração e verifica que dias são sábados e domingos.
        /// </summary>
        /// <param name="dataInicial">Data incial</param>
        /// <param name="numDiasUteis">Quantidade de dias uteis.</param>
        /// <returns>Retorna a data resultado da data inicial mais os dias uteis.</returns>
        static DateTime SomarDiasUteis(DateTime dataInicial, int numDiasUteis)
        {
            DateTime dataResultado = dataInicial;

            while (numDiasUteis > 0)
            {
                dataResultado = dataResultado.AddDays(1);

                if (dataResultado.DayOfWeek != DayOfWeek.Saturday && dataResultado.DayOfWeek != DayOfWeek.Sunday)
                {
                    numDiasUteis--;
                }
            }

            return dataResultado;
        }
    }
}