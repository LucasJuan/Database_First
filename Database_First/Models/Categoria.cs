using System;
using System.Collections.Generic;

namespace Database_First.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Produtos = new HashSet<Produto>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; } = null!;
        public int? Status { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
