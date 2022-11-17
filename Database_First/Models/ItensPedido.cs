using System;
using System.Collections.Generic;

namespace Database_First.Models
{
    public partial class ItensPedido
    {
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int QtdVendida { get; set; }
        public decimal PrecoVendido { get; set; }

        public virtual Pedido Pedido { get; set; } = null!;
        public virtual Produto Produto { get; set; } = null!;
    }
}
