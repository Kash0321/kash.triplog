using Akavache;
using kash.triplog.Detail;
using kash.triplog.Http;
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
        ITripLogDataService TripLogService { get; set; }
        IBlobCache Cache { get; set; }

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

        public MainViewModel(INavService navService, ITripLogDataService tripLogService, IBlobCache cache) : base(navService)
        {
            TripLogService = tripLogService;
            Cache = cache;
            LogEntries = new ObservableCollection<TripLogEntry>();
        }

        public override async Task Init()
        {
            LoadEntries();
        }

        void LoadEntries()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                // Load from local cache and then immediately load from API
                Cache.GetAndFetchLatest("entries", async () => await TripLogService.GetEntriesAsync())
                    .Subscribe(entries => {
                        LogEntries = new ObservableCollection<TripLogEntry>(entries);
                });
            }
            finally
            {
                IsBusy = false;
            }

            IsBusy = false;
        }
    }
}