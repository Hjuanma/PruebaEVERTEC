
using MediatR;
using Prism.Navigation;
using Prism.Services;
using PruebaEVERTEC.Application.DTOs;
using PruebaEVERTEC.Application.Ports.Input.Queries;
using PruebaEVERTEC.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PruebaEVERTEC.ViewModels.Pages
{
    public class ContactsViewModel : BaseViewModel
    {

        private readonly IMediator _mediator;

        private ObservableCollection<ContactResponse> _contacts;

        public ObservableCollection<ContactResponse> Contacts
        {
            get => _contacts;
            set => SetProperty(ref _contacts, value);
        }


        public ContactsViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            _mediator = StatUpServices.Resolve<IMediator>();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            Contacts = new ObservableCollection<ContactResponse>(await _mediator.Send(new GetContactsQuery()));
            /*Contacts = new ObservableCollection<ContactResponse>(new List<ContactResponse>
            {
                new ContactResponse{
                    Id=1, Name = "A", Avatar = "A",CreatedAt = DateTime.Now,TechQuote = new Domain.Entities.TechQuote{Id=1, Quote= "lkdjaslkdjlaksjdklasjdlkajsld"}
                },
                new ContactResponse{
                    Id=2, Name = "A", Avatar = "A",CreatedAt = DateTime.Now,TechQuote = new Domain.Entities.TechQuote{Id=1, Quote= "lkdjaslkdjlaksjdklasjdlkajsld"}
                }
            });*/
            base.OnNavigatedTo(parameters);
        }
    }
}
