using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using DigitalLibrary.Views.PublicationTypeV;
using Xamarin.Forms;

namespace DigitalLibrary.ViewModels.PublicationTypeVM
{
    public class PublicationTypeViewModel : AListViewModel<PublicationType>
    {
        public PublicationTypeViewModel() :base("publication type") { }
        public async override void OnItemSelected(PublicationType item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(PublicationTypeDetailsPage)}?{nameof(PublicationTypeDetailsViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(PublicationTypeNewPage));
        }
    }
}
