using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using System;

namespace DigitalLibrary.ViewModels.PublicationTypeVM
{
    public class NewPublicationTypeViewModel : ANewViewModel<PublicationType>
    {
        #region Fields
        private string name;
        private string description;
        private bool isActive;
        #endregion Fields

        #region Properties
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public bool IsActive
        {
            get => isActive;
            set => SetProperty(ref isActive, value);
        }
        #endregion Properties
        public NewPublicationTypeViewModel() :base() { }

        public override PublicationType SetItem()
        {
            return new PublicationType
            {
                Description = this.Description,
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
