using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiAluno.Models
{
    public class Cursos
    {
        public long Id { get; set; }
        [Required]
        public string CursoNOME { get; set; }
        [Required]
        public long ValorCurso { get; set; }
    }
}
