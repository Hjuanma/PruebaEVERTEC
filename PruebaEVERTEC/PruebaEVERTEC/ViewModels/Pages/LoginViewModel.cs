using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PruebaEVERTEC.Models;
using PruebaEVERTEC.ViewModels;
using PruebaEVERTEC.Views.Pages;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;

namespace PrismDemo.ViewModels.Pages
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Properties

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _passWord;

        public string PassWord
        {
            get { return _passWord; }
            set { SetProperty(ref _passWord, value); }

        }

        #endregion

        #region Commands

        public DelegateCommand<object> OnLoginCommand => new DelegateCommand<object>(async act => await LoginOptionAlert((LoginActions)act));

        #endregion



        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        private async Task LoginOptionAlert(LoginActions act)
        {
            switch (act)
            {
                case LoginActions.Login:
                    await GoMainPage();
                    break;
                case LoginActions.Google:
                case LoginActions.FaceBook:
                case LoginActions.Instagram:
                case LoginActions.SingUp:
                case LoginActions.Recover:
                    await _dialogService.DisplayAlertAsync("", act.ToString(), "OK");
                    break;
                default:
                    break;
            }
        }

        private async Task GoMainPage()
        {
            if (!IsBusy)
            {

                IsBusy = true;
                if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(PassWord))
                {
                    await _dialogService.DisplayAlertAsync("Error", "Username and Password are required", "ok")
                        .ContinueWith(_ => { IsBusy = false; });
                }
                else
                {
                    await _navigationService.NavigateAsync($"{PageRouts.NavigationBase}{PageRouts.HomePage}")
                        .ContinueWith(_ => { IsBusy = false; });
                }
            }
        }


    }
}

