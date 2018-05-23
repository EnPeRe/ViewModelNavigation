using Xamarin.Forms;

namespace ViewModelNavigation.Core.ViewModels
{
    public interface IViewModel
    {
        INavigation NavigationService { get; set; }
        void Navigate();
    }
}
