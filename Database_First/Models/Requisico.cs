using System;
using System.Collections.Generic;

namespace Database_First.Models
{
    public partial class Requisico
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int? Status { get; set; }
    }
}
