using kash.triplog.Detail;
using kash.triplog.Main;
using kash.triplog.Navigation;
using kash.triplog.NewEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace kash.triplog
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var mainPage = new NavigationPage(new MainView());

            var navService = DependencyService.Get<INavService>() as XamarinFormsNavService;

            navService.XamarinFormsNav = mainPage.Navigation;
            navService.RegisterViewMapping(typeof(MainViewModel), typeof(MainView));
            navService.RegisterViewMapping(typeof(DetailViewModel), typeof(DetailView));
            navService.RegisterViewMapping(typeof(NewEntryViewModel), typeof(NewEntryView));

            MainPage = mainPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
