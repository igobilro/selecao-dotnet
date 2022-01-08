using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiAluno.Models
{
    public class Token
    {
        public long Id { get; set; }
        [Required]
        public long User_ID { get; set; }
        [Required]
        public string User_Token { get; set; }
    }
}
