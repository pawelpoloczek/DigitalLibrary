using DigitalLibrary.Models;
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
    public partial class PublicationNewPage : ContentPage
    {
        public Service.Reference.Publication Item { get; set; }
        public PublicationNewPage()
        {
            InitializeComponent();
            BindingContext = new NewPublicationViewModel();
        }
    }
}