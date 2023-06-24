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
    public class FormatDataStore : AListDataStore<Format>
    {
        public FormatDataStore() :base() { }

        public override async Task<Format> AddItemToService(Format item)
        {
            return await _service.FormatPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Format item)
        {
            return await _service.FormatDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Format> Find(Format item)
        {
            return await _service.FormatGETAsync(item.Id);
        }

        public override async Task<Format> Find(int id)
        {
            return await _service.FormatGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.FormatAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Format item)
        {
            return await _service.FormatPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
