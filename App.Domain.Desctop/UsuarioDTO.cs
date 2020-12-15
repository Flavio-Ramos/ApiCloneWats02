using System.Collections.Generic;

namespace App.Domain.Desctop
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public List<ContatoDTO> Contatos { get; set; } = new List<ContatoDTO>();
    }
}
