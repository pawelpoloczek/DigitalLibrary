using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalLibrary.ViewModels.PublicationVM
{
    public class PublicationDetailsViewModel : AItemDetailsViewModel<Publication>
    {
        #region Fields
        private string title;
        private string language;
        private bool status;
        private int publicationYear;
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


        #endregion Properties

        public PublicationDetailsViewModel() :base() { }

        public override void LoadProperties(Publication item)
        {
            Title = item.Title;
            Language = item.Language;
            Status = item.Status;
            PublicationYear = item.PublicationYear;
        }
    }
}
