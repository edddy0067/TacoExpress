using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp8.Models;
using MauiApp8.Services;
using System.Collections.ObjectModel;

namespace MauiApp8.ViewModels
{
    public partial class CarritoViewModel : ObservableObject
    {
        private readonly CarritoService _carritoService;

        private decimal _total;

        public ObservableCollection<Producto> Productos =>
            _carritoService.Productos;

        public decimal Total
        {
            get => _total;
            set => SetProperty(ref _total, value);
        }

        public IRelayCommand<Producto> EliminarProductoCommand { get; }

        public IAsyncRelayCommand IrAPedidoCommand { get; }

        public CarritoViewModel()
        {
            _carritoService = CarritoService.Instance;

            EliminarProductoCommand =
                new RelayCommand<Producto>(EliminarProducto);

            IrAPedidoCommand =
                new AsyncRelayCommand(IrAPedido);

            ActualizarTotal();
        }

        public void ActualizarTotal()
        {
            Total = _carritoService.ObtenerTotal();
        }

        private void EliminarProducto(Producto producto)
        {
            if (producto == null)
                return;

            _carritoService.EliminarProducto(producto);

            ActualizarTotal();
        }

        private async Task IrAPedido()
        {
            if (Productos.Count == 0)
            {
                await Shell.Current.DisplayAlert(
                    "Carrito vacío",
                    "Agrega al menos un producto antes de continuar.",
                    "Aceptar");

                return;
            }

            await Shell.Current.GoToAsync(nameof(Views.PedidoPage));
        }
    }
}