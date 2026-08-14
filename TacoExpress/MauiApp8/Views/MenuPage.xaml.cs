using MauiApp8.ViewModels;

namespace MauiApp8.Views;

public partial class MenuPage : ContentPage
{
    public MenuPage()
    {
        InitializeComponent();

        BindingContext = new MenuViewModel();
    }

    private async void OnVerCarritoClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CarritoPage));
    }
}