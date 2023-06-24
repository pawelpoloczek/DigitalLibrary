using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using DigitalLibrary.ViewModels.BorrowerVM;
using DigitalLibrary.Views.AuthorV;
using DigitalLibrary.Views.BorrowerV;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DigitalLibrary.ViewModels.AuthorVM
{
    public class AuthorViewModel : AListViewModel<Author>
    {
        public AuthorViewModel() : base("Author index!")
        {
        }
        public async override void OnItemSelected(Author item)
        {
            if (item == null)
                return;
            await Shell.Current.GoToAsync($"{nameof(AuthorDetailsPage)}?{nameof(AuthorDetailsViewModel.ItemId)}={item.Id}");

        }
        public override void GoToAddPage()
        {
            Shell.Current.GoToAsync(nameof(AuthorNewPage));
        }
    }
}
