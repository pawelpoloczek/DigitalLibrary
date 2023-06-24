using System;
using DigitalLibrary.ViewModels.PublishingHouseVM;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.PublishingHouseV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PublishingHouseNewPage : ContentPage
    {
        public Service.Reference.PublishingHouse Item { get; set; }
        public PublishingHouseNewPage()
        {
            InitializeComponent();
            BindingContext = new NewPublishingHouseViewModel();
        }
    }
}