using DigitalLibrary.ViewModels;
using DigitalLibrary.Views;
using DigitalLibrary.Views.AuthorV;
using DigitalLibrary.Views.BorrowerV;
using DigitalLibrary.Views.CategoryV;
using DigitalLibrary.Views.FormatV;
using DigitalLibrary.Views.LectorV;
using DigitalLibrary.Views.PublicationTypeV;
using DigitalLibrary.Views.PublicationV;
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

            Routing.RegisterRoute(nameof(PublicationNewPage), typeof(PublicationNewPage));
            Routing.RegisterRoute(nameof(PublicationDetailsPage), typeof(PublicationDetailsPage));

            Routing.RegisterRoute(nameof(AuthorNewPage), typeof(AuthorNewPage));
            Routing.RegisterRoute(nameof(AuthorDetailsPage), typeof(AuthorDetailsPage));

            Routing.RegisterRoute(nameof(CategoryNewPage), typeof(CategoryNewPage));
            Routing.RegisterRoute(nameof(CategoryDetailsPage), typeof(CategoryDetailsPage));

            Routing.RegisterRoute(nameof(PublicationTypeNewPage), typeof(PublicationTypeNewPage));
            Routing.RegisterRoute(nameof(PublicationTypeDetailsPage), typeof(PublicationTypeDetailsPage));

            Routing.RegisterRoute(nameof(FormatNewPage), typeof(FormatNewPage));
            Routing.RegisterRoute(nameof(FormatDetailsPage), typeof(FormatDetailsPage));

            Routing.RegisterRoute(nameof(PublishingHouseNewPage), typeof(PublishingHouseNewPage));
            Routing.RegisterRoute(nameof(PublishingHouseDetailsPage), typeof(PublishingHouseDetailsPage));

            Routing.RegisterRoute(nameof(LectorNewPage), typeof(LectorNewPage));
            Routing.RegisterRoute(nameof(LectorDetailsPage), typeof(LectorDetailsPage));

            Routing.RegisterRoute(nameof(BorrowerNewPage), typeof(BorrowerNewPage));
            Routing.RegisterRoute(nameof(BorrowerDetailsPage), typeof(BorrowerDetailsPage));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
