using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ApiAluno.Models
{
    public class CartaoContext : DbContext
    {
        public CartaoContext(DbContextOptions<CartaoContext> options)
            : base(options)
        {
        }

        public DbSet<Cartao> AlunoCartao { get; set; }
    }
}
