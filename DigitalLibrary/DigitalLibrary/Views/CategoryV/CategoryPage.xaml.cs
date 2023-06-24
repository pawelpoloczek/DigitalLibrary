using DigitalLibrary.ViewModels.CategoryVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.CategoryV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        private CategoryViewModel _viewModel;

        public CategoryPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CategoryViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}