using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Pessoa : BaseEntity
    {
        public string Nome { get; set; }
        public DateTime Dt_Nascimento { get; set; }
        public string CPF { get; set; }
    }
}
