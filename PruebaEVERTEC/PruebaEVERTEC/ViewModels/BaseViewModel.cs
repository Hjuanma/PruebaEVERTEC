using System;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PruebaEVERTEC.Services.Interfaces;

namespace PruebaEVERTEC.ViewModels
{
    public class BaseViewModel : BindableBase, INavigatedAware
    {

        #region Variables
        protected INavigationService _navigationService;
        protected IApiService _apiService;
        protected IPageDialogService _dialogService;
        #endregion

        #region Properties

        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }

        }

        #endregion

        public BaseViewModel()
        {
        }

        public virtual async void OnNavigatedFrom(INavigationParameters parameters)
        {
            
        }

        public virtual async void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }
    }
}

