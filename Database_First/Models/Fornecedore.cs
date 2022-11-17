using System;
using System.Collections.Generic;

namespace Database_First.Models
{
    public partial class Fornecedore
    {
        public int Id { get; set; }
        public string Cnpj { get; set; } = null!;

        public virtual Pessoa IdNavigation { get; set; } = null!;
    }
}
