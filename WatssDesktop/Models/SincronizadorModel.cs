using App.Domain.Desctop;
using App.Domain.Desctop.Enums;
using App.Repository.Desctop;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WatssDesktop.Models
{
     class SincronizadorModel
    {
        public SincronizadorDTO Sincronizar(SincronizadorDTO objSinc)
        {
             return SincronizarMensagem(objSinc);
        }

        private SincronizadorDTO SincronizarMensagem(SincronizadorDTO sincMensagem)
        {

            if(sincMensagem == null)
            {
                sincMensagem = new SincronizadorDTO();
            }
            MensagemDAO mensagem = new MensagemDAO();
            

            if (sincMensagem.StatusSincroniaMensagem == Status.Enviando)
            {
                foreach (MensagemDTO obj in sincMensagem.ListaMensagem)
                {
                    mensagem.InserirMensagemDB(obj);
                }

                sincMensagem.StatusSincroniaMensagem = Status.Ok;
            }

            if(sincMensagem.StatusGrupoSincronia == Status.Solicitando) 
            {
                var listaMensagem = mensagem.PegarDadosParaEnviarSincronia(sincMensagem);

                if (listaMensagem.Any())
                {
                    sincMensagem.ListaMensagem = listaMensagem;
                    sincMensagem.StatusSincroniaMensagem = Status.Enviando;
                }
                else
                {
                    sincMensagem.StatusSincroniaMensagem = Status.Ok;
                }
                sincMensagem.StatusGrupoSincronia = Status.Ok;
                return sincMensagem;
            }

            return sincMensagem;
        }

        public async Task BotaoSincronizar()
        {
           
            string url = "http://myfirstprogram.gearhostpreview.com/api/Sincronizador";

            string dados = "";
            SincronizadorDTO obj = new SincronizadorDTO();
            dados = new JavaScriptSerializer().Serialize(PegarDadosUltimaSincronia());
            HttpContent c = new StringContent(dados, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.PostAsync(url, c);
                if (result.IsSuccessStatusCode)
                {
                    dados = "";
                    dados = await result.Content.ReadAsStringAsync();
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(SincronizadorDTO));
                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(dados));
                    obj = (SincronizadorDTO)serializer.ReadObject(ms);
                    obj = Sincronizar(obj);
                    if (obj.StatusSincroniaMensagem == Status.Enviando)
                    {
                        dados = "";
                        dados = new JavaScriptSerializer().Serialize(obj);
                        c = new StringContent(dados, Encoding.UTF8, "application/json");
                        using (client)
                        {
                            HttpResponseMessage result2 = await client.PostAsync(url, c);
                        }
                    }
                }
                dados = "";
            }
        }

        
        public void sincronizarAutomaticamente()
        {
            Mensagens f = new Mensagens();
            f.lalbeSincronia.BackColor = Color.Red;
        }
        internal SincronizadorDTO PegarDadosUltimaSincronia()
        {
            MensagemDAO mensagem = new MensagemDAO();
            SincronizadorDTO sincronizador = mensagem.PegarDadosParaSolicitarSincronia();
            if (sincronizador.ListaDeGruposSincroniaPay.Any())
            {
                sincronizador.StatusGrupoSincronia = Status.Solicitando;
            }
            else
            {
                sincronizador.StatusGrupoSincronia = Status.Ok;
            }
            return sincronizador;
        }
    }
}
