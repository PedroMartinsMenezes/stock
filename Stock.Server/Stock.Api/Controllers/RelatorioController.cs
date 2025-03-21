using Microsoft.AspNetCore.Mvc;
using Stock.Model.Dto;
using System;
using System.Threading.Tasks;

namespace Stock.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {
        public RelatorioController()
        {
        }

        [HttpGet("GetEstoque")]
        public async Task<IActionResult> GetEstoque(DateTime dia, string codigoProduto)
        {
            return Ok(await Task.FromResult(new RelatorioResponse()));
        }
    }
}
