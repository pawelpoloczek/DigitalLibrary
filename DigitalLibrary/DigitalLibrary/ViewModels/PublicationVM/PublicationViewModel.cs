using DigitalLibrary.Service.Reference;
using DigitalLibrary.Services.Abstract;
using DigitalLibrary.ViewModels.Abstract;
using DigitalLibrary.Views.PublicationV;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DigitalLibrary.ViewModels.PublicationVM
{
    public class PublicationViewModel : AListViewModel<Service.Reference.PublicationViewModel>
    {
        public PublicationViewModel() : base("Publications") { }
        public async override void OnItemSelected(Service.Reference.PublicationViewModel item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(PublicationDetailsPage)}?{nameof(PublicationDetailsViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(PublicationNewPage));
        }
    }
}
