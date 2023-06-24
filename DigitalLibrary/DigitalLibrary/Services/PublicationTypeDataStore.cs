using DigitalLibrary.Helpers;
using DigitalLibrary.Service.Reference;
using DigitalLibrary.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Services
{
    public class PublicationTypeDataStore : AListDataStore<PublicationType>
    {
        public PublicationTypeDataStore() :base() { }

        public override async Task<PublicationType> AddItemToService(PublicationType item)
        {
            return await _service.PublicationTypePOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(PublicationType item)
        {
            return await _service.PublicationTypeDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<PublicationType> Find(PublicationType item)
        {
            return await _service.PublicationTypeGETAsync(item.Id);
        }

        public override async Task<PublicationType> Find(int id)
        {
            return await _service.PublicationTypeGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.PublicationTypeAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(PublicationType item)
        {
            return await _service.PublicationTypePUTAsync(item.Id, item).HandleRequest();
        }
    }
}
