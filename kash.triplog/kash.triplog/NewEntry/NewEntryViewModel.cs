using kash.triplog.Infrastructure;
using kash.triplog.Main;
using kash.triplog.Model;
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
        public ICommand SaveCommand { get; private set; }

        public NewEntryViewModel(INavigation navigation) : base(navigation)
        {
            SaveCommand = new Command(() =>
            {
                var newEntry = new TripLogEntry()
                {
                    Title = Title,
                    Latitude = Latitude,
                    Longitude = Longitude,
                    Rating = Rating,
                    Date = Date,
                    Notes = Notes
                };

                // TODO: Almacenar la nueva entrada

                Navigation.PopAsync();
                Navigation.PushAsync(new MainView());
            });
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
