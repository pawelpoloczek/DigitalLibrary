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
    public class AuthorDataStore : AListDataStore<Author>
    {
        public AuthorDataStore() : base() { }

        public override async Task<Author> AddItemToService(Author item)
        {
            return await _service.AuthorPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Author item)
        {
            return await _service.AuthorDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Author> Find(Author item)
        {
            return await _service.AuthorGETAsync(item.Id);
        }

        public override async Task<Author> Find(int id)
        {
            return await _service.AuthorGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.AuthorAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Author item)
        {
            return await _service.AuthorPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
