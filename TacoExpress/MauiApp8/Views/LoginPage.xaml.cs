using MauiApp8.ViewModels;

namespace MauiApp8.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}