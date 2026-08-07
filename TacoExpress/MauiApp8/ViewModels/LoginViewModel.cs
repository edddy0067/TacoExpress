using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp8.Helpers;
using MauiApp8.Models;
using MauiApp8.Services;
using MauiApp8.Views;

namespace MauiApp8.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly AuthService _authService;
    public LoginViewModel(AuthService authService)
    {
        _authService = authService;
    }

    [ObservableProperty]
    private string username = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [RelayCommand]
    private async Task Login()
    {
        if (string.IsNullOrWhiteSpace(Username) ||
            string.IsNullOrWhiteSpace(Password))
        {
            await Shell.Current.DisplayAlert(
                "Error",
                "Ingrese usuario y contraseña.",
                "Aceptar");

            return;
        }

        // Generar el hash SHA-256 de la contraseña.
        // No se envía porque DummyJSON requiere la contraseña original.

        string passwordHash = PasswordHelper.ComputeSha256(Password);

        LoginRequest request = new LoginRequest
        {
            Username = Username,
            Password = Password
        };

        var response = await _authService.LoginAsync(request);

        if (!response.Success)
        {
            await Shell.Current.DisplayAlert(
                "Login",
                response.Message,
                "Aceptar");

            return;
        }

        await SessionManager.SaveTokenAsync(response.Data!.AccessToken);

        await Shell.Current.DisplayAlert(
            "Correcto",
            "Inicio de sesión exitoso",
            "Aceptar");

        await Shell.Current.GoToAsync(nameof(MenuPage));
    }


}

