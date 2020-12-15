using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Domain
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public List<ContatoDTO> Contatos { get; set; } = new List<ContatoDTO>();
    }
}