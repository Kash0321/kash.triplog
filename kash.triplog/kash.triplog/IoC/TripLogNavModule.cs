using kash.triplog.Detail;
using kash.triplog.Main;
using kash.triplog.Navigation;
using kash.triplog.NewEntry;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kash.triplog.IoC
{
    public class TripLogNavModule : NinjectModule
    {
        readonly INavigation xfNav;

        public TripLogNavModule(INavigation xamarinFormsNavigation)
        {
            xfNav = xamarinFormsNavigation;
        }

        public override void Load()
        {
            var navService = new XamarinFormsNavService();
            navService.XamarinFormsNav = xfNav;

            // Register view mappings
            navService.RegisterViewMapping(typeof(MainViewModel), typeof(MainView));
            navService.RegisterViewMapping(typeof(DetailViewModel), typeof(DetailView));
            navService.RegisterViewMapping(typeof(NewEntryViewModel), typeof(NewEntryView));

            Bind<INavService>().ToMethod(x => navService).InSingletonScope();
        }
    }
}
