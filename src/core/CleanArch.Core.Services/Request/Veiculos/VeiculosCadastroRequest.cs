namespace CleanArch.Core.Services.Request.Veiculos
{
    public class VeiculosCadastroRequest
    {
        public int EmpresaId { get; set; }

        public string Marca { get;  set; }

        public string Modelo { get;  set; }

        public string Cor { get;  set; }

        public string Placa { get;  set; }

        public int Tipo { get;  set; }

        public bool Entrada { get; set; }
    }
}
