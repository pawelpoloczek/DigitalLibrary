using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using System;

namespace DigitalLibrary.ViewModels.BorrowerVM
{
    public class NewBorrowerViewModel : ANewViewModel<Borrower>
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

        public NewBorrowerViewModel() : base() { }

        public override Borrower SetItem()
        {
            return new Borrower
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
