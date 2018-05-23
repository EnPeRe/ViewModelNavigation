using System;
using System.Windows.Input;
using ViewModelNavigation.Views;
using Xamarin.Forms;

namespace ViewModelNavigation.ViewModels
{
    public class ViewModel1 : BaseViewModel
    {
        public ViewModel1() 
        {
        }

        private ICommand _openViewCommand;
        public ICommand OpenViewCommand
        {
            get
            {
                _openViewCommand = _openViewCommand ?? new Command(() => GoToPage2());
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

        private void GoToPage2()
        {
            NavigateTo<ViewModel2>();
        }

        public override void Navigate()
        {
            LoadData();
            OpenView<Page1>();
        }

        private void LoadData()
        {
            PageName = "I am the page 1";
        }
    }
}
