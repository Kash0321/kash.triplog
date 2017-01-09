using Akavache;
using kash.triplog.Detail;
using kash.triplog.Http;
using kash.triplog.Main;
using kash.triplog.NewEntry;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kash.triplog.IoC
{
    public class TripLogCoreModule : NinjectModule
    {
        public override void Load()
        {
            // ViewModels
            Bind<MainViewModel>().ToSelf();
            Bind<DetailViewModel>().ToSelf();
            Bind<NewEntryViewModel>().ToSelf();

            // Core Services
            var tripLogService = new TripLogApiDataService(new Uri("https://ktriplog.azurewebsites.net"));
            Bind<ITripLogDataService>()
                .ToMethod(x => tripLogService)
                .InSingletonScope();
            Bind<IBlobCache>().ToConstant(BlobCache.LocalMachine);
        }
    }
}
