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
    public class PublicationAddViewMocelStoreData: AListDataStore<PublicationAddViewModel>
    {
        public PublicationAddViewMocelStoreData() : base() { }
        public override async Task<PublicationAddViewModel> AddItemToService(PublicationAddViewModel item)
        {
            return await _service.PublicationPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(PublicationAddViewModel item)
        {
            throw new NotImplementedException();
            //return await _service.PublicationDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<PublicationAddViewModel> Find(PublicationAddViewModel item)
        {
            throw new NotImplementedException();
            //return await _service.PublicationGETAsync(item.Id);
        }

        public override async Task<PublicationAddViewModel> Find(int id)
        {
            throw new NotImplementedException();
            //return await _service.PublicationGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            throw new NotImplementedException();
            //items = _service.PublicationAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(PublicationAddViewModel item)
        {
            throw new NotImplementedException();
            //return await _service.PublicationPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
