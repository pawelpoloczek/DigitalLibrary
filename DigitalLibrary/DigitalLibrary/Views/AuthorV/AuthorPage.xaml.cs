using DigitalLibrary.ViewModels.Abstract;
using DigitalLibrary.ViewModels.AuthorVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.AuthorV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorPage : ContentPage
    {
        private AuthorViewModel _viewModel;
        public AuthorPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AuthorViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}