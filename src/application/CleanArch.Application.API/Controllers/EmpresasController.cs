using CleanArch.Core.Domain.Collections.Empresa;
using CleanArch.Core.Domain.Dto.Empresa;
using CleanArch.Core.Domain.Interfaces.Repositories;
using CleanArch.Core.Services.Request.Empresa;
using CleanArch.Core.Services.Response.Empresa;
using CleanArch.Core.Services.UseCases.Empresa.Cadastrar;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Application.API.Controllers
{
    /// <summary>
    /// Gerenciar entidade empresa
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        /// <summary>
        /// Lista empresa com endereço pelo seu identificador
        /// </summary>
        /// <param name="empresaRepository"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmpresaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromServices] IEmpresaRepository empresaRepository,
             int id)
        {
            return Ok(await empresaRepository.GetOne(id));
        }

        /// <summary>
        /// Listar Empresas com endereço
        /// </summary>
        /// <param name="empresaRepository"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(EmpresasCollection), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromServices] IEmpresaRepository empresaRepository)
        {
            var empresas = await empresaRepository.GetAllAsync();

            return Ok(new EmpresasCollection(empresas));
        }

        /// <summary>
        /// Cadastrar empresa com endereço
        /// </summary>
        /// <param name="empresaCadastrar"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(EmpresaCadastrarResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromServices] IEmpresaCadastrarUseCase empresaCadastrar,
            [FromBody] EmpresaCadastroRequest request)
        {
            return Ok(await empresaCadastrar.ExecuteAsync(request));
        }
    }
}
