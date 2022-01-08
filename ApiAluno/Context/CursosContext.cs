using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ApiAluno.Models
{
    public class CursosContext : DbContext
    {
        public CursosContext(DbContextOptions<CursosContext> options)
    : base(options)
        {
        }

        public DbSet<Cursos> Curso { get; set; }
    }
}
