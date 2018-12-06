using System;
using System.Collections.Generic;

namespace UNIP.PIM.HelpDesk.DTO.Chamado
{
	public class Chamado
	{
        public Chamado()
        {
            Ocorrencias = new List<Ocorrencia>();
        }
		public long IdChamado { get; set; }
		public string Titulo { get; set; }
		public DateTime DataAbertura { get; set; }
		public DateTime? DataConclusaoPrevista { get; set; }
		public DateTime? DataFechamento { get; set; }
		public int IdStatus { get; set; }
		public int IdSolicitacao { get; set; }
        public int IdCliente { get; set; }
        public int? IdGrupo { get; set; }
        public long IdUsuarioAbertura { get; set; }
		public long IdTecnico { get; set; }
		public string Tecnico { get; set; }
        public string UsuarioSolicitante { get; set; }
        public string Status { get; set; }
		public string Grupo { get; set; }
        public bool UsuarioTecnico { get; set; }
        public string Solicitacao { get; set; }
        public List<Ocorrencia> Ocorrencias { get; set; }
    }
}