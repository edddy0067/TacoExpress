using MauiApp8.Models;
using System.Collections.ObjectModel;

namespace MauiApp8.Services
{
    public class CarritoService
    {
        private static readonly CarritoService _instance = new();

        public static CarritoService Instance => _instance;

        public ObservableCollection<Producto> Productos { get; } = new();

        private CarritoService()
        {
        }

        public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
        }

        public void EliminarProducto(Producto producto)
        {
            Productos.Remove(producto);
        }

        public void VaciarCarrito()
        {
            Productos.Clear();
        }

        public decimal ObtenerTotal()
        {
            return Productos.Sum(p => p.Precio);
        }
    }
}