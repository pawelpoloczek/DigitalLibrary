using DigitalLibrary.Service.Reference;
using DigitalLibrary.Services;
using DigitalLibrary.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalLibrary.ViewModels.PublicationVM
{
    public class NewPublicationViewModel : ANewViewModel<Publication>
    {
        #region Fields
        private string title;
        private string language;
        private bool status;
        private int publicationYear;
        private List<Category> categories;
        private Category selectedCategory;

        private List<Lector> lectors;
        private Lector selectedLector;

        private List<PublishingHouse> publishingHouses;
        private PublishingHouse selectedPublishingHouse;

        private List<PublicationType> publicationTypes;
        private PublicationType selectedPublicationType;

        private List<Format> formats;
        private Format selectedFormat;

        private List<Borrower> borrowers;
        private Borrower selectedBorrower;

        #endregion Fields

        #region Properties
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

        public Category SelectedCategory
        {
            get => selectedCategory;
            set => SetProperty(ref selectedCategory, value);
        }

        public List<Category> Categories
        {
            get
            {
                return categories;
            }
        }

        public Lector SelectedLector
        {
            get => selectedLector;
            set => SetProperty(ref selectedLector, value);
        }

        public List<Lector> Lectors
        {
            get 
            { 
                return lectors;
            }
        }

        public PublishingHouse SelectedPublishingHouse
        {
            get => selectedPublishingHouse;
            set => SetProperty(ref selectedPublishingHouse, value);
        }

        public List<PublishingHouse> PublishingHouses
        {
            get { return publishingHouses; }
        }

        public PublicationType SelectedPublicationType
        {
            get => selectedPublicationType;
            set => SetProperty(ref selectedPublicationType, value);
        }

        public List <PublicationType> PublicationTypes
        {
            get { return publicationTypes; }
        }


        public Format SelectedFormat
        {
            get => selectedFormat;
            set => SetProperty(ref selectedFormat, value);
        }

        public List<Format> Formats
        {
            get { return formats; }
        }

        public Borrower SelectedBorrower
        {
            get => selectedBorrower;
            set => SetProperty(ref selectedBorrower, value);
        }

        public List<Borrower> Borrowers 
        {
            get { return borrowers; }
        }

        #endregion Properties

        public NewPublicationViewModel() :base()
        {
            var categoryDataStore = new CategoryDataStore();
            categoryDataStore.RefreshListFromService();
            categories = categoryDataStore.items;

            var lectorDataStore = new LectorDataStore();
            lectorDataStore.RefreshListFromService();
            lectors = lectorDataStore.items;

            var publishingHouse = new PublishingHouseDataStore();
            publishingHouse.RefreshListFromService();
            publishingHouses = publishingHouse.items;

            var publicationTypeDataStore = new PublicationTypeDataStore();
            publicationTypeDataStore.RefreshListFromService();
            publicationTypes = publicationTypeDataStore.items;


            var formatDataStore = new FormatDataStore();
            formatDataStore.RefreshListFromService();
            formats = formatDataStore.items;


            var borrowerDataStore = new BorrowerDataStore();
            borrowerDataStore.RefreshListFromService();
            borrowers = borrowerDataStore.items;

        }

        public override Publication SetItem()
        {
            return new Publication
            {
                Title = this.Title,
                Language = this.Language,
                Status = true,
                IdCategory = SelectedCategory.Id,
                IdLector = SelectedLector.Id,
                IdPublicationType = SelectedPublicationType.Id,
                IdFormat = SelectedFormat.Id,   
                IdBorrower = SelectedBorrower.Id,
                IdPublishingHouse = SelectedPublishingHouse.Id,
            };
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(Title);
            //!String.IsNullOrEmpty(SelectedCategory?.Name);
        }
    }
}
