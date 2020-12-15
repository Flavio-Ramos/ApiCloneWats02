using System;
using System.Collections.Generic;
using App.Domain;
using App.Repository;

namespace ApiCloneWats02.Models
{
    public class MensagenModel
    {
        public List<MensagemDTO> ListarMensagem()
        {
            try
            {
                var mensagem = new MensagemDAO();
                return mensagem.ListarMensagensDB();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao listar Mensagem: {e.Message}");
            }

        }

        public void InserirMensagem(MensagemDTO mensagem)
        {
            try
            {
                //MensagemDAO pegarSync = new MensagemDAO();
                //int MinhaUltimaSync = pegarSync.PegarDadosUltimaSincronia(mensagem.PaiSyncronia, mensagem.Grupo);
                MensagemDAO mensagemDAO = new MensagemDAO();
                //mensagem.ContSyncronia = MinhaUltimaSync + 1;
                mensagemDAO.InserirMensagemDB(mensagem);

                //MensagemDAO mensagemDAO = new MensagemDAO();
                //mensagemDAO.InserirMensagemDB(mensagem);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao inserir Mensagem: {e.Message}");
            }
        }

    }
}