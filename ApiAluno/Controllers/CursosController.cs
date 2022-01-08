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
    public class CursosController : ControllerBase
    {
        private readonly CursosContext _context;

        public CursosController(CursosContext context)
        {
            _context = context;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cursos>>> GetCurso()
        {
            return await _context.Curso.ToListAsync();
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cursos>> GetCursos(long id)
        {
            var cursos = await _context.Curso.FindAsync(id);

            if (cursos == null)
            {
                return NotFound();
            }

            return cursos;
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursos(long id, Cursos cursos)
        {
            if (id != cursos.Id)
            {
                return BadRequest();
            }

            _context.Entry(cursos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursosExists(id))
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

        // POST: api/Cursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cursos>> PostCursos(Cursos cursos)
        {
            if (_context.Curso.Any(e => e.CursoNOME == cursos.CursoNOME))
                return BadRequest("Curso já cadastrado");
            else
            {
                _context.Curso.Add(cursos);
                await _context.SaveChangesAsync();

                CreatedAtAction(nameof(GetCursos), new { id = cursos.Id }, cursos);
                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject("Cadastro concluído"));
            }
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCursos(long id)
        {
            var cursos = await _context.Curso.FindAsync(id);
            if (cursos == null)
            {
                return NotFound();
            }

            _context.Curso.Remove(cursos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CursosExists(long id)
        {
            return _context.Curso.Any(e => e.Id == id);
        }
    }
}
