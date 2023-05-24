using System;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using PrismDemo.ViewModels.Pages;
using PruebaEVERTEC.Helpers;
using PruebaEVERTEC.Resources.Resx;
using PruebaEVERTEC.Services;
using PruebaEVERTEC.ViewModels.Pages;
using PruebaEVERTEC.Views.Pages;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaEVERTEC
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            Settings.SetTheme();
            StatUpServices.ConfigurateServices();
            LocalizationResourceManager.Current.Init(AppResources.ResourceManager);
            NavigationService.NavigateAsync($"{PageRouts.NavigationBase}{PageRouts.LoginPage}");

        }

        /// <summary>
        /// Initialize services
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //Regist NavPage
            containerRegistry.RegisterForNavigation<NavigationPage>();

            //Regist View/ViewModels
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>();
            containerRegistry.RegisterForNavigation<ContactsPage, ContactsViewModel>();
        }

        protected override void OnStart()
        {
            base.OnStart();
            OnResume();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
            Settings.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;

        }

        protected override void OnResume()
        {
            base.OnResume();
            Settings.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Settings.SetTheme();

            });
        }
    }
}

