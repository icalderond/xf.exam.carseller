using carseller.ViewModels;
using Xamarin.Forms;

namespace carseller.Views
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            this.BindingContext = new DashboardViewModel();
        }
    }
}
