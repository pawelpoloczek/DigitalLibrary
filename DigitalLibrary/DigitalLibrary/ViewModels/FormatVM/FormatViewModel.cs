using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using DigitalLibrary.Views.FormatV;
using Xamarin.Forms;

namespace DigitalLibrary.ViewModels.FormatVM
{
    public class FormatViewModel : AListViewModel<Format>
    {
        public FormatViewModel() : base("publication type") { }
        public async override void OnItemSelected(Format item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(FormatDetailsPage)}?{nameof(FormatDetailsViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(FormatNewPage));
        }
    }
}
