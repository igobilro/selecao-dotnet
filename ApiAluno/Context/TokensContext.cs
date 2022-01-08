using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiAluno.Models
{
    public class TokensContext : DbContext
    {
        public TokensContext(DbContextOptions<TokensContext> options)
: base(options)
        {
        }

        public DbSet<Token> Tokens { get; set; }
    }
}