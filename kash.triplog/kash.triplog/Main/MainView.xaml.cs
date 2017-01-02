using kash.triplog.Detail;
using kash.triplog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace kash.triplog.Main
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            BindingContext = new MainViewModel(Navigation);

            Entries.ItemTapped += async (sender, e) => {
                var item = (TripLogEntry)e.Item;
                await Navigation.PushAsync(new DetailView(item));
            };
        }
    }
}
