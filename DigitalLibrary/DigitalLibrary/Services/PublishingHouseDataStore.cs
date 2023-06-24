using DigitalLibrary.Helpers;
using DigitalLibrary.Service.Reference;
using DigitalLibrary.Services.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalLibrary.Services
{
    public class PublishingHouseDataStore : AListDataStore<PublishingHouse>
    {
        public PublishingHouseDataStore()
        : base()
        { }
        public override async Task<PublishingHouse> AddItemToService(PublishingHouse item)
        {
            return await _service.PublishingHousePOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(PublishingHouse item)
        {
            return await _service.PublishingHouseDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<PublishingHouse> Find(PublishingHouse item)
        {
            return await _service.PublishingHouseGETAsync(item.Id);
        }

        public override async Task<PublishingHouse> Find(int id)
        {
            return await _service.PublishingHouseGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.PublishingHouseAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(PublishingHouse item)
        {
            return await _service.PublishingHousePUTAsync(item.Id, item).HandleRequest();
        }
    }
}
