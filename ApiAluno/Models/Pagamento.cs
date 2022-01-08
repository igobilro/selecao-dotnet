using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiAluno.Models
{
    public class Pagamento
    {
        public long Id { get; set; }
        [Required]
        public long AlunoID { get; set; }
        [Required]
        public long CartaoID { get; set; }
        public string ValorPGMT { get; set; }
        public long DataPGMT { get; set; }

    }
}
