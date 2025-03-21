using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock.Server.Data;
using Stock.Server.Models;

namespace Stock.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly StockServerContext _context;

        public ProdutoController(StockServerContext context)
        {
            _context = context;
        }

        [HttpGet("GetProdutos")]
        public async Task<ActionResult> Index()
        {
            return Ok(await _context.Produto.ToListAsync());
        }

        [HttpGet("GetProdutoById")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Produto = await _context.Produto.FirstOrDefaultAsync(m => m.Id == id);
            if (Produto == null)
            {
                return NotFound();
            }
            return Ok(Produto);
        }

        [HttpGet("CreateProduto")]
        public async Task<IActionResult> Create([FromQuery] Produto entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return Ok(entity);
        }

        [HttpGet("EditProduto")]
        public async Task<IActionResult> Edit([FromQuery] Produto entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Produto.Any(e => e.Id == entity.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(entity);
        }

        [HttpGet("DeleteProduto")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Produto = await _context.Produto.FindAsync(id);
            if (Produto != null)
            {
                _context.Produto.Remove(Produto);
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
