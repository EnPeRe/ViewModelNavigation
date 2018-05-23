using ViewModelNavigation.Views;
using Xamarin.Forms;

namespace ViewModelNavigation.ViewModels
{
    public class ViewModel2 : BaseViewModel
    {
        public ViewModel2() 
        {
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

        public override void Navigate()
        {
            LoadData();
            OpenView<Page2>();
        }

        private void LoadData()
        {
            PageName = "I am the page 2";
        }
    }
}
