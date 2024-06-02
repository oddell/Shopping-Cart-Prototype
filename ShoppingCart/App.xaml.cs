using ShoppingCart.ViewModel;
using ShoppingCartApp;
using System.Windows;
using Unity;

namespace ShoppingCart
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Configure Unity
            UnityConfig.RegisterComponents();

            // Resolve the main view and set its DataContext
            var shopView = new View.ShopView
            {
                DataContext = UnityConfig.Container.Resolve<ShopViewModel>()
            };

            shopView.Show();
        }
    }
}
