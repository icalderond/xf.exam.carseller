using System;
using System.Threading.Tasks;
using carseller.Models;
using carseller.Persistence;

namespace carseller.ViewModels
{
    internal class RegisterViewModel : BindableBase
    {
        public RegisterViewModel()
        {
            DbContext = new DbContext();
            Initialize();
        }

        #region Variables
        public DbContext DbContext { get; set; }
        #endregion Variables

        #region Properties
        private Account _Account;
        public Account Account
        {
            get => _Account = _Account ?? new Account();
            set => Set(ref _Account, value);
        }
        #endregion Properties

        #region Commands
        private ActionCommand _RegisterCommand;
        public ActionCommand RegisterCommand
        {
            get => _RegisterCommand = _RegisterCommand ?? new ActionCommand(async () =>
            {
                await RegisterAccountAsync();
            });
        }
        #endregion Commands

        #region Methods

        private async void Initialize()
        {
            await DbContext.Initialize();
        }

        private async Task RegisterAccountAsync()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Account.Name))
                    throw new Exception("Name is required");
                if (string.IsNullOrWhiteSpace(Account.Username))
                    throw new Exception("Username is required");
                if (string.IsNullOrWhiteSpace(Account.Password))
                    throw new Exception("Password is required");

                await DbContext.Accounts.Insert(Account);
                await App.Current.MainPage.Navigation.PopAsync();
                await App.Current.MainPage.DisplayAlert("Account", "Account created", "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Account Error", ex.Message, "Ok");
            }
        }
        #endregion Methods

    }
}