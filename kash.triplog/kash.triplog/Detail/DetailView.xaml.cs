using kash.triplog.Model;
using kash.triplog.Navigation;
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
        readonly Map map;
        DetailViewModel viewModel
        {
            get { return BindingContext as DetailViewModel; }
        }

        public DetailView()
        {
            InitializeComponent();

            Title = "Entry Details";

            BindingContextChanged += (sender, args) =>
            {
                if (viewModel == null) return;
                viewModel.PropertyChanged += (s, e) => {
                    if (e.PropertyName == "Entry")
                    {
                        UpdateMap();
                    }
                };
            };

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

            map = new Map();

            var title = new Label
            {
                HorizontalOptions = LayoutOptions.Center
            };
            title.SetBinding(Label.TextProperty, "Entry.Title");

            var date = new Label
            {
                HorizontalOptions = LayoutOptions.Center
            };
            date.SetBinding(Label.TextProperty, "Entry.Date", stringFormat: "{0:M}");

            var rating = new Label
            {
                HorizontalOptions = LayoutOptions.Center
            };
            rating.SetBinding(Label.TextProperty, "Entry.Rating");

            var notes = new Label
            {
                HorizontalOptions = LayoutOptions.Center
            };
            notes.SetBinding(Label.TextProperty, "Entry.Notes");

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

        void UpdateMap()
        {
            var pos = new Position(viewModel.Entry.Latitude, viewModel.Entry.Longitude);

            // Center the map around the log entry's location
            map.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromMiles(.5)));

            // Place a pin on the map for the log entry's location
            map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = viewModel.Entry.Title,
                Position = pos
            });
        }
    }
}