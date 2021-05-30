using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using carseller.Mocks;
using carseller.Models;
using carseller.Persistence;

namespace carseller.ViewModels
{
    public class DashboardViewModel : BindableBase
    {
        #region Variables
        public DbContext DbContext { get; set; }
        #endregion Variables

        public DashboardViewModel()
        {
            _ = LoadData();
        }

        private async Task LoadData()
        {
            DbContext = new DbContext();
            await DbContext.Products.Initialize();
            var productsDB = await DbContext.Products.Get();
            if (!productsDB.Any()) productsDB = ProductsMock.Products;
            Products = new ObservableCollection<Product>(productsDB);
        }

        #region Properties
        private ObservableCollection<Product> _Products;
        public ObservableCollection<Product> Products
        {
            get => _Products;
            set => Set(ref _Products, value);
        }
        #endregion Properties
    }
}
