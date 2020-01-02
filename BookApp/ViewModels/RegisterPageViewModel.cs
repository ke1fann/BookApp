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
    public class RegisterPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        private readonly ISqliteDal _sqliteDal;
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

        public RegisterPageViewModel(INavigationService navigationService, ISqliteDal sqliteDal)
        {
            _navigationService = navigationService;
            _sqliteDal = sqliteDal;
        }

        public ICommand RegiesterCommand => _regiesterCommand ?? (_regiesterCommand = new Command(Regiester));
        private void Regiester()
        {
            IsEmailInvalid = !string.IsNullOrEmpty(Email) && BookAppConst.IsInvalidEmail(Email);
            IsUserNameInvalid = !string.IsNullOrEmpty(UserName);
            IsPasswordInvalid = Password == ConfirmPassword && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(ConfirmPassword);

            MessagingCenter.Send(this, MessageKey.ValidationInvalidKey);
            var user = new UserInformation
            {
                Email = Email,
                UserName = UserName,
                Password = Password
            };

            if (!IsEmailInvalid || !IsUserNameInvalid || !IsPasswordInvalid) return;
            if (!_sqliteDal.Register(user)) return;

            _navigationService.GoBackAsync();
            
        }
    }
}
