using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using BookApp.SqliteDatabase.SQLiteDAL;
using BookApp.Utilities;
using BookApp.Utilities.Const;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        private readonly ISqliteDal _sqliteDal;
        private readonly INavigationService _navigationService;
        private ICommand _forgetPasswordCommand;
        private ICommand _registerCommand;
        private ICommand _loginCommand;
        private ICommand _emailEntryUnfocusedCommand;
        private string _email;
        private string _password;
        private bool _emailInvaild;
        private bool _passwordInvaild;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public bool EmailInvaild
        {
            get => _emailInvaild;
            set => SetProperty(ref _emailInvaild, value);
        }
        public bool PasswordInvaild
        {
            get => _passwordInvaild;
            set => SetProperty(ref _passwordInvaild, value);
        }


        public LoginPageViewModel(INavigationService navigationService,ISqliteDal sqliteDal)
        {
            _sqliteDal = sqliteDal;
            _navigationService = navigationService;
        }

        public ICommand EmailEntryUnfocusedCommand => _emailEntryUnfocusedCommand ?? (_emailEntryUnfocusedCommand = new Command(EmailEntryUnfocused));
        private void EmailEntryUnfocused()
        {
        }


        public ICommand ForgetPasswordCommand => _forgetPasswordCommand ?? (_forgetPasswordCommand = new Command(ForgetPassword));
        private void ForgetPassword()
        {
            _navigationService.NavigateAsync("/LoginPage/RegisterPage");
        }

        public ICommand RegisterCommand => _registerCommand ?? (_registerCommand = new Command(Register));
        private void Register()
        {
            _navigationService.NavigateAsync(NavigationTo.RegisterPage);   
        }

        public ICommand LoginCommand => _loginCommand ?? (_loginCommand = new Command(Login));
        private void Login()
        {

            var isInvaildEmail = BookAppConst.IsInvalidEmail(Email);

            EmailInvaild = !string.IsNullOrEmpty(Email) && isInvaildEmail;
            PasswordInvaild = !string.IsNullOrEmpty(Password);
            MessagingCenter.Send(this, MessageKey.ValidationInvalidKey);

            if (!EmailInvaild || !PasswordInvaild) return;
            if (!_sqliteDal.Login(Email, Password)) return;
            _navigationService.NavigateAsync(NavigationTo.HomePage);
        }
    }

}
