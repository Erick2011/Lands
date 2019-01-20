namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel: BaseViewModel
    {

        #region Attributes
        private string email;

        private string password;

        private bool isRunning;

        private bool isRemembered;

        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { this.SetValue(ref email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { this.SetValue(ref password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { this.SetValue(ref isRunning, value); }
        }

        public bool IsRemembered
        {
            get { return this.isRemembered; }
            set { this.SetValue(ref isRemembered, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref isEnabled, value); }
        }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnabled = true;
        }
        #endregion

        #region Command
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        #endregion

        #region Methods
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", 
                    "You must to enter an email", 
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must to enter a password",
                    "Accept");
                return;
            }

            this.IsEnabled = false;
            this.IsRunning = true;

            if (!this.Email.Equals("erick_johan2011@hotmail.com") || !this.Password.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or password incorrect",
                    "Accept");

                this.Password = string.Empty;
                this.IsEnabled = true;
                this.IsRunning = false;
                return;
            }

            this.IsEnabled = true;
            this.IsRunning = false;

            await Application.Current.MainPage.DisplayAlert(
                    "OK",
                    "Todo bien!!",
                    "Accept");          
        }
        #endregion
    }
}
