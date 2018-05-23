using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModelNavigation.Core.ViewModels;
using ViewModelNavigation.Services.Factory;
using Xamarin.Forms;

namespace ViewModelNavigation.ViewModels
{
    public abstract class BaseViewModel : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private INavigation _navigationService;
        private Page _currentPage;
        private ICommand _backCommand;

        public INavigation NavigationService
        {
            get
            {
                return _navigationService;
            }
            set
            {
                _navigationService = value;
            }
        }

        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;               
            }
        }

        public ICommand BackCommand
        {
            get
            {
                _backCommand = _backCommand ?? new Command(async () => await this.CloseView());
                return _backCommand;
            }
        }

        public BaseViewModel()
        {
          
        }

        public abstract void Navigate();

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OpenView<TView>() where TView : Page, new()
        {
            TView view = new TView();
            view.BindingContext = this;
            NavigationService.PushAsync(view);
            _currentPage = view;
        }

        protected virtual void OpenModalView<TView>() where TView : Page, new()
        {
            TView view = new TView();
            view.BindingContext = this;
            NavigationService.PushModalAsync(view);
            _currentPage = view;
        }

        protected virtual async Task CloseView()
        {
            await NavigationService.PopAsync();
        }

        protected virtual void CloseModalView()
        {
            NavigationService.PopModalAsync();
        }

        public void NavigateTo<TViewModel>() where TViewModel : BaseViewModel
        {
            //si no hemos abierto ninguna página, nos quedamos con el servicio de navegación obtenido
            IViewModel viewModel = ViewModelsFactory.GetViewModel<TViewModel>(_currentPage?.Navigation ?? NavigationService);
            viewModel.Navigate();
        }
    }
}
