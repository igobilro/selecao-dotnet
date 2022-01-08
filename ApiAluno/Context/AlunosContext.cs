using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiAluno.Models
{
    public class AlunosContext : DbContext
    {
        public AlunosContext(DbContextOptions<AlunosContext> options)
            : base(options)
        {
        }

        public DbSet<Alunos> Aluno { get; set; }
    }
}
