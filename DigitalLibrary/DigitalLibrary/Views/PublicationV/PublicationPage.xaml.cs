using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalLibrary.ViewModels.PublicationVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.PublicationV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublicationPage : ContentPage
    {
        private PublicationViewModel _viewModel;
        public PublicationPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PublicationViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}