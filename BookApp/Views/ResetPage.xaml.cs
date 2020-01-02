using System;
using System.Collections.Generic;
using BookApp.Utilities;
using BookApp.ViewModels;
using Xamarin.Forms;

namespace BookApp.Views
{
    public partial class ResetPage : ContentPage
    {
        public ResetPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<ResetPageViewModel>(this, MessageKey.ValidationInvalidKey, SubMitRequested);
        }
        private void SubMitRequested(ResetPageViewModel resetPageViewModel)
        {
            if (!resetPageViewModel.IsEmailInvalid)
            {
                VisualStateManager.GoToState(emailEntry, "Invalid");
            }
            if (!resetPageViewModel.IsPasswordInvalid)
            {
                VisualStateManager.GoToState(resetPasswordEntry, "Invalid");
                VisualStateManager.GoToState(confirmResetPasswordEntry, "Invalid");
            }
        }
    }
}
