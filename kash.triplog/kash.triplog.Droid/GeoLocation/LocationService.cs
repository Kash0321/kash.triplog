using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using kash.triplog.GeoLocation;
using Xamarin.Geolocation;
using Xamarin.Forms;

namespace kash.triplog.Droid.GeoLocation
{
    public class LocationService : ILocationService
    {
        public async Task<GeoCoords> GetGeoCoordinatesAsync()
        {
            var locator = new Geolocator(Forms.Context)
            {
                DesiredAccuracy = 30
            };

            var position = await locator.GetPositionAsync(30000);

            var result = new GeoCoords
            {
                Latitude = position.Latitude,
                Longitude = position.Longitude
            };
            return result;
        }
    }
}