using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp8.Models
{
    public class Pedido
    {
        public List<Producto> Productos { get; set; } = new();

        public decimal Total { get; set; }
    }
}
