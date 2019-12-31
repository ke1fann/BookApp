using System;
using BookApp.Utilities.Const;
using BookApp.ViewModels;
using BookApp.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;

namespace BookApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }


        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync(NavigationTo.LoginPage);

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
        }
    }
}

