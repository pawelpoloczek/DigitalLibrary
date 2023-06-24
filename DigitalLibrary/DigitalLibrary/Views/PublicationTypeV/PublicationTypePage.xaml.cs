using DigitalLibrary.ViewModels.PublicationTypeVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.PublicationTypeV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublicationTypePage : ContentPage
    {
        private PublicationTypeViewModel _viewModel;
        public PublicationTypePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PublicationTypeViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}