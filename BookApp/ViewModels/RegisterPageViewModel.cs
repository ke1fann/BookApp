using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using BookApp.Utilities;
using BookApp.Utilities.Const;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class RegisterPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private string _email;
        private string _userName;
        private string _password;
        private string _confirmPassword;
        private bool _isRegisterEnable;
        private bool _isEmailInvalid;
        private bool _isUsernameInvalid;
        private bool _isPasswordInvalid;
        private ICommand _regiesterCommand;




        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }
        public bool IsRegisterEnable
        {
            get => _isRegisterEnable;
            set => SetProperty(ref _isRegisterEnable, value);
        }
        public bool IsEmailInvalid
        {
            get => _isEmailInvalid;
            set => SetProperty(ref _isEmailInvalid, value);
        }
        public bool IsUserNameInvalid
        {
            get => _isUsernameInvalid;
            set => SetProperty(ref _isUsernameInvalid, value);
        }
        public bool IsPasswordInvalid
        {
            get => _isPasswordInvalid;
            set => SetProperty(ref _isPasswordInvalid, value);
        }

        public RegisterPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand RegiesterCommand => _regiesterCommand ?? (_regiesterCommand = new Command(Regiester));
        private void Regiester()
        {
            IsEmailInvalid = !string.IsNullOrEmpty(Email) && IsEmail(Email);
            IsUserNameInvalid = !string.IsNullOrEmpty(UserName);
            IsPasswordInvalid = Password == ConfirmPassword && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword);

            MessagingCenter.Send(this, MessageKey.EmailLoginValidation);
            MessagingCenter.Send(this, MessageKey.UserNameValidation);
            MessagingCenter.Send(this, MessageKey.PasswordLoginValidation);

            if (!IsEmailInvalid || !IsUserNameInvalid || !IsPasswordInvalid) return;
            _navigationService.GoBackAsync();
            
        }

        public static bool IsEmail(string inputData)
        {
            if (string.IsNullOrEmpty(inputData)) return false;

            Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");
            return RegEmail.IsMatch(inputData);
        }
    }
}
