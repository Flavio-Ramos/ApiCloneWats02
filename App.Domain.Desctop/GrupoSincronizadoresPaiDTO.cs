using System.Collections.Generic;

namespace App.Domain.Desctop
{
    public class GrupoSincronizadoresPaiDTO
    {
        public int IdGrupo { get; set; }
        public List<PaiSincronia> SincroniasPai { get; set; } = new List<PaiSincronia>();

    }
}
