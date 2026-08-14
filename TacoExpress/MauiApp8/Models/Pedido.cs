namespace MauiApp8.Models
{
    public class Pedido
    {
        public string NumeroPedido { get; set; } = string.Empty;

        public List<Producto> Productos { get; set; } = new();

        public decimal Total { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}