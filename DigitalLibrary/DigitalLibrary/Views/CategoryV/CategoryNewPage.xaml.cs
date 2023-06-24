using DigitalLibrary.ViewModels.CategoryVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.CategoryV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryNewPage : ContentPage
    {
        public Service.Reference.Category Item { get; set; }

        public CategoryNewPage()
        {
            InitializeComponent();
            BindingContext = new NewCategoryViewModel();
        }
    }
}