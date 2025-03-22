using Microsoft.AspNetCore.Mvc;
using Stock.Interfaces;
using System;
using System.Threading.Tasks;

namespace Stock.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly IMovimentacaoDomain _movimentacaoDomain;

        public RelatorioController(IMovimentacaoDomain movimentacaoDomain)
        {
            _movimentacaoDomain = movimentacaoDomain;
        }

        [HttpGet("GetEstoque")]
        public async Task<IActionResult> GetEstoque(DateTime dia, string codigoProduto)
        {
            return Ok(await _movimentacaoDomain.GetEstoque(dia, codigoProduto));
        }
    }
}
