using CleanArch.Core.Domain.Entities.Aggregates;

namespace CleanArch.Core.Domain.Entities
{
    public class EmpresaEntity : AudityEntity
    {
        public string Nome { get; private set; }

        public string CNPJ { get; private set; }

        public string Telefone { get; private set; }

        public int QuantidadeVagasMotos { get; private set; }

        public int QuantidadeVagasCarros { get; private set; }

        public virtual EnderecoEntity Endereco { get; set; }

        public EmpresaEntity() { }

        public EmpresaEntity(string nome,
            string cnpj,
            string telefone,
            int quantidadeVagasMotos,
            int quantidadeVagasCarros,
            EnderecoEntity endereco)
        {
            Nome = nome;
            CNPJ = cnpj;
            Telefone = telefone;
            QuantidadeVagasCarros = quantidadeVagasCarros;
            QuantidadeVagasMotos = quantidadeVagasMotos;
            Endereco = endereco;
        }
    }
}
