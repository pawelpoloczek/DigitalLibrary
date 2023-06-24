using Xamarin.Forms;

namespace DigitalLibrary.ViewModels.Abstract
{
    public class AViewModel<T> where T : class
    {
        public T DataStore => DependencyService.Get<T>();
    }
}
