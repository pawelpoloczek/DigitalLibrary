using System;
using DigitalLibrary.ViewModels.PublishingHouseVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.PublishingHouseV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublishingHouseDetailsPage : ContentPage
    {
        public PublishingHouseDetailsPage()
        {
            InitializeComponent();
            BindingContext = new PublishingHouseDetailsViewModel();
        }
    }
}