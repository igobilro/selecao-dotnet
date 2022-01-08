using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAluno.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiAluno.Context
{
    public class ApplicationDbContext: IdentityDbContext <ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
