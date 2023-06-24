using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using DigitalLibrary.Views.BorrowerV;
using Xamarin.Forms;

namespace DigitalLibrary.ViewModels.BorrowerVM
{
    public class BorrowerViewModel : AListViewModel<Borrower>
    {
        public BorrowerViewModel() : base("Borrower") { }
        public async override void OnItemSelected(Borrower item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(BorrowerDetailsPage)}?{nameof(BorrowerDetailsViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(BorrowerNewPage));
        }
    }
}
