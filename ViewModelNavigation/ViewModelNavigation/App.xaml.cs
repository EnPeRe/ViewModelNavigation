using System;
using ViewModelNavigation.Core.ViewModels;
using ViewModelNavigation.Services.Factory;
using ViewModelNavigation.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ViewModelNavigation
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            IViewModel mainViewModel = ViewModelsFactory.GetViewModel<MainViewModel>(null);
            mainViewModel.Navigate();
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
