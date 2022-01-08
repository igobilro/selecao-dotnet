using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAluno.Models;
using ApiAluno.Context;

namespace ApiAluno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaosController : ControllerBase
    {
        private readonly CartaoContext _context;

        public CartaosController(CartaoContext context)
        {
            _context = context;
        }

        // GET: api/Cartaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cartao>>> GetAlunoCartao()
        {
            return await _context.AlunoCartao.ToListAsync();
        }

        // GET: api/Cartaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cartao>> GetCartao(long id)
        {
            var cartao = await _context.AlunoCartao.FindAsync(id);

            if (cartao == null)
            {
                return NotFound();
            }

            return cartao;
        }

        // PUT: api/Cartaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartao(long id, Cartao cartao)
        {
            if (id != cartao.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cartaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cartao>> PostCartao(Cartao cartao)
        {
            _context.AlunoCartao.Add(cartao);
            await _context.SaveChangesAsync();
            

            CreatedAtAction(nameof(GetCartao), new { id = cartao.Id }, cartao);
            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject("Cadastro concluído"));
        }

        // DELETE: api/Cartaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartao(long id)
        {
            var cartao = await _context.AlunoCartao.FindAsync(id);
            if (cartao == null)
            {
                return NotFound();
            }

            _context.AlunoCartao.Remove(cartao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartaoExists(long id)
        {
            return _context.AlunoCartao.Any(e => e.Id == id);
        }
    }
}
