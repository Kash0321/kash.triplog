using kash.triplog.Detail;
using kash.triplog.Model;
using kash.triplog.Navigation;
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
        MainViewModel ViewModel
        {
            get { return BindingContext as MainViewModel; }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Initialize MainViewModel
            if (ViewModel != null)
            {
                await ViewModel.Init();
            }
        }

        public MainView()
        {
            InitializeComponent();

            Entries.ItemTapped += async (sender, e) => {
                var item = (TripLogEntry)e.Item;
                ViewModel.ViewCommand.Execute(item);
            };
        }
    }
}
