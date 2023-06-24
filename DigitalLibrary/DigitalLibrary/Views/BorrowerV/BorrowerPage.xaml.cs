using DigitalLibrary.ViewModels.BorrowerVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.BorrowerV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BorrowerPage : ContentPage
    {
        private BorrowerViewModel _viewModel;
        public BorrowerPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new BorrowerViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}