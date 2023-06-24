using DigitalLibrary.ViewModels.PublicationVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.PublicationV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublicationDetailsPage : ContentPage
    {
        public PublicationDetailsPage()
        {
            InitializeComponent();
            BindingContext = new PublicationDetailsViewModel();
        }
    }
}