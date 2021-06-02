using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using carseller.Mocks;
using carseller.Models;
using carseller.Persistence;
using carseller.Views;

namespace carseller.ViewModels
{
    public class DashboardViewModel : BindableBase
    {
        #region Variables
        public DbContext DbContext { get; set; }
        #endregion Variables

        public DashboardViewModel()
        {
            Initializer();
        }

        private async void Initializer()
        {
            DbContext = new DbContext();
            await DbContext.Initialize();
        }

        #region Methods
        public async Task LoadData()
        {
            var productsDB = await DbContext.Products.Get();
            if (!productsDB.Any())
            {
                foreach (var item in ProductsMock.Products)
                    await DbContext.Products.Insert(item);

                productsDB = await DbContext.Products.Get();
            }
            Products = new ObservableCollection<Product>(productsDB.OrderByDescending(x => x.Id).ToList());
        }
        #endregion Methods

        #region Properties
        private ObservableCollection<Product> _Products;
        public ObservableCollection<Product> Products
        {
            get => _Products;
            set => Set(ref _Products, value);
        }

        private Product _ProductSelected;
        public Product ProductSelected
        {
            get => _ProductSelected;
            set
            {
                Set(ref _ProductSelected, value);
                if (value != null)
                    UpdateCommand.Execute(value.Id);
            }
        }
        #endregion Properties

        #region Commands
        private ActionCommand _CreateCommand;
        public ActionCommand CreateCommand
        {
            get => _CreateCommand = _CreateCommand ?? new ActionCommand(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new CreateProductPage());
            });
        }

        private ActionCommand<int> _UpdateCommand;
        public ActionCommand<int> UpdateCommand
        {
            get => _UpdateCommand = _UpdateCommand ?? new ActionCommand<int>(async (productId) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new CreateProductPage(productId));
            });
        }
        #endregion Commands
    }
}
