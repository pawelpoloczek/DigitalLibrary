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
    public class AuthorDataStore : AListDataStore<AuthorViewModel>
    {
        public AuthorDataStore() : base() { }

        public override async Task<AuthorViewModel> AddItemToService(AuthorViewModel item)
        {
            //throw new NotImplementedException();
            return await _service.AuthorPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(AuthorViewModel item)
        {
            return await _service.AuthorDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<AuthorViewModel> Find(AuthorViewModel item)
        {
            return await _service.AuthorGETAsync(item.Id);
        }

        public override async Task<AuthorViewModel> Find(int id)
        {
            return await _service.AuthorGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.AuthorAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(AuthorViewModel item)
        {
            //throw new NotImplementedException();
            return await _service.AuthorPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
