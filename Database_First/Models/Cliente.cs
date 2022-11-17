using System;
using System.Collections.Generic;

namespace Database_First.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public decimal Renda { get; set; }
        public decimal? Credito { get; set; }

        public virtual Pessoa IdNavigation { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
