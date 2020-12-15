using App.Domain.Desctop.Enums;
using System;
using System.Collections.Generic;

namespace App.Domain.Desctop
{
    public class SincronizadorDTO
    {
        //Cabeçalho da sincronia
        public Status StatusSincroniaMensagem { get; set; }
        public Status StatusGrupoSincronia { get; set; }
        //public int MaxSincMensagem { get; set; }


        //public int? MaxSincUsuario { get; set; }
        //public int? MaxSincContatos { get; set; }

        //Corpo da Sincronia
        public List<MensagemDTO> ListaMensagem { get; set; } = new List<MensagemDTO>();
        public List<UsuarioDTO> ListaUsuarios { get; set; } = new List<UsuarioDTO>();
        public List<ContatoDTO> ListaContatos { get; set; } = new List<ContatoDTO>();
        public List<GrupoSincronizadoresPaiDTO> ListaDeGruposSincroniaPay { get; set; } = new List<GrupoSincronizadoresPaiDTO>();
    }
}
