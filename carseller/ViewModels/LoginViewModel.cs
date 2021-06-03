using System;
using System.Threading.Tasks;
using carseller.Persistence;
using carseller.Views;

namespace carseller.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        public LoginViewModel()
        {
            DbContext = new DbContext();
            Initialize();
        }

        #region Variables
        public DbContext DbContext { get; set; }
        #endregion Variables

        #region Properties
        private string _Username;
        public string Username
        {
            get => _Username;
            set => Set(ref _Username, value);
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

        private ActionCommand _RegisterCommand;
        public ActionCommand RegisterCommand
        {
            get => _RegisterCommand = _RegisterCommand ?? new ActionCommand(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
            });
        }

        #endregion Commands

        #region Methods

        private async void Initialize()
        {
            await DbContext.Initialize();
        }

        private async Task LoginAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Username))
                    throw new Exception("Username is required");
                if (string.IsNullOrWhiteSpace(Password))
                    throw new Exception("Password is required");

                var account = await DbContext.Accounts.Get(
                    (x) => x.Username.ToLower() == Username.ToLower()
                    && x.Password.ToLower() == Password.ToLower());

                if (account == null)
                    throw new Exception("Account not founded");

                await App.Current.MainPage.Navigation.PushAsync(new DashboardPage());
            }
            catch (System.Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Login Error", ex.Message, "Ok");
            }
        }
        #endregion Methods
    }
}
