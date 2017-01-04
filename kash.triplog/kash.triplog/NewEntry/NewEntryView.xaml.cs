using kash.triplog.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace kash.triplog.NewEntry
{
    public partial class NewEntryView : ContentPage
    {
        NewEntryViewModel ViewModel
        {
            get
            {
                return BindingContext as NewEntryViewModel;
            }
        }

        public NewEntryView()
        {
            InitializeComponent();
        }
    }
}
