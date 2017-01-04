using kash.triplog.Detail;
using kash.triplog.IoC;
using kash.triplog.Main;
using kash.triplog.Navigation;
using kash.triplog.NewEntry;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace kash.triplog
{
    public partial class App : Application
    {
        public IKernel Kernel { get; set; }

        public App(params INinjectModule[] platformModules)
        {
            InitializeComponent();

            var mainPage = new NavigationPage(new MainView());

            // Register core services
            Kernel = new StandardKernel(new TripLogCoreModule(), new TripLogNavModule(mainPage.Navigation));

            // Register platform specific services
            Kernel.Load(platformModules);

            // Get the MainViewModel from the IoC
            mainPage.BindingContext = Kernel.Get<MainViewModel>();

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
