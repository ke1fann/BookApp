using System;
using System.Collections.Generic;
using BookApp.Utilities;
using BookApp.ViewModels;
using Xamarin.Forms;

namespace BookApp.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<RegisterPageViewModel>(this, MessageKey.ValidationInvalidKey, OnRegisterRequested);
        }

         void OnRegisterRequested(RegisterPageViewModel registerPageViewModel)
        {
            if (!registerPageViewModel.IsEmailInvalid)
            {
                VisualStateManager.GoToState(emailEntry, "Invalid");
            }
            if (!registerPageViewModel.IsUserNameInvalid)
            {
                VisualStateManager.GoToState(userName, "Invalid");
            }
            if (!registerPageViewModel.IsPasswordInvalid)
            {
                VisualStateManager.GoToState(passwordEntry, "Invalid");
                VisualStateManager.GoToState(confrimPassword, "Invalid");
            }
        }
    }
}
