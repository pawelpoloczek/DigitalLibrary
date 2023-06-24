using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;

namespace DigitalLibrary.ViewModels.PublicationTypeVM
{
    public class PublicationTypeDetailsViewModel: AItemDetailsViewModel<PublicationType>
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

        public PublicationTypeDetailsViewModel() :base() { }

        public override void LoadProperties(PublicationType item)
        {
            Name = item.Name;
            Description = item.Description;
            IsActive = item.IsActive;
        }
    }
}
