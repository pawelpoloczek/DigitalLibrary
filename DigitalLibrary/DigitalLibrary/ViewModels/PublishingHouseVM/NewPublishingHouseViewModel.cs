using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalLibrary.ViewModels.PublishingHouseVM
{
    public class NewPublishingHouseViewModel : ANewViewModel<PublishingHouse>
    {
        #region Fields
        private string name;
        private string city;
        private bool isActive;
        #endregion Fields

        #region Properties
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }
        public bool IsActive
        {
            get => isActive;
            set => SetProperty(ref isActive, value);
        }
        #endregion Properties


        public NewPublishingHouseViewModel() : base() { }

        public override PublishingHouse SetItem()
        {
            return new PublishingHouse
            {
                City = this.City,
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
