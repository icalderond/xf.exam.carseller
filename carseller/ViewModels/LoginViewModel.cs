using System;
using System.Threading.Tasks;
using carseller.Views;

namespace carseller.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        public LoginViewModel()
        {
        }

        #region Properties
        private string _User;
        public string User
        {
            get => _User;
            set => Set(ref _User, value);
        }

        private string _Password;
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }
        #endregion Properties

        #region Commands
        private ActionCommand _LoginCommand;
        public ActionCommand LoginCommand
        {
            get => _LoginCommand = _LoginCommand ?? new ActionCommand(async () =>
            {
                await LoginAsync();
            });
        }
        #endregion Commands

        #region Methods
        private async Task LoginAsync()
        {
            await App.Current.MainPage.Navigation.PushAsync(new DashboardPage());
        }
        #endregion Methods
    }
}
