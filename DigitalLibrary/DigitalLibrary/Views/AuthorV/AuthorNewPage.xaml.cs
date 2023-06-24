using DigitalLibrary.ViewModels.AuthorVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.AuthorV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorNewPage : ContentPage
    {
        public Service.Reference.Author Item { get; set; }
        public AuthorNewPage()
        {
            InitializeComponent();
            BindingContext = new NewAuthorViewModel();
        }
    }
}