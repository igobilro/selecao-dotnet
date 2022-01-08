using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAluno.Models;
using ApiAluno.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using ApiAluno.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ApiAluno.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AlunosContext _context;

        public AlunosController(AlunosContext context)
        {
            _context = context;

        }

        // GET: api/Alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alunos>>> GetAluno()
        {
            return await _context.Aluno.ToListAsync();
        }

        // GET: api/Alunos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alunos>> GetAlunos(long id)
        {
            var alunos = await _context.Aluno.FindAsync(id);

            if (alunos == null)
            {
                return NotFound();
            }

            return alunos;
        }

        // PUT: api/Alunos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlunos(long id, Alunos alunos)
        {
            if (id != alunos.Id)
            {
                return BadRequest();
            }

            _context.Entry(alunos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunosExists(id))
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

        // POST: api/Alunos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alunos>> PostAlunos(Alunos alunos)
        {
            if (_context.Aluno.Any(e => e.Email == alunos.Email))
                return BadRequest("E-mail já cadastrado");
            else
            {
                _context.Aluno.Add(alunos);
                await _context.SaveChangesAsync();

                CreatedAtAction(nameof(GetAlunos), new { id = alunos.Id }, alunos);
                return Ok(Newtonsoft.Json.JsonConvert.SerializeObject("Cadastro concluído"));
            }
        }

        // DELETE: api/Alunos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlunos(long id)
        {
            var alunos = await _context.Aluno.FindAsync(id);
            if (alunos == null)
            {
                return NotFound();
            }

            _context.Aluno.Remove(alunos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlunosExists(long id)
        {
            return _context.Aluno.Any(e => e.Id == id);
        }
    }
}
