using MauiApp8.Models;
using MauiApp8.Services;

namespace TacoExpress.Tests
{
    public class CarritoServiceTests
    {
        private readonly CarritoService _carritoService;

        public CarritoServiceTests()
        {
            _carritoService = CarritoService.Instance;
            _carritoService.VaciarCarrito();
        }

        [Fact]
        public void AgregarProducto_DebeAgregarProductoAlCarrito()
        {
            var producto = new Producto
            {
                Id = 1,
                Nombre = "Taco de Bistec",
                Precio = 35.00m
            };

            _carritoService.AgregarProducto(producto);

            Assert.Single(_carritoService.Productos);
            Assert.Equal("Taco de Bistec",
                _carritoService.Productos[0].Nombre);
        }

        [Fact]
        public void ObtenerTotal_DebeCalcularTotalCorrectamente()
        {
            var producto1 = new Producto
            {
                Id = 1,
                Nombre = "Taco de Bistec",
                Precio = 35.00m
            };

            var producto2 = new Producto
            {
                Id = 2,
                Nombre = "Taco al Pastor",
                Precio = 30.00m
            };

            _carritoService.AgregarProducto(producto1);
            _carritoService.AgregarProducto(producto2);

            decimal total = _carritoService.ObtenerTotal();

            Assert.Equal(65.00m, total);
        }

        [Fact]
        public void EliminarProducto_DebeEliminarProductoDelCarrito()
        {
            var producto = new Producto
            {
                Id = 1,
                Nombre = "Taco de Bistec",
                Precio = 35.00m
            };

            _carritoService.AgregarProducto(producto);

            _carritoService.EliminarProducto(producto);

            Assert.Empty(_carritoService.Productos);
        }

        [Fact]
        public void VaciarCarrito_DebeEliminarTodosLosProductos()
        {
            _carritoService.AgregarProducto(new Producto
            {
                Id = 1,
                Nombre = "Taco de Bistec",
                Precio = 35.00m
            });

            _carritoService.AgregarProducto(new Producto
            {
                Id = 2,
                Nombre = "Taco al Pastor",
                Precio = 30.00m
            });

            _carritoService.VaciarCarrito();

            Assert.Empty(_carritoService.Productos);
            Assert.Equal(0m, _carritoService.ObtenerTotal());
        }
    }
}