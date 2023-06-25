using DigitalLibrary.Helpers;
using DigitalLibrary.Service.Reference;
using DigitalLibrary.Services.Abstract;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Services
{
    public class PublicationDataStore : AListDataStore<Service.Reference.PublicationViewModel>
    {
        public PublicationDataStore() :base() { }
        public override async Task<Service.Reference.PublicationViewModel> AddItemToService(Service.Reference.PublicationViewModel item)
        {
            throw new NotImplementedException();
            //return await _service.PublicationPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Service.Reference.PublicationViewModel item)
        {
            return await _service.PublicationDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Service.Reference.PublicationViewModel> Find(Service.Reference.PublicationViewModel item)
        {
            return await _service.PublicationGETAsync(item.Id);
        }

        public override async Task<Service.Reference.PublicationViewModel> Find(int id)
        {
            return await _service.PublicationGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.PublicationAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Service.Reference.PublicationViewModel item)
        {
            throw new NotImplementedException();
            //return await _service.PublicationPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
