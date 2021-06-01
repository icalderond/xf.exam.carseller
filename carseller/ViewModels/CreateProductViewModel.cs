using System;
using System.Threading.Tasks;
using carseller.Models;
using carseller.Persistence;

namespace carseller.ViewModels
{
    public class CreateProductViewModel : BindableBase
    {
        #region Variables
        private DbContext DbContext;
        #endregion Variables

        public CreateProductViewModel()
        {
            _ = LoadData();
        }

        private async Task LoadData()
        {
            DbContext = new DbContext();
            await DbContext.Initialize();
        }

        #region Properties
        private Product _Product;
        public Product Product
        {
            get => _Product = _Product ?? new Product();
            set => Set(ref _Product, value);
        }

        #endregion Properties

        #region Commands
        private ActionCommand _SaveCommand;
        public ActionCommand SaveCommand
        {
            get => _SaveCommand = _SaveCommand ?? new ActionCommand(SaveAsync);
        }

        private async void SaveAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Product.Brand))
                    throw new Exception("The fiel Brand is required");
                if (Product.Kilometers <= 0)
                    throw new Exception("The fiel Kilometers is required");
                if (string.IsNullOrWhiteSpace(Product.Model))
                    throw new Exception("The fiel Model is required");
                if (Product.Price <= 0)
                    throw new Exception("The fiel Price is required");

                var idSaved = await DbContext.Products.Insert(Product);
                await App.Current.MainPage.DisplayAlert("Saved", $"Saved product with id {idSaved}", "Ok");

                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        #endregion Commands
    }
}
