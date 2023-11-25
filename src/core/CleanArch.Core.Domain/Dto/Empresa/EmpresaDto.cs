using CleanArch.Core.Domain.Entities;

namespace CleanArch.Core.Domain.Dto.Empresa
{
    public class EmpresaDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Telefone { get; set; }

        public int QuantidadeVagasMotos { get; set; }

        public int QuantidadeVagasCarros { get; set; }

        public EmpresaEnderecoDto Endereco { get; set; }

        public static EmpresaDto AdapterEmpresaEntityToEmpresaDto(EmpresaEntity empresa)
        {
            return new EmpresaDto
            {
                Id = empresa.Id,
                Nome = empresa.Nome,
                CNPJ = empresa.CNPJ,
                Telefone = empresa.Telefone,
                QuantidadeVagasCarros = empresa.QuantidadeVagasCarros,
                QuantidadeVagasMotos = empresa.QuantidadeVagasMotos,
                Endereco = new EmpresaEnderecoDto
                {
                    Id = empresa.Endereco.Id,
                    Endereco = empresa.Endereco.Endereco,
                    Bairro = empresa.Endereco.Bairro,
                    Numero = empresa.Endereco.Numero,
                    Cidade = empresa.Endereco.Cidade,
                    UF = empresa.Endereco.UF
                }
            };
        }
    }

    public class EmpresaEnderecoDto
    {
        public int Id { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Numero { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public int EmpresaId { get; set; }
    }
}
