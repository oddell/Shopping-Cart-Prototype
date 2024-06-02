using ShoppingCart.Model.Objects;
using ShoppingCart.ViewModel;
using Unity;

namespace ShoppingCartApp
{
    /// <summary>
    /// Configures the Unity container for dependency injection.
    /// </summary>
    public static class UnityConfig
    {
        private static IUnityContainer _container;

        /// <summary>
        /// Registers the components in the Unity container.
        /// </summary>
        public static void RegisterComponents()
        {
            _container = new UnityContainer();

            // Register types
            _container.RegisterType<IBasket, Basket>();
            _container.RegisterType<ShopViewModel>();
        }

        /// <summary>
        /// Gets the Unity container.
        /// </summary>
        public static IUnityContainer Container => _container;
    }
}
