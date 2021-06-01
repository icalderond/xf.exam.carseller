using carseller.ViewModels;
using Xamarin.Forms;

namespace carseller.Views
{
    public partial class CreateProductPage : ContentPage
    {
        public CreateProductPage()
        {
            InitializeComponent();
            this.BindingContext = new CreateProductViewModel();
        }
    }
}
