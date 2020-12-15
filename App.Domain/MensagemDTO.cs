using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Domain
{
    public class MensagemDTO
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public int Grupo { get; set; }
        public int PaiMensagem { get; set; }
        public int PaiSyncronia { get; set; }
        public int ContSyncronia { get; set; }
    }
}