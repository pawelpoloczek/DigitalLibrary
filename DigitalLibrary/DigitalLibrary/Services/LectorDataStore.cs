using DigitalLibrary.Helpers;
using DigitalLibrary.Service.Reference;
using DigitalLibrary.Services.Abstract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Services
{
    public class LectorDataStore : AListDataStore<Lector>
    {
        public LectorDataStore() :base() { }

        public override async Task<Lector> AddItemToService(Lector item)
        {
            return await _service.LectorPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Lector item)
        {
            return await _service.LectorDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Lector> Find(Lector item)
        {
            return await _service.LectorGETAsync(item.Id);
        }

        public override async Task<Lector> Find(int id)
        {
            return await _service.LectorGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.LectorAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Lector item)
        {
            return await _service.LectorPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
