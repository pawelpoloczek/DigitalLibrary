using DigitalLibrary.Service.Reference;
using DigitalLibrary.ViewModels.Abstract;

namespace DigitalLibrary.ViewModels.PublishingHouseVM
{

    public class PublishingHouseDetailsViewModel : AItemDetailsViewModel<PublishingHouse>
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

        public PublishingHouseDetailsViewModel() : base() { }

        public override void LoadProperties(PublishingHouse item)
        {
            Name = item.Name;
            City = item.City;
            IsActive = item.IsActive;
        }

    }
}
