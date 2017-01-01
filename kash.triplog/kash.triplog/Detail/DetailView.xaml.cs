using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace kash.triplog.Detail
{
    public partial class DetailView : ContentPage
    {
        public DetailView()
        {
            InitializeComponent();

            BindingContext = new DetailViewModel(Navigation);
        }
    }
}
