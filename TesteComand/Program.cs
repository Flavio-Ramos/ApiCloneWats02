using System;

namespace TesteComand
{
    class Program
    {    static void Main(string[] args)
        {
            TimeSincronizador timeSincronizador = new TimeSincronizador();
            timeSincronizador.timeMain();

            //TesteEvento testeEvento = new TesteEvento();
            //testeEvento.MainTeste();

            //TesteUnico testeUnico = new TesteUnico();
            //testeUnico.Main();
            Console.ReadLine();
        }
    }
}
