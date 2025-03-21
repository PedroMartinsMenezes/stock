using Microsoft.AspNetCore.Mvc;
using Stock.Interfaces;
using Stock.Model.Dto;
using Stock.Model.Entity;
using System.Threading.Tasks;

namespace Stock.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacaoController(IMovimentacaoDomain domain) : ControllerBase
    {
        private readonly IMovimentacaoDomain _domain = domain;

        [HttpGet("List")]
        public async Task<ActionResult> List()
        {
            return Ok(await _domain.List());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _domain.GetById(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateMovimentacaoRequest request)
        {
            return Ok(await _domain.Create(request));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(Movimentacao entity)
        {
            return await _domain.Update(entity) == 1 ? Ok() : NotFound();
        }

        [HttpGet("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _domain.Delete(id) == 1 ? Ok() : NotFound();
        }
    }
}
