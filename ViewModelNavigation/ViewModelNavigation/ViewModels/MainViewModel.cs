using System.Windows.Input;
using Xamarin.Forms;

namespace ViewModelNavigation.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel() 
        {
        }

        private ICommand _openViewCommand;
        public ICommand OpenViewCommand
        {
            get
            {
                _openViewCommand = _openViewCommand ?? new Command(() => GoToPage1());
                return _openViewCommand;
            }
        }

        private string _pageName;
        public string PageName
        {
            get
            {
                return _pageName;
            }
            set
            {
                _pageName = value;
                OnPropertyChanged();
            }
        }

        protected override void OpenView<TView>()
        {
            TView view = new TView();
            view.BindingContext = this;
            App.Current.MainPage = new NavigationPage(view);
            CurrentPage = App.Current.MainPage;
        }

        private void GoToPage1()
        {
            NavigateTo<ViewModel1>();
        }

        public override void Navigate()
        {
            LoadData();
            OpenView<MainPage>();
        }

        private void LoadData()
        {
            PageName = "I am the main page";
        }
    }
}
