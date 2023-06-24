using DigitalLibrary.ViewModels.PublicationTypeVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.PublicationTypeV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublicationTypeDetailsPage : ContentPage
    {
        public PublicationTypeDetailsPage()
        {
            InitializeComponent();
            BindingContext = new PublicationTypeDetailsViewModel();
        }
    }
}