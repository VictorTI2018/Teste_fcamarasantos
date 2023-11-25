using CleanArch.Core.Services.Request.Empresa;
using CleanArch.Core.Services.Validation.Empresa;

namespace CleanArch.Test.Validator.Empresa
{
    public class EmpresaCadastrarValidatorTest
    {
        [Fact]
        public void Return_Error_Name_Empty()
        {
            var request = new EmpresaCadastroRequest
            {
                Nome = string.Empty,
                CNPJ = "24.525.954/0001-86",
                Telefone = "(17) 99999-9999",
                QuantidadeVagasCarros = 50,
                QuantidadeVagasMotos = 100,
                Endereco = new EmpresaEnderecoRequest
                {
                    Endereco = "TESTE",
                    Numero = "212",
                    Bairro = "TESTE",
                    Cidade = "TESTE",
                    UF = "TS"
                }
            };

            var validator = new EmpresaCadastrarValidator();
            var result = validator.Validate(request);

            Assert.False(result.IsValid);
        }
    }
}
