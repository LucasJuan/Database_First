using System;
using System.Collections.Generic;

namespace Database_First.Models
{
    public partial class Estagiario
    {
        public Estagiario()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public decimal Bolsa { get; set; }
        public int? Status { get; set; }

        public virtual Pessoa IdNavigation { get; set; } = null!;
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
