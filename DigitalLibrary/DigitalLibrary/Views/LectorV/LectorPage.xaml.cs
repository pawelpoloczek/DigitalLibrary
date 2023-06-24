using DigitalLibrary.ViewModels.LectorVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.LectorV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LectorPage : ContentPage
    {
        private LectorViewModel _viewModel;
        public LectorPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LectorViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}