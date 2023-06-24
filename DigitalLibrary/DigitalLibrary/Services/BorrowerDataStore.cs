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
    public class BorrowerDataStore : AListDataStore<Borrower>
    {
        public BorrowerDataStore():base() { }

        public override async Task<Borrower> AddItemToService(Borrower item)
        {
            return await _service.BorrowerPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Borrower item)
        {
            return await _service.BorrowerDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Borrower> Find(Borrower item)
        {
            return await _service.BorrowerGETAsync(item.Id);
        }

        public override async Task<Borrower> Find(int id)
        {
            return await _service.BorrowerGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.BorrowerAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Borrower item)
        {
            return await _service.BorrowerPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
