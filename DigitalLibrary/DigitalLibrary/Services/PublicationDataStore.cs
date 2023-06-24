using DigitalLibrary.Helpers;
using DigitalLibrary.Service.Reference;
using DigitalLibrary.Services.Abstract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Services
{
    public class PublicationDataStore : AListDataStore<Publication>
    {
        public PublicationDataStore() :base() { }
        public override async Task<Publication> AddItemToService(Publication item)
        {
            return await _service.PublicationPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Publication item)
        {
            return await _service.PublicationDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Publication> Find(Publication item)
        {
            return await _service.PublicationGETAsync(item.Id);
        }

        public override async Task<Publication> Find(int id)
        {
            return await _service.PublicationGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.PublicationAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Publication item)
        {
            return await _service.PublicationPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
