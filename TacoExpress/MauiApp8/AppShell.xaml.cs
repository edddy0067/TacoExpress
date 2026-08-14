using MauiApp8.Views;
namespace MauiApp8
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(MenuPage), typeof(MenuPage));
            Routing.RegisterRoute(nameof(CarritoPage), typeof(CarritoPage));
            Routing.RegisterRoute(nameof(PedidoPage), typeof(PedidoPage));
            Routing.RegisterRoute(nameof(CarritoPage), typeof(CarritoPage));
            Routing.RegisterRoute(nameof(PedidoPage), typeof(PedidoPage));
        }
    }
}
