using DigitalLibrary.ViewModels.FormatVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.FormatV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormatNewPage : ContentPage
    {
        public Service.Reference.Format Item { get; set; }
        public FormatNewPage()
        {
            InitializeComponent();
            BindingContext = new NewFormatViewModel();
        }
    }
}