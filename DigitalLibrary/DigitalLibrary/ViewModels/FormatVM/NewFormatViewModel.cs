using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using System;

namespace DigitalLibrary.ViewModels.FormatVM
{
    public class NewFormatViewModel : ANewViewModel<Format>
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
        public NewFormatViewModel() : base() { }

        public override Format SetItem()
        {
            return new Format
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
