using App.Repository.Desctop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatssDesktop.Models;

namespace WatssDesktop.Controllers
{
    class MensagemCTRL
    {
        public void EnviarMensagem(string mensagem)
        {
            //vai para model
            MensagenModel mensagenModel = new MensagenModel();
            mensagenModel.SalvarMensagem(mensagem);

        }
    }
}
