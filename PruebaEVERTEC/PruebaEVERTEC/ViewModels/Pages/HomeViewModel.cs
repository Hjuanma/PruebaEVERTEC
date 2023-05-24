using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using Prism.Services;
using PruebaEVERTEC.Resources.Resx;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.ObjectModel;
using Prism.Commands;
using PruebaEVERTEC.Views.Pages;

namespace PruebaEVERTEC.ViewModels.Pages
{
    public class HomeViewModel : BaseViewModel
    {
        List<(Func<string> name, string value)> languageMapping { get; } = new List<(Func<string> name, string value)>
        {
            (() => AppResources.english, "en"),
            (() => AppResources.spanish, "es"),
        };

        public LocalizedString CurrentLanguage { get; }

        private LocalizedString _selectedLanguage;
        public LocalizedString SelectedLanguage
        {
            get { return _selectedLanguage; }
            set { SetProperty(ref _selectedLanguage, value); }
        }

        private DateTime _lastUpdate = DateTime.Now;
        public DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set { SetProperty(ref _lastUpdate, value); }
        }

        public ICommand ChangeLanguageCommand { get; }

        public DelegateCommand<object> OnContactsCommand => new DelegateCommand<object>(async act => await GoToContacts());
        

        public HomeViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;

            CurrentLanguage = new LocalizedString(GetCurrentLanguageName);
            ChangeLanguageCommand = new AsyncCommand(ChangeLanguage);
            SelectedLanguage = new LocalizedString(() => AppResources.spanish);

        }
        private string GetCurrentLanguageName()
        {
            var (knownName, _) = languageMapping.SingleOrDefault(m => m.value == LocalizationResourceManager.Current.CurrentCulture.TwoLetterISOLanguageName);
            return knownName != null ? knownName() : LocalizationResourceManager.Current.CurrentCulture.DisplayName;
        }

        async Task ChangeLanguage()
        {
            string selectedName = await App.Current.MainPage.DisplayActionSheet(
                AppResources.changeLanguage,
                null, null,
                languageMapping.Select(m => m.name()).ToArray());
            if (selectedName == null)
            {
                return;
            }

            string selectedValue = languageMapping.Single(m => m.name() == selectedName).value;
            LocalizationResourceManager.Current.CurrentCulture = selectedValue == null ? CultureInfo.CurrentCulture : new CultureInfo(selectedValue);
            if (selectedValue.Equals("en"))
            {
                SelectedLanguage = new LocalizedString(() => AppResources.english);
            }
            else
            {
                SelectedLanguage = new LocalizedString(() => AppResources.spanish);
            }

            LastUpdate = DateTime.Now;
        }

        private async Task GoToContacts()
        {
            await _navigationService.NavigateAsync($"{PageRouts.NavigationBase}{PageRouts.ContactsPage}")
                .ContinueWith(_ => { IsBusy =false; });
        }
    }
}