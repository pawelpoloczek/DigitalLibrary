using DigitalLibrary.ViewModels.BorrowerVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.BorrowerV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BorrowerNewPage : ContentPage
    {
        public Service.Reference.Borrower Item { get; set; }
        public BorrowerNewPage()
        {
            InitializeComponent();
            BindingContext = new NewBorrowerViewModel();
        }
    }
}