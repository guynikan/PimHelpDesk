namespace UNIP.PIM.HelpDesk.DTO.Cliente
{
	public class Cliente
	{
        public int IdCliente { get; set; }
		public string NomeFantasia { get; set; }
		public string CNPJ { get; set; }
		public string CPF { get; set; }
		public string RazaoSocial { get; set; }
		public bool Ativo { get; set; }
		public string Email { get; set; }
		public string Cidade { get; set; }
		public string UF { get; set; }
		public string Numero { get; set; }
		public string Complemento { get; set; }
		public string Endereco { get; set; }
		public string Bairro { get; set; }
		public string Cep { get; set; }
        public string DescricaoAtivo => Ativo ? "Sim" : "Não";
    }
}