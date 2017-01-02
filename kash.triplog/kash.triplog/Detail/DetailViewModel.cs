using kash.triplog.Infrastructure;
using kash.triplog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kash.triplog.Detail
{
    public class DetailViewModel : ViewModelBase
    {
        public DetailViewModel(INavigation navigation, TripLogEntry entry) : base(navigation)
        {
            Entry = entry;
        }

        public TripLogEntry Entry { get; set; }
    }
}