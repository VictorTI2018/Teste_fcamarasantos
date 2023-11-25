namespace CleanArch.Core.Domain.Entities.Aggregates
{
    public class EnderecoEntity : BaseEntity
    {
        public string Endereco { get; private set; }

        public string Bairro { get; private set; }

        public string Numero { get; private set; }

        public string Cidade { get; private set; }

        public string UF { get; private set; }

        public int EmpresaId { get; private set; }

        public virtual EmpresaEntity Empresa { get; set; }

        public EnderecoEntity() { }

        public EnderecoEntity(string endereco,
            string bairro,
            string numero,
            string cidade,
            string uf)
        {
            Endereco = endereco;
            Bairro = bairro;
            Numero = numero;
            Cidade = cidade;
            UF = uf;
        }
    }
}
