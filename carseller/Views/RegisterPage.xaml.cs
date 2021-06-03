using Xamarin.Forms;

namespace carseller.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.RegisterViewModel();
        }
    }
}
