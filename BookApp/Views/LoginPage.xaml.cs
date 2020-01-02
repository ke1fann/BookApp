using BookApp.Utilities;
using BookApp.ViewModels;
using Xamarin.Forms;

namespace BookApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<LoginPageViewModel>(this, MessageKey.ValidationInvalidKey, OnLoginREquested);
        }

        void OnLoginREquested(LoginPageViewModel loginPageViewModel)
        {
            if (!loginPageViewModel.EmailInvaild)
            {
                VisualStateManager.GoToState(emailEntry, "Invalid");
            }
            if (!loginPageViewModel.PasswordInvaild)
            {
                VisualStateManager.GoToState(passwordEntry, "Invalid");
            }
        }
    }
}
