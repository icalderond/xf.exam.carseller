using carseller.ViewModels;
using Xamarin.Forms;

namespace carseller.Views
{
    public partial class CreateProductPage : ContentPage
    {
        public CreateProductPage(int productId = 0)
        {
            InitializeComponent();
            this.BindingContext = new CreateProductViewModel(productId);
        }
    }
}
