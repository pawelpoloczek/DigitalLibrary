using DigitalLibrary.ViewModels;
using DigitalLibrary.Views;
using DigitalLibrary.Views.CategoryV;
using DigitalLibrary.Views.FormatV;
using DigitalLibrary.Views.PublicationTypeV;
using DigitalLibrary.Views.PublishingHouseV;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DigitalLibrary
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));

            Routing.RegisterRoute(nameof(CategoryNewPage), typeof(CategoryNewPage));
            Routing.RegisterRoute(nameof(CategoryDetailsPage), typeof(CategoryDetailsPage));

            Routing.RegisterRoute(nameof(PublicationTypeNewPage), typeof(PublicationTypeNewPage));
            Routing.RegisterRoute(nameof(PublicationTypeDetailsPage), typeof(PublicationTypeDetailsPage));

            Routing.RegisterRoute(nameof(FormatNewPage), typeof(FormatNewPage));
            Routing.RegisterRoute(nameof(FormatDetailsPage), typeof(FormatDetailsPage));

            Routing.RegisterRoute(nameof(PublishingHouseNewPage), typeof(PublishingHouseNewPage));
            Routing.RegisterRoute(nameof(PublishingHouseDetailsPage), typeof(PublishingHouseDetailsPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
