using DigitalLibrary.ViewModels.FormatVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.FormatV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormatDetailsPage : ContentPage
    {
        public FormatDetailsPage()
        {
            InitializeComponent();
            BindingContext = new FormatDetailsViewModel();
        }
    }
}