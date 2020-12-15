using App.Domain.Desctop;
using App.Domain.Desctop.Enums;
using App.Repository.Desctop;
using System.Collections.Generic;

namespace WatssDesktop.Models
{
    class MensagenModel
    {
        public List<MensagemDTO> ListarMensagens(int qtdRegistros)
        {
            MensagemDAO mensagemDAO = new MensagemDAO();
            return mensagemDAO.ListarMensagensDB(qtdRegistros);
        }

        public void SalvarMensagem(string mensagem)
        {
            MensagemDAO pegarSync = new MensagemDAO();
            int MinhaUltimaSync = pegarSync.PegarDadosUltimaSincronia();
            MensagemDAO mensagemDAO = new MensagemDAO();
            MensagemDTO mensagemDTO = new MensagemDTO();
            mensagemDTO.Mensagem = mensagem;
            mensagemDTO.Id = 1;
            mensagemDTO.PaiMensagem = 1;
            mensagemDTO.Grupo = 1;
            mensagemDTO.PaiSyncronia = 1;
            mensagemDTO.ContSyncronia = MinhaUltimaSync + 1;

            mensagemDAO.SalvarMensagem(mensagemDTO);
        }

        public SincronizadorDTO Teste1Sincronizador()
        {
            SincronizadorDTO teste1 = new SincronizadorDTO()
            {
                StatusSincroniaMensagem = Status.Perguntando,
                //MaxSincMensagem = 0,
                //MaxSincUsuario = 0,
                //MaxSincContatos = 0,
                //ListaMensagem = null,
                //ListaUsuarios = null,
                //ListaContatos = null
                /* "StatusSincroniaMensagem": 5,
    "StatusGrupoSincronia": 1,
    "MaxSincMensagem": 0,
    "MaxSincUsuario": 0,
    "MaxSincContatos": 0,
    "ListaMensagem": [
        {
            "Id": 27,
            "Mensagem": "Precisamos resolver um assunto",
            "Grupo": 1,
            "PaiMensagem": 1,
            "PaiSyncronia": 1,
            "ContSyncronia": 2
        }
    ],
    "ListaUsuarios": [],
    "ListaContatos": [],
    "ListaDeGruposSincroniaPay": []
}*/
            };
            return teste1;
        }

        public SincronizadorDTO Teste2Sincronizador()
        {

            SincronizadorDTO sincronizador = new SincronizadorDTO();
            sincronizador.StatusSincroniaMensagem = Status.Solicitando;
            //sincronizador.MaxSincMensagem = 1;
            //sincronizador.MaxSincUsuario = 1;
            //sincronizador.MaxSincContatos = 1;

            List<MensagemDTO> listaMensagem = new List<MensagemDTO>();
            MensagemDTO m1 = new MensagemDTO()
            {
                Id = 2,
                Mensagem = "Teste2",
                Grupo = 1,
                PaiMensagem = 1,
                PaiSyncronia = 1,
                ContSyncronia = 2
            };
            listaMensagem.Add(m1);

            MensagemDTO m2 = new MensagemDTO()
            {
                Id = 3,
                Mensagem = "Teste3",
                Grupo = 1,
                PaiMensagem = 1,
                PaiSyncronia = 1,
                ContSyncronia = 3
            };
            listaMensagem.Add(m2);

            MensagemDTO m3 = new MensagemDTO()
            {
                Id = 4,
                Mensagem = "Teste4",
                Grupo = 1,
                PaiMensagem = 1,
                PaiSyncronia = 1,
                ContSyncronia = 4
            };
            listaMensagem.Add(m3);
            //sincronizador.ListaMensagem = listaMensagem;
            sincronizador.ListaMensagem = null;

            UsuarioDTO us = new UsuarioDTO();
            us = null;
            sincronizador.ListaUsuarios.Add(us);

            ContatoDTO ct = new ContatoDTO();
            ct = null;
            sincronizador.ListaContatos.Add(ct);

            GrupoSincronizadoresPaiDTO Gs = new GrupoSincronizadoresPaiDTO();
            Gs.IdGrupo = 1;

            PaiSincronia sp1 = new PaiSincronia();
            sp1.Id = 1;
            sp1.MaxSincronia = 1;
            Gs.SincroniasPai.Add(sp1);

            PaiSincronia sp2 = new PaiSincronia();
            sp2.Id = 2;
            sp2.MaxSincronia = 2;
            Gs.SincroniasPai.Add(sp2);

            sincronizador.ListaDeGruposSincroniaPay.Add(Gs);
            return sincronizador;
        }
    }
}
