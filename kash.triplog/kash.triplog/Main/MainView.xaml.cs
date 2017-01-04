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
        MainViewModel viewModel
        {
            get { return BindingContext as MainViewModel; }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Initialize MainViewModel
            if (viewModel != null)
            {
                await viewModel.Init();
            }
        }

        public MainView()
        {
            InitializeComponent();

            Entries.ItemTapped += async (sender, e) => {
                var item = (TripLogEntry)e.Item;
                viewModel.ViewCommand.Execute(item);
            };
        }
    }
}
