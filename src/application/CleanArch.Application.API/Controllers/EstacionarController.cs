using CleanArch.Core.Services.Request.Veiculos;
using CleanArch.Core.Services.Response.Veiculos;
using CleanArch.Core.Services.UseCases.Veiculos.Cadastrar;
using CleanArch.Infra.RedisCache;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Application.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EstacionarController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="request"></param>
        /// <returns></returns>        
        [HttpPost("estacionar")]
        [ProducesResponseType(typeof(VeiculosCadastrarResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(
            [FromServices] CachingHelper cache,
            [FromBody] VeiculosCadastroRequest request)
        {

            var key = $"Estacionamento-{request.EmpresaId}";

            var record = await cache.GetRecordAsync<List<VeiculosCadastroRequest>>(key);

            if (record is null)
                await cache.SetRecordAsync(key, new List<VeiculosCadastroRequest> { request });
            else
            {
                var veiculoEstacionado = record.FirstOrDefault(r => r.Placa == request.Placa && r.Entrada == true);

                if (veiculoEstacionado is null)
                    await cache.SetRecordAsync(key, record);
                else
                {
                    if (request.Entrada)
                        return BadRequest("Veiculos já estacionado!");
                    else
                        veiculoEstacionado.Entrada = false;

                    await cache.RemoveRecordAsync(key);
                    await cache.SetRecordAsync(key, record);
                }

            }

            return Ok();
        }
    }
}
