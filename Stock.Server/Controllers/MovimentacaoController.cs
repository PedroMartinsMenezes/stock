using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock.Server.Data;
using Stock.Server.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentacaoController : ControllerBase
    {
        private readonly StockServerContext _context;

        public MovimentacaoController(StockServerContext context)
        {
            _context = context;
        }

        [HttpGet("GetMovimentacoes")]
        public async Task<ActionResult> Index()
        {
            return Ok(await _context.Movimentacao.ToListAsync());
        }

        [HttpGet("GetMovimentacaoById")]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Movimentacao = await _context.Movimentacao.FirstOrDefaultAsync(m => m.Id == id);
            if (Movimentacao == null)
            {
                return NotFound();
            }
            return Ok(Movimentacao);
        }

        [HttpPost("CreateMovimentacao")]
        public async Task<IActionResult> Create(string codigoProduto, TipoMovimentacao tipoMovimentacao, int quantidade)
        {
            if (tipoMovimentacao != TipoMovimentacao.Entrada && tipoMovimentacao != TipoMovimentacao.Saida)
            {
                return Ok("Tipo de movimentação inválido");
            }
            Produto produto = await _context.Produto.FirstOrDefaultAsync(p => p.Codigo == codigoProduto);
            if (produto == null)
            {
                return Ok("Produto não encontrado");
            }
            Movimentacao movimentacao = new() { Quantidade = quantidade, Tipo = tipoMovimentacao, Produto = produto };
            _context.Add(movimentacao);
            await _context.SaveChangesAsync();
            return Ok(movimentacao);
        }

        [HttpPost("EditMovimentacao")]
        public async Task<IActionResult> Edit(Movimentacao Movimentacao)
        {
            try
            {
                _context.Update(Movimentacao);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Movimentacao.Any(e => e.Id == Movimentacao.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(Movimentacao);
        }

        [HttpGet("DeleteMovimentacao")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Movimentacao = await _context.Movimentacao.FindAsync(id);
            if (Movimentacao != null)
            {
                _context.Movimentacao.Remove(Movimentacao);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
