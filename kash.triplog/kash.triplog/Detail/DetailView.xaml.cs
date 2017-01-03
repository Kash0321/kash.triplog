using kash.triplog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace kash.triplog.Detail
{
    public partial class DetailView : ContentPage
    {
        public DetailView(TripLogEntry entry)
        {
            InitializeComponent();

            var viewModel = new DetailViewModel(Navigation, entry);

            BindingContext = viewModel;

            Title = "Entry Details";

            var mainLayout = new Grid
            {
                RowDefinitions = {
                    new RowDefinition {
                        Height = new GridLength (4, GridUnitType.Star)
                    },
                    new RowDefinition {
                        Height = GridLength.Auto
                    },
                    new RowDefinition {
                        Height = new GridLength (1, GridUnitType.Star)
                    }
                }
            };

            var map = new Map();

            // Center the map around the log entry's location
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position
            (viewModel.Entry.Latitude, viewModel.Entry.Longitude), Distance.FromMiles(.5)));

            // Place a pin on the map for the log entry's location
            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = viewModel.Entry.Title,
                Position = new Position(viewModel.Entry.Latitude, viewModel.Entry.Longitude)
            });

            var title = new Label
            {
                HorizontalOptions = LayoutOptions.Center
            };
            title.Text = viewModel.Entry.Title;

            var date = new Label
            {
                HorizontalOptions = LayoutOptions.Center
            };
            date.Text = viewModel.Entry.Date.ToString("M");

            var rating = new Label
            {
                HorizontalOptions = LayoutOptions.Center
            };
            rating.Text = $"{viewModel.Entry.Rating} star rating";

            var notes = new Label
            {
                HorizontalOptions = LayoutOptions.Center
            };
            notes.Text = viewModel.Entry.Notes;

            var details = new StackLayout
            {
                Padding = 10,
                Children = {
                    title, date, rating, notes
                }
            };

            var detailsBg = new BoxView
            {
                BackgroundColor = Color.White,
                Opacity = .8
            };

            mainLayout.Children.Add(map);
            mainLayout.Children.Add(detailsBg, 0, 1);
            mainLayout.Children.Add(details, 0, 1);
            Grid.SetRowSpan(map, 3);
            Content = mainLayout;
        }
    }
}