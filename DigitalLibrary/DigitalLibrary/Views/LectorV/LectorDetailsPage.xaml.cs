using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalLibrary.ViewModels.LectorVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalLibrary.Views.LectorV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LectorDetailsPage : ContentPage
    {
        public LectorDetailsPage()
        {
            InitializeComponent();
            BindingContext = new LectorDetailsViewModel();
        }
    }
}