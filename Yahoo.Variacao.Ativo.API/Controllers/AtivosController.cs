using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Yahoo.Variacao.Ativo.Aplicacao;

namespace Yahoo.Variacao.Ativo.API
{
    [Route("api/ativos")]
    [ApiController]
    public class AtivosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(string nomeAtivo, [FromServices] IObterVariacoesAtivosUltimoMesUseCase useCase)
        {
            if (string.IsNullOrEmpty(nomeAtivo))
                return BadRequest();

            var lstAtivos = await useCase.Executar(nomeAtivo);

            if (lstAtivos == null || !lstAtivos.Any())
                return NoContent();

            return Ok(lstAtivos);
        }
    }
}
