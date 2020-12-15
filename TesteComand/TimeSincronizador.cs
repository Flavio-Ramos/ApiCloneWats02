using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteComand
{
    class TimeSincronizador
    {
        public static System.Timers.Timer _timer;
        public void timeMain()
        {
            _timer = new System.Timers.Timer();
            _timer.AutoReset = false;
            _timer.Interval = valorDoTempo(); // Intervalo em milésimos
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(executarTarefa);
            _timer.Enabled = true;
        }
        static int valorDoTempo()
        {
            _timer.Enabled = false;
            Random novo = new Random();
            return novo.Next(1000, 10000);
        }
        static void executarTarefa(object sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Interval = valorDoTempo();
            Console.WriteLine("Função de sincronia "+_timer.Interval);
            _timer.Enabled = true;
        }
    }
}
