using System;
using System.Collections.Generic;

namespace Database_First.Models
{
    public partial class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Email { get; set; }
        public int? Status { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual Estagiario? Estagiario { get; set; }
        public virtual Fornecedore? Fornecedore { get; set; }
        public virtual Funcionario? Funcionario { get; set; }
    }
}
