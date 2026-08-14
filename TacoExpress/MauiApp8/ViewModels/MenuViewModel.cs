using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp8.Models;
using MauiApp8.Services;
using System.Collections.ObjectModel;

namespace MauiApp8.ViewModels
{
    public partial class MenuViewModel : ObservableObject
    {
        public ObservableCollection<Producto> Productos { get; }

        private readonly CarritoService _carritoService;

        public MenuViewModel()
        {
            _carritoService = CarritoService.Instance;

            Productos = new ObservableCollection<Producto>
            {
                new Producto
                {
                    Id = 1,
                    Nombre = "Taco de Bistec",
                    Descripcion = "Bistec con cebolla y cilantro",
                    Precio = 35.00m
                },

                new Producto
                {
                    Id = 2,
                    Nombre = "Taco al Pastor",
                    Descripcion = "Pastor con piña, cebolla y cilantro",
                    Precio = 30.00m
                },

                new Producto
                {
                    Id = 3,
                    Nombre = "Taco de Barbacoa",
                    Descripcion = "Barbacoa con cebolla y cilantro",
                    Precio = 40.00m
                },

                new Producto
                {
                    Id = 4,
                    Nombre = "Gringa",
                    Descripcion = "Tortilla de harina con pastor y queso",
                    Precio = 65.00m
                },

                new Producto
                {
                    Id = 5,
                    Nombre = "Refresco",
                    Descripcion = "Refresco de 355 ml",
                    Precio = 25.00m
                }
            };
        }

        [RelayCommand]
        private async Task AgregarAlCarrito(Producto producto)
        {
            if (producto == null)
                return;

            _carritoService.AgregarProducto(producto);

            await Shell.Current.DisplayAlert(
                "Producto agregado",
                $"{producto.Nombre} se agregó al carrito.",
                "Aceptar");
        }
    }
}