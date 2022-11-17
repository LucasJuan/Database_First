using System;
using System.Collections.Generic;

namespace Database_First.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            PedidoFunRecs = new HashSet<Pedido>();
            PedidoFunRegs = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public decimal Salario { get; set; }
        public string Cpf { get; set; } = null!;

        public virtual Pessoa IdNavigation { get; set; } = null!;
        public virtual ICollection<Pedido> PedidoFunRecs { get; set; }
        public virtual ICollection<Pedido> PedidoFunRegs { get; set; }
    }
}
