using DigitalLibrary.ViewModels.FormatVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.FormatV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormatPage : ContentPage
    {
        private FormatViewModel _viewModel;
        public FormatPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new FormatViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}