﻿using Microsoft.AspNetCore.Mvc;
using Stock.Interfaces;
using Stock.Model.Dto;
using System.Threading.Tasks;

namespace Stock.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController(IProdutoDomain domain) : ControllerBase
    {
        private readonly IProdutoDomain _domain = domain;

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
        public async Task<IActionResult> Create(ProdutoRequest entity)
        {
            return Ok(await _domain.Create(entity));
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(ProdutoRequest entity)
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
