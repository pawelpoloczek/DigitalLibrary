using DigitalLibrary.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DigitalLibrary.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}