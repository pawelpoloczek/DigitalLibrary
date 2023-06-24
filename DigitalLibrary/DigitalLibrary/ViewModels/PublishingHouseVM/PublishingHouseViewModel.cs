using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using DigitalLibrary.Views.PublishingHouseV;
using Xamarin.Forms;

namespace DigitalLibrary.ViewModels.PublishingHouseVM
{
    public class PublishingHouseViewModel : AListViewModel<PublishingHouse>
    {
        public PublishingHouseViewModel() : base("Publishing House") { }
        public async override void OnItemSelected(PublishingHouse item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(PublishingHouseDetailsPage)}?{nameof(PublishingHouseDetailsViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(PublishingHouseNewPage));
        }
    }
}
