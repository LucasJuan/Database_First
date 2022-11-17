using System;
using System.Collections.Generic;

namespace Database_First.Models
{
    public partial class Produto
    {
        public Produto()
        {
            ItensPedidos = new HashSet<ItensPedido>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; } = null!;
        public decimal? Preco { get; set; }
        public int? Estoque { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; } = null!;
        public virtual ICollection<ItensPedido> ItensPedidos { get; set; }
    }
}
