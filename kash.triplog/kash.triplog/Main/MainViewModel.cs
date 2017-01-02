using kash.triplog.Detail;
using kash.triplog.Infrastructure;
using kash.triplog.Model;
using kash.triplog.NewEntry;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace kash.triplog.Main
{
    public class MainViewModel : ViewModelBase
    {
        ObservableCollection<TripLogEntry> _logEntries;
        public ObservableCollection<TripLogEntry> LogEntries
        {
            get { return _logEntries; }
            set
            {
                _logEntries = value;
                OnPropertyChanged();
            }
        }

        public ICommand NewCommand { get; private set; }
        public ICommand ShowDetail { get; private set; }

        public MainViewModel(INavigation navigation) : base(navigation)
        {
            LogEntries = new ObservableCollection<TripLogEntry>();
            LogEntries.Add(new TripLogEntry
            {
                Title = "Washington Monument",
                Notes = "Amazing!",
                Rating = 3,
                Date = new DateTime(2015, 2, 5),
                Latitude = 38.8895,
                Longitude = -77.0352
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Statue of Liberty",
                Notes = "Inspiring!",
                Rating = 4,
                Date = new DateTime(2015, 4, 13),
                Latitude = 40.6892,
                Longitude = -74.0444
            });
            LogEntries.Add(new TripLogEntry
            {
                Title = "Golden Gate Bridge",
                Notes = "Foggy, but beautiful.",
                Rating = 5,
                Date = new DateTime(2015, 4, 26),
                Latitude = 37.8268,
                Longitude = -122.4798
            });

            NewCommand = new Command(() =>
            {
                Navigation.PopAsync();
                Navigation.PushAsync(new NewEntryView());
            });

            ShowDetail = new Command(() =>
            {
                Navigation.PopAsync();
                Navigation.PushAsync(new DetailView(new TripLogEntry()));
            });
        }
    }
}