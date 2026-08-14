using MauiApp8.ViewModels;

namespace MauiApp8.Views;

public partial class CarritoPage : ContentPage
{
    private readonly CarritoViewModel _viewModel;

    public CarritoPage()
    {
        InitializeComponent();

        _viewModel = new CarritoViewModel();

        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _viewModel.ActualizarTotal();
    }
}