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

        public CreateProductViewModel(int _productId)
        {
            ProductId = _productId;
            _ = LoadData();
        }

        private async Task LoadData()
        {
            DbContext = new DbContext();
            await DbContext.Initialize();

            if (ProductId > 0)
                Product = await DbContext.Products.Get(ProductId);
        }

        #region Properties
        private Product _Product;
        public Product Product
        {
            get => _Product = _Product ?? new Product();
            set => Set(ref _Product, value);
        }

        private int _ProductId;
        public int ProductId
        {
            get => _ProductId;
            set => Set(ref _ProductId, value);
        }
        #endregion Properties

        #region Commands
        private ActionCommand _SaveCommand;
        public ActionCommand SaveCommand
        {
            get => _SaveCommand = _SaveCommand ?? new ActionCommand(SaveAsync);
        }

        private ActionCommand _DeleteCommand;
        public ActionCommand DeleteCommand
        {
            get => _DeleteCommand = _DeleteCommand ?? new ActionCommand(DeleteAsync);
        }

        #endregion Commands

        #region Methods
        private async void DeleteAsync()
        {
            try
            {
                var allowDelete = await App.Current.MainPage.DisplayAlert("Delete message", "This product will be deleted, ¿are you sure?", "Delete", "No delete");

                if (allowDelete)
                {
                    var productToDelete = await DbContext.Products.Get(ProductId);
                    await DbContext.Products.Delete(productToDelete);
                    await App.Current.MainPage.DisplayAlert("Deleted", $"Product was deleted", "Ok");

                    await App.Current.MainPage.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
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

                if (ProductId > 0)
                    await DbContext.Products.Update(Product);
                else
                    await DbContext.Products.Insert(Product);

                await App.Current.MainPage.DisplayAlert("Saved", $"Product was saved", "Ok");

                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        #endregion Methods
    }
}
