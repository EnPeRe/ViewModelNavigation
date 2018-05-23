using ViewModelNavigation.Core.ViewModels;
using ViewModelNavigation.ViewModels;
using Xamarin.Forms;

namespace ViewModelNavigation.Services.Factory
{
    public static class ViewModelsFactory
    {
        public static IViewModel GetViewModel<TViewModel>(INavigation navigationService) where TViewModel : BaseViewModel
        {
            IViewModel vm = null;

            if (typeof(TViewModel) == typeof(MainViewModel))
            {
                vm = new MainViewModel();
            }

            if (typeof(TViewModel) == typeof(ViewModel1))
            {
                vm = new ViewModel1();
            }

            if (typeof(TViewModel) == typeof(ViewModel2))
            {
                vm = new ViewModel2();
            }

            if (vm != null)
            {
                vm.NavigationService = navigationService;
            }           

            return vm;
        }
    }
}
