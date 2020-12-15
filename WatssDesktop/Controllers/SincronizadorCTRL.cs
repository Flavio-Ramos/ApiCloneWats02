using App.Domain.Desctop;
using System.Threading.Tasks;
using WatssDesktop.Models;

namespace WatssDesktop.Controllers
{
    public class SincronizadorCTRL
    {
        internal SincronizadorDTO Sincronizar(SincronizadorDTO sincronizador)
        {
            SincronizadorModel sincronizadorModel = new SincronizadorModel();
            return sincronizadorModel.Sincronizar(sincronizador);
        }

        internal SincronizadorDTO PegarDadosUltimaSincronia()
        {
            SincronizadorModel sincronizadorModel = new SincronizadorModel();
            return sincronizadorModel.PegarDadosUltimaSincronia();
        }

        internal async Task<bool> BotaoSincronizar()
        {
            SincronizadorModel sincronizador = new SincronizadorModel();
            await sincronizador.BotaoSincronizar();
            return true;
        }
    }
}
