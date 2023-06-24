using DigitalLibrary.ViewModels.LectorVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.LectorV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LectorNewPage : ContentPage
    {
        public Service.Reference.Lector Item { get; set; }
        public LectorNewPage()
        {
            InitializeComponent();
            BindingContext = new NewLectorViewModel();
        }
    }
}