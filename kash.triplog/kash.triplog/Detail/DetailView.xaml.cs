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
        DetailViewModel viewModel
        {
            get { return BindingContext as DetailViewModel; }
        }

        public DetailView()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                throw ex;
            }

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
        }

        void UpdateMap()
        {
            var pos = new Position(viewModel.Entry.Latitude, viewModel.Entry.Longitude);

            // Center the map around the log entry's location
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(pos, Distance.FromMiles(.5)));

            // Place a pin on the map for the log entry's location
            Map.Pins.Add(new Pin
            {
                Type = PinType.Place,
                Label = viewModel.Entry.Title,
                Position = pos
            });
        }
    }
}