using DigitalLibrary.Helpers;
using DigitalLibrary.Service.Reference;
using DigitalLibrary.Services.Abstract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalLibrary.Services
{
    public class CategoryDataStore : AListDataStore<Category>
    {
        public CategoryDataStore() 
            :base ()
        { }
        public override async Task<Category> AddItemToService(Category item)
        {
            return await _service.CategoryPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Category item)
        {
            return await _service.CategoryDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Category> Find(Category item)
        {
            return await _service.CategoryGETAsync(item.Id);
        }

        public override async Task<Category> Find(int id)
        {
            return await _service.CategoryGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.CategoryAllAsync().Result.ToList();
        }

        public override async Task<bool> UpdateItemInService(Category item)
        {
            return await _service.CategoryPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
