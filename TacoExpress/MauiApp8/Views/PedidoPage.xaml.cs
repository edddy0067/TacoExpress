using MauiApp8.ViewModels;

namespace MauiApp8.Views;

public partial class PedidoPage : ContentPage
{
    public PedidoPage()
    {
        InitializeComponent();

        BindingContext = new PedidoViewModel();
    }
}