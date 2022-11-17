using System;
using System.Collections.Generic;

namespace Database_First.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            ItensPedidos = new HashSet<ItensPedido>();
        }

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal? Total { get; set; }
        public int? Status { get; set; }
        public int ClienteId { get; set; }
        public int FunRegId { get; set; }
        public int? FunRecId { get; set; }
        public int? EstagiarioId { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
        public virtual Estagiario? Estagiario { get; set; }
        public virtual Funcionario? FunRec { get; set; }
        public virtual Funcionario FunReg { get; set; } = null!;
        public virtual ICollection<ItensPedido> ItensPedidos { get; set; }
    }
}
