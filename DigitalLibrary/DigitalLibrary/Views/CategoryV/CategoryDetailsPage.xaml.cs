using DigitalLibrary.ViewModels.CategoryVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.CategoryV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryDetailsPage : ContentPage
    {
        public CategoryDetailsPage()
        {
            InitializeComponent();
            BindingContext = new CategoryDetailsViewModel();
        }
    }
}