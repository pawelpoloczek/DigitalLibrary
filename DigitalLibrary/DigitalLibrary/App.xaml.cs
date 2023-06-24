using DigitalLibrary.Service.Reference;
using DigitalLibrary.Services;
using DigitalLibrary.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<CategoryDataStore>();
            DependencyService.Register<PublicationTypeDataStore>();
            DependencyService.Register<FormatDataStore>();
            DependencyService.Register<PublishingHouseDataStore>();
            
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
