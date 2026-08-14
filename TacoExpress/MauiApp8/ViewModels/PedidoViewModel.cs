using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp8.Models;
using MauiApp8.Services;
using System.Collections.ObjectModel;

namespace MauiApp8.ViewModels
{
    public partial class PedidoViewModel : ObservableObject
    {
        private readonly CarritoService _carritoService;

        private decimal _total;

        private string _numeroPedido = string.Empty;

        private bool _pedidoConfirmado;

        public ObservableCollection<Producto> Productos =>
            _carritoService.Productos;

        public decimal Total
        {
            get => _total;
            set => SetProperty(ref _total, value);
        }

        public string NumeroPedido
        {
            get => _numeroPedido;
            set => SetProperty(ref _numeroPedido, value);
        }

        public bool PedidoConfirmado
        {
            get => _pedidoConfirmado;
            set => SetProperty(ref _pedidoConfirmado, value);
        }

        public IAsyncRelayCommand ConfirmarPedidoCommand { get; }

        public PedidoViewModel()
        {
            _carritoService = CarritoService.Instance;

            Total = _carritoService.ObtenerTotal();

            ConfirmarPedidoCommand =
                new AsyncRelayCommand(ConfirmarPedido);
        }

        private async Task ConfirmarPedido()
        {
            if (Productos.Count == 0)
            {
                await Shell.Current.DisplayAlert(
                    "Pedido vacío",
                    "No hay productos para generar el pedido.",
                    "Aceptar");

                return;
            }

            NumeroPedido = $"TX-{DateTime.Now:yyyyMMddHHmmss}";

            PedidoConfirmado = true;

            await Shell.Current.DisplayAlert(
                "Pedido confirmado",
                $"Tu pedido {NumeroPedido} fue generado correctamente.\nTotal: ${Total:F2}",
                "Aceptar");

            _carritoService.VaciarCarrito();
        }
    }
}