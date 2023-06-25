using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using System;

namespace DigitalLibrary.ViewModels.AuthorVM
{
    public class NewAuthorViewModel : ANewViewModel<Service.Reference.AuthorViewModel>
    {
        #region Fields
        private string name;
        private string surname;
        private bool isActive;
        #endregion Fields

        #region Properties
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Surname
        {
            get => surname;
            set => SetProperty(ref surname, value);
        }
        public bool IsActive
        {
            get => isActive;
            set => SetProperty(ref isActive, value);
        }
        #endregion Properties

        public NewAuthorViewModel() : base() { }

        public override Service.Reference.AuthorViewModel SetItem()
        {
            return new Service.Reference.AuthorViewModel
            {
                Surname = this.Surname,
                Name = this.Name,
                IsActive = true,
            };
        }

        public override bool ValidateSave()
        {
            return !String.IsNullOrEmpty(Name);
        }
    }
}
