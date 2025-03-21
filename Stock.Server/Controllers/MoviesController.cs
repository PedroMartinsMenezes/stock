using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using Stock.Server.Data;

namespace Stock.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly StockServerContext _context;

        public MoviesController(StockServerContext context)
        {
            _context = context;
        }

        [HttpGet("GetMovies")]
        public async Task<ActionResult> Index()
        {
            return Ok(await _context.Movie.ToListAsync());
        }

        [HttpGet("GetMovieById")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet("CreateMovie")]
        public async Task<IActionResult> Create([FromQuery] Movie movie)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return Ok(movie);
        }

        [HttpGet("EditMovie")]
        public async Task<IActionResult> Edit([FromQuery] Movie movie)
        {
            try
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Movie.Any(e => e.Id == movie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(movie);
        }

        [HttpGet("DeleteMovie")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie != null)
            {
                _context.Movie.Remove(movie);
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
