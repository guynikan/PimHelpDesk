using System;

namespace UNIP.PIM.HelpDesk.DTO.Grupo
{
	public class Grupo
	{
		public int IdGrupo { get; set; }
		public string Codigo { get; set; }
		public string Descricao { get; set; }
		public bool Ativo { get; set; }
		public decimal HorarioInicio { get; set; }
		public decimal HorarioFim { get; set; }
		public bool DomingoDiaUtil { get; set; }
		public bool SegundaDiaUtil { get; set; }
		public bool TercaDiaUtil { get; set; }
		public bool QuartaDiaUtil { get; set; }
		public bool QuintaDiaUtil { get; set; }
		public bool SextaDiaUtil { get; set; }
		public bool SabadoDiaUtil { get; set; }
        public bool Selecionado { get; set; }
    }
}