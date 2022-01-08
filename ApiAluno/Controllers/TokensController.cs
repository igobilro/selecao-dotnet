using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAluno.Models;
using ApiAluno.Context;
using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiAluno.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly TokensContext _context;
        private readonly AlunosContext _context_alunos;
        private readonly IConfiguration _configuration;

        public TokensController(IConfiguration configuration, TokensContext tokenContext, AlunosContext alunosContext)
        {
            _context = tokenContext;
            _configuration = configuration;
            _context_alunos = alunosContext;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Token>> Login(Login login)
        {
            if (!_context_alunos.Aluno.Any(a => a.Email == login.Email))
                return BadRequest("Usuário ou senha errados");

            var aluno_escolhido = await _context_alunos.Aluno.Where(a => a.Email == login.Email).ToListAsync();

            Alunos alunos = aluno_escolhido[0];

            if (alunos.Password != login.Password)
                return BadRequest("Usuário ou senha errados");

            Token token = BuildToken(alunos);

            _context.Tokens.Add(token);

            return Ok(Newtonsoft.Json.JsonConvert.SerializeObject(token));


        }

        private Token BuildToken(Alunos alunos)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, alunos.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // tempo de expiração do token: 1 hora
            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new Token
            {

                User_Token = new JwtSecurityTokenHandler().WriteToken(token),
                User_ID = alunos.Id

            };
        }
    }

}
