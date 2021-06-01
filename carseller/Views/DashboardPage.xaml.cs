using carseller.ViewModels;
using Xamarin.Forms;

namespace carseller.Views
{
    public partial class DashboardPage : ContentPage
    {
        private DashboardViewModel ViewModel = new DashboardViewModel();
        public DashboardPage()
        {
            InitializeComponent();
            this.BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _ = ViewModel.LoadData();
        }
    }
}
