using DigitalLibrary.ViewModels.AuthorVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.AuthorV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorDetailsPage : ContentPage
    {
        public AuthorDetailsPage()
        {
            InitializeComponent();
            BindingContext = new AuthorDetailsViewModel();
        }
    }
}