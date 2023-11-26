namespace CleanArch.Core.Domain.Entities
{
    public class VeiculosEntity : AudityEntity
    {
        public int EmpresaId { get; set; }
        public string Marca { get; private set; }

        public string Modelo { get; private set; }

        public string Cor { get; private set; }

        public string Placa { get; private set; }

        public int Tipo { get; private set; }

        public virtual EmpresaEntity Empresa { get; set; }

        public VeiculosEntity() { }

        public VeiculosEntity(string marca,
            string modelo,
            string cor,
            string placa,
            int tipo,
            int empresaId)
        {
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
            Placa = placa;
            Tipo = tipo;
            EmpresaId = empresaId;
        }
    }
}
