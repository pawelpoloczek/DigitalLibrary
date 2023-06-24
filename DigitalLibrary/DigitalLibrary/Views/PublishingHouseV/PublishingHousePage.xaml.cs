using DigitalLibrary.ViewModels.PublishingHouseVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.PublishingHouseV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublishingHousePage : ContentPage
    {
        private PublishingHouseViewModel _viewModel;
        public PublishingHousePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PublishingHouseViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}