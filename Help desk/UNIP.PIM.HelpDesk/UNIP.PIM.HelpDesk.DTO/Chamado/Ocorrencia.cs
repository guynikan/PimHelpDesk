using System;

namespace UNIP.PIM.HelpDesk.DTO.Chamado
{
    public class Ocorrencia
    {
        public int IdOcorrencia { get; set; }
        public long IdChamado { get; set; }
        public DateTime DataAlteracao { get; set; }
        public long IdUsuarioAlteracao { get; set; }
        public string Usuario { get; set; }
        public string Descricao { get; set; }
    }
}
