using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using DigitalLibrary.Views.LectorV;
using Xamarin.Forms;

namespace DigitalLibrary.ViewModels.LectorVM
{
    public class LectorViewModel : AListViewModel<Lector>
    {
        public LectorViewModel() : base("Lector") { }
        public async override void OnItemSelected(Lector item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(LectorDetailsPage)}?{nameof(LectorDetailsViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(LectorNewPage));
        }
    }
}
