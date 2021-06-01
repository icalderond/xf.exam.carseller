using System.Collections.ObjectModel;
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

        #region Methods
        public async Task LoadData()
        {
            DbContext = new DbContext();
            await DbContext.Products.Initialize();
            var productsDB = await DbContext.Products.Get();
            if (!productsDB.Any()) productsDB = ProductsMock.Products;

            productsDB = productsDB.OrderByDescending(x => x.Id).ToList();
            Products = new ObservableCollection<Product>(productsDB);
        }
        #endregion Methods

        #region Properties
        private ObservableCollection<Product> _Products;
        public ObservableCollection<Product> Products
        {
            get => _Products;
            set => Set(ref _Products, value);
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
        #endregion Commands
    }
}
