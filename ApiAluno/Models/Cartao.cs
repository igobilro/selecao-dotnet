using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAluno.Models
{
    public class Cartao
    {
        public long Id { get; set; }
        [Required]
        public long AlunoID { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(16)")]
        public string NumCartao { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(3)")]
        public long CDV { get; set; }
    }
}
