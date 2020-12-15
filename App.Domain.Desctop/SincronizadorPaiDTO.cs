using System.Collections.Generic;

namespace App.Domain.Desctop
{
    public class SincronizadorPaiDTO
    {
        public int Id { get; set; }
        public List<int> Grupo { get; set; } = new List<int>();
        public int MaxSincronia { get; set; }
    }
}
