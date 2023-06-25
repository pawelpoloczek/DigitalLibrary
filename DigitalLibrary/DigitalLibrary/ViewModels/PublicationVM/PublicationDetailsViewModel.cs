using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DigitalLibrary.ViewModels.PublicationVM
{
    public class PublicationDetailsViewModel : AItemDetailsViewModel<Service.Reference.PublicationViewModel>
    {
        #region Fields
        private string title;
        private string language;
        private bool status;
        private int publicationYear;
        private List<PublicationAuthor> authorList;
        #endregion Fields

        #region Properties
        public ObservableCollection<PublicationAuthor> Items
        {
            get;
        }
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string Language
        {
            get => language;
            set => SetProperty(ref language, value);
        }
        public bool Status
        {
            get => status;
            set => SetProperty(ref status, value);
        }
        public int PublicationYear
        {
            get => publicationYear;
            set => SetProperty(ref publicationYear, value);
        }

        public Command LoadItemsCommand { get; }
        #endregion Properties

        public PublicationDetailsViewModel() :base() 
        {
            Items = new ObservableCollection<PublicationAuthor>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = authorList;
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


        public override async void LoadProperties(Service.Reference.PublicationViewModel item)
        {
            Title = item.Title;
            Language = item.Language;
            Status = item.Status;
            PublicationYear = item.PublicationYear;
            //authorList = item?.Authors?.ToList();
            await ExecuteLoadItemsCommand();
        }
    }
}
