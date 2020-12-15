namespace App.Domain.Desctop
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