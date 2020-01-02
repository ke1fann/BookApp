using System;
using System.Text.RegularExpressions;
using System.Windows.Input;
using BookApp.SqliteDatabase.SQLiteDAL;
using BookApp.SqliteDatabase.SQLiteDomain;
using BookApp.Utilities;
using BookApp.Utilities.Const;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace BookApp.ViewModels
{
    public class ResetPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly ISqliteDal _sqliteDal;
        private ICommand _submitCommand;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private bool _isEmailInvalid;
        private bool _isPasswordInvalid;


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
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }
        public bool IsEmailInvalid
        {
            get => _isEmailInvalid;
            set => SetProperty(ref _isEmailInvalid, value);
        }
        public bool IsPasswordInvalid
        {
            get => _isPasswordInvalid;
            set => SetProperty(ref _isPasswordInvalid, value);
        }
        public ResetPageViewModel(INavigationService navigationService,ISqliteDal sqliteDal)
        {
            _navigationService = navigationService;
            _sqliteDal = sqliteDal;
        }


        public ICommand SubmitCommand => _submitCommand ?? (_submitCommand = new Command(Submit));
        private void Submit()
        {
            IsEmailInvalid = !string.IsNullOrEmpty(Email) && BookAppConst.IsInvalidEmail(Email);
            IsPasswordInvalid = !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword) && Password == ConfirmPassword;

            MessagingCenter.Send(this, MessageKey.ValidationInvalidKey);
            if (!IsEmailInvalid || !IsPasswordInvalid) return;
            if (_sqliteDal.IsInvalidUser(Email))
            {
                var user = _sqliteDal.GetUserInformation(Email);
                var updateUser = new UserInformation
                {
                    Email = Email,
                    UserName = user.UserName,
                    Password = Password
                };
                _sqliteDal.Register(updateUser);
            }
            _navigationService.GoBackAsync();

        }

        
    }
}
