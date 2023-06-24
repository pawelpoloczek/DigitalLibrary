using DigitalLibrary.ViewModels.BorrowerVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.BorrowerV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BorrowerDetailsPage : ContentPage
    {
        public BorrowerDetailsPage()
        {
            InitializeComponent();
            BindingContext = new BorrowerDetailsViewModel();
        }
    }
}