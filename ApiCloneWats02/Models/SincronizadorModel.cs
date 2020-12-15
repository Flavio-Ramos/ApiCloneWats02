using App.Domain;
using App.Domain.Enums;
using App.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ApiCloneWats02.Models
{
    public class SincronizadorModel
    {
        public SincronizadorModel()
        {
        }

        public SincronizadorDTO Sincronizar(SincronizadorDTO objSinc)
        {
            return SincronizarMensagem(objSinc);
        }

        private SincronizadorDTO SincronizarMensagem(SincronizadorDTO sincMensagem)
        {
            if (sincMensagem.StatusGrupoSincronia == Status.Solicitando)
            {
                //pegar Mensagens no banco e enviar
                MensagemDAO objMensagemDao = new MensagemDAO();
                SincronizadorDTO devolveSincronia = new SincronizadorDTO();
                devolveSincronia.ListaMensagem = objMensagemDao.PegarDadosParaEnviarSincronia(sincMensagem);
                
                if (devolveSincronia.ListaMensagem.Any())
                {
                    devolveSincronia.StatusSincroniaMensagem = Status.Enviando;
                }
                else
                {
                    devolveSincronia.StatusSincroniaMensagem = Status.Ok;
                }

                List<GrupoSincronizadoresPaiDTO> listaDeGruposSincroniaPay = objMensagemDao.PegarDadosParaSolicitarSincronia(sincMensagem);
                if (!listaDeGruposSincroniaPay.Any() || listaDeGruposSincroniaPay[0].IdGrupo == 0)
                {
                    devolveSincronia.StatusGrupoSincronia = Status.Ok;
                }
                else
                {
                    devolveSincronia.ListaDeGruposSincroniaPay = listaDeGruposSincroniaPay;
                    devolveSincronia.StatusGrupoSincronia = Status.Solicitando;
                }
                
                return devolveSincronia;
            }

            if (sincMensagem.StatusSincroniaMensagem == Status.Enviando)
            {
                //salvar no banco
                MensagemDAO objMensagemDao = new MensagemDAO();
                objMensagemDao.SincronizarMenagens(sincMensagem.ListaMensagem);
                sincMensagem.StatusSincroniaMensagem = Status.Ok;
                sincMensagem.ListaMensagem = null;
                return null;
            }
            if (sincMensagem.StatusSincroniaMensagem == Status.Ok)
            {
                return null;
            }
           
            return null;
        }

        //public SincronizadorDTO Sincronizar(SincronizadorDTO sincronia)
        //{
        //    //vai para DAO
        //    SincronizadorDTO resultadoSinc = new SincronizadorDTO();
        //    SincronizadorDAO sincronizadorDAO = new SincronizadorDAO();
        //    resultadoSinc = sincronizadorDAO.PegaTodasMaxSincronia(sincronia,resultadoSinc);
        //    sincronia = VerificarSincroniaMensagem(sincronia, resultadoSinc);
        //    return sincronia;
        //}


        //private SincronizadorDTO VerificarSincroniaMensagem(SincronizadorDTO sincroniaBase,SincronizadorDTO sincroniaResult)
        //{
        //    if(sincroniaBase.MaxSincMensagem == sincroniaResult.MaxSincMensagem)
        //    {
        //        sincroniaBase.StatusSincroniaMensagem = StatusSincroniaMensagem.Ok;
        //        return sincroniaBase;
        //    }

        //    if (sincroniaBase.MaxSincMensagem > sincroniaResult.MaxSincMensagem)
        //    {
        //        sincroniaBase.StatusSincroniaMensagem = StatusSincroniaMensagem.Solicitando;
        //        sincroniaBase.MaxSincMensagem = sincroniaResult.MaxSincMensagem;
        //        return sincroniaBase;
        //    }

        //    if (sincroniaBase.MaxSincMensagem < sincroniaResult.MaxSincMensagem)
        //    {
        //        sincroniaBase.StatusSincroniaMensagem = StatusSincroniaMensagem.Enviando;
        //        SincronizadorDAO sincronizadorDAO = new SincronizadorDAO();
        //        sincronizadorDAO.PegarMensagensNaoSincronizadas(sincroniaBase);

        //        return sincroniaBase;
        //    }
        //    return sincroniaBase;
        //}

    }
}