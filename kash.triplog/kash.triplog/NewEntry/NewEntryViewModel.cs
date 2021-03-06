﻿using kash.triplog.GeoLocation;
using kash.triplog.Http;
using kash.triplog.Infrastructure;
using kash.triplog.Main;
using kash.triplog.Model;
using kash.triplog.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace kash.triplog.NewEntry
{
    public class NewEntryViewModel : ViewModelBase
    {
        ILocationService LocationService { get; set; }
        ITripLogDataService TripLogService { get; set; }

        Command saveCommand;
        public Command SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new Command(async () => await ExecuteSaveCommand(), CanSave));
            }
        }

        async Task ExecuteSaveCommand()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            var newItem = new TripLogEntry
            {
                Title = Title,
                Latitude = Latitude,
                Longitude = Longitude,
                Date = Date,
                Rating = Rating,
                Notes = Notes
            };

            try
            {
                await TripLogService.AddEntryAsync(newItem);
                await NavService.GoBack();
            }
            finally
            {
                IsBusy = false;
            }
        }

        bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Title);
        }

        public NewEntryViewModel(INavService navService, ILocationService locService, ITripLogDataService tripLogService) : base(navService)
        {
            Date = DateTime.Today;
            Rating = 1;

            LocationService = locService;
            TripLogService = tripLogService;
        }

        public override async Task Init()
        {
            var coords = await LocationService.GetGeoCoordinatesAsync();

            Latitude = coords.Latitude;
            Longitude = coords.Longitude;
        }

        string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged();
                    SaveCommand.ChangeCanExecute();
                }
            }
        }

        double latitude;
        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                if (latitude != value)
                {
                    latitude = value;
                    OnPropertyChanged();
                }
            }
        }

        double longitude;
        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                if (longitude != value)
                {
                    longitude = value;
                    OnPropertyChanged();
                }
            }
        }

        DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged();
                }
            }
        }

        int rating;
        public int Rating
        {
            get
            {
                return rating;
            }
            set
            {
                if (rating != value)
                {
                    rating = value;
                    OnPropertyChanged();
                }
            }
        }

        string notes;
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                if (notes != value)
                {
                    notes = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
