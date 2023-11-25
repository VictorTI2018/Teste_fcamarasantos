using CleanArch.Core.Domain.Entities;
using CleanArch.Core.Domain.Entities.Aggregates;

namespace CleanArch.Core.Services.Request.Empresa
{
    public class EmpresaCadastroRequest
    {
        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Telefone { get; set; }

        public int QuantidadeVagasMotos { get; set; }

        public int QuantidadeVagasCarros { get; set; }

        public EmpresaEnderecoRequest Endereco { get; set; }

        public static EmpresaEntity AdapterEmpresaCadastroRequestToEmpresaEntity(EmpresaCadastroRequest request)
        {
            return new EmpresaEntity(request.Nome, request.CNPJ,
                    request.Telefone, request.QuantidadeVagasMotos, request.QuantidadeVagasCarros,
                    new EnderecoEntity(request.Endereco.Endereco,
                    request.Endereco.Bairro, request.Endereco.Numero,
                    request.Endereco.Cidade, request.Endereco.UF));
        }
    }

    public class EmpresaEnderecoRequest
    {
        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Numero { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }
    }
}
