using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Domain
{
    public class ContatoDTO
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public MensagemDTO Mensagens { get; set; }
    }
}