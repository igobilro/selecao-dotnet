using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAluno.Models
{
    public class Registro
    {
        public long Id { get; set; }
        [Required]
        public long AlunosID { get; set; }
        [Required]
        public long CursosID { get; set; }
    }
}
