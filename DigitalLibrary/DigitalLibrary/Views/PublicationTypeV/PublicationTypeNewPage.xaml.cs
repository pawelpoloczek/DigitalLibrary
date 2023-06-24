using DigitalLibrary.ViewModels.PublicationTypeVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.PublicationTypeV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublicationTypeNewPage : ContentPage
    {
        public Service.Reference.PublicationType Item { get; set; }
        public PublicationTypeNewPage()
        {
            InitializeComponent();
            BindingContext = new NewPublicationTypeViewModel();
        }
    }
}