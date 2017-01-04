using kash.triplog.Detail;
using kash.triplog.Infrastructure;
using kash.triplog.Model;
using kash.triplog.Navigation;
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
        ObservableCollection<TripLogEntry> logEntries;
        public ObservableCollection<TripLogEntry> LogEntries
        {
            get { return logEntries; }
            set
            {
                logEntries = value;
                OnPropertyChanged();
            }
        }

        Command<TripLogEntry> viewCommand;
        public Command<TripLogEntry> ViewCommand
        {
            get
            {
                return viewCommand ?? (viewCommand = new Command<TripLogEntry>(async (entry) => await ExecuteViewCommand(entry)));
            }
        }
        Command newCommand;
        public Command NewCommand
        {
            get
            {
                return newCommand ?? (newCommand = new Command(async () => await ExecuteNewCommand()));
            }
        }

        async Task ExecuteViewCommand(TripLogEntry entry)
        {
            await NavService.NavigateTo<DetailViewModel, TripLogEntry>(entry);
        }

        async Task ExecuteNewCommand()
        {
            await NavService.NavigateTo<NewEntryViewModel>();
        }

        public MainViewModel(INavService navService) : base(navService)
        {
            LogEntries = new ObservableCollection<TripLogEntry>();
        }

        public override async Task Init()
        {
            await LoadEntries();
        }

        async Task LoadEntries()
        {
            LogEntries.Clear();

            await Task.Factory.StartNew(() =>
            {
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
            });
        }
    }
}