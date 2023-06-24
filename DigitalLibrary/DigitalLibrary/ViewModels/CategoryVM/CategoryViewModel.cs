using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using DigitalLibrary.Views.CategoryV;
using System;
using Xamarin.Forms;

namespace DigitalLibrary.ViewModels.CategoryVM
{
    public class CategoryViewModel : AListViewModel<Category>
    {
        public CategoryViewModel(): base("Category") { }


        public async override void OnItemSelected(Category item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(CategoryDetailsPage)}?{nameof(CategoryDetailsViewModel.ItemId)}={item.Id}");
        }

        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(CategoryNewPage));
        }
    }
}
