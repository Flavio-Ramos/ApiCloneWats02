using System;
using WatssDesktop.Models;

namespace WatssDesktop.SevircoSincronia
{
    public class SincroniaAutomaticaService
    {
        public static System.Timers.Timer _timer;
        public void SincronizarAutomaticamente()
        {
            _timer = new System.Timers.Timer();
            _timer.AutoReset = false;
            _timer.Interval = valorDoTempo(); // Intervalo em milésimos
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(ExecutarSincroniaAutomaticamente);
            _timer.Enabled = true;
        }
        private int valorDoTempo()
        {
            _timer.Enabled = false;
            Random novo = new Random();
            return novo.Next(10000, 15000);
        }
        private void ExecutarSincroniaAutomaticamente(object sender, System.Timers.ElapsedEventArgs e)
        {
            SincronizadorModel sincronizadorModel = new SincronizadorModel();
            sincronizadorModel.BotaoSincronizar();
            _timer.Interval = valorDoTempo();
            _timer.Enabled = true;
        }
    }
}
