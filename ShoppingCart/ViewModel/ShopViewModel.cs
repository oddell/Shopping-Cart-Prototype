using ShoppingCart.Model.Objects;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ShoppingCart.ViewModel
{
    /// <summary>
    /// Represents the view model for the shopping cart.
    /// </summary>
    public class ShopViewModel : INotifyPropertyChanged
    {
        private IBasket _basket;
        private decimal _totalCost;
        private decimal _totalCostBeforeDiscount;
        private string _discountCode;
        private IProduct _selectedProduct;
        private int _selectedQuantity;

        /// <summary>
        /// Gets or sets the list of products.
        /// </summary>
        public ObservableCollection<IProduct> Products { get; set; }

        /// <summary>
        /// Gets or sets the list of basket items.
        /// </summary>
        public ObservableCollection<IBasketItem> BasketItems { get; set; }

        /// <summary>
        /// Gets the command to add a product to the basket.
        /// </summary>
        public ICommand AddToBasketCommand { get; }

        /// <summary>
        /// Gets the command to apply a discount to the basket.
        /// </summary>
        public ICommand ApplyDiscountCommand { get; }

        /// <summary>
        /// Event that is raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopViewModel"/> class.
        /// </summary>
        public ShopViewModel(IBasket basket)
        {
            if (basket == null)
            {
                throw new ArgumentNullException(nameof(basket));
            }
            _basket = basket;

            Products = new ObservableCollection<IProduct>
                {
                    new Product(Guid.NewGuid(), "Product 1", 10.0m),
                    new Product(Guid.NewGuid(), "Product 2", 20.0m),
                    new Product(Guid.NewGuid(), "Product 3", 30.0m)
                };

            SelectedQuantity = 1;
            BasketItems = new ObservableCollection<IBasketItem>();

            AddToBasketCommand = new RelayCommand(AddToBasket);
            ApplyDiscountCommand = new RelayCommand(ApplyDiscount);
        }

        /// <summary>
        /// Gets or sets the selected product.
        /// </summary>
        public IProduct SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the total cost of the basket.
        /// </summary>
        public decimal TotalCost
        {
            get => _totalCost;
            set
            {
                _totalCost = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the total cost of the basket before discount.
        /// </summary>
        public decimal TotalCostBeforeDiscount
        {
            get => _totalCostBeforeDiscount;
            set
            {
                _totalCostBeforeDiscount = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the selected quantity of the product.
        /// </summary>
        public int SelectedQuantity
        {
            get { return _selectedQuantity; }
            set
            {
                if (int.TryParse(value.ToString(), out int quantity) && quantity > 0)
                {
                    _selectedQuantity = quantity;
                }
                else
                {
                    _selectedQuantity = 1;
                }

                OnPropertyChanged(nameof(SelectedQuantity));
            }
        }

        /// <summary>
        /// Gets or sets the discount code to apply to the basket.
        /// </summary>
        public string DiscountCode
        {
            get => _discountCode;
            set
            {
                _discountCode = value;
                OnPropertyChanged();
            }
        }

        private void AddToBasket(object parameter)
        {
            if (parameter is Product product)
            {
                _basket.AddProduct(product, SelectedQuantity);
                RefreshBasketItems();
                UpdateTotalCost();
            }
        }


        private void ApplyDiscount(object parameter)
        {
            if (!string.IsNullOrEmpty(_discountCode))
            {
                _basket.ApplyDiscount(_discountCode);
                UpdateTotalCost();
            }
        }


        private void RefreshBasketItems()
        {
            BasketItems.Clear();
            foreach (var item in _basket.GetItems())
            {
                BasketItems.Add(item);
            }
        }

        private void UpdateTotalCost()
        {
            TotalCostBeforeDiscount = _basket.GetTotalCostBeforeDiscount();
            TotalCost = _basket.GetTotalCost();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

