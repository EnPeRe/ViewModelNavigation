using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ViewModelNavigation.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasePage : ContentPage
	{
		public BasePage ()
		{
			InitializeComponent ();
		}

        public static readonly BindableProperty BackButtonCommandProperty = BindableProperty.Create("BackButtonCommand",
            typeof(ICommand), typeof(BasePage),
            default(ICommand), BindingMode.TwoWay);

        public ICommand BackButtonCommand
        {
            get { return ((ICommand)GetValue(BackButtonCommandProperty)); }
            set
            {
                SetValue(BackButtonCommandProperty, value);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            if (BackButtonCommand == null) return base.OnBackButtonPressed();
            if (BackButtonCommand.CanExecute(null))
            {
                BackButtonCommand.Execute(null);
            }
            return true;
        }
    }
}