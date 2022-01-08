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
    public class RegistroesController : ControllerBase
    {
        private readonly RegistroContext _context;

        public RegistroesController(RegistroContext context)
        {
            _context = context;
        }

        // GET: api/Registroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registro>>> GetMatricula()
        {
            return await _context.Matricula.ToListAsync();
        }

        // GET: api/Registroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Registro>> GetRegistro(long id)
        {
            var registro = await _context.Matricula.FindAsync(id);

            if (registro == null)
            {
                return NotFound();
            }

            return registro;
        }

        // PUT: api/Registroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistro(long id, Registro registro)
        {
            if (id != registro.Id)
            {
                return BadRequest();
            }

            _context.Entry(registro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroExists(id))
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

        // POST: api/Registroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Registro>> PostRegistro(Registro registro)
        {
            _context.Matricula.Add(registro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRegistro), new { id = registro.Id }, registro);
        }

        // DELETE: api/Registroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistro(long id)
        {
            var registro = await _context.Matricula.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }

            _context.Matricula.Remove(registro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistroExists(long id)
        {
            return _context.Matricula.Any(e => e.Id == id);
        }
    }
}
