﻿using kash.triplog.Infrastructure;
using kash.triplog.Model;
using kash.triplog.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kash.triplog.Detail
{
    public class DetailViewModel : ViewModelBase<TripLogEntry>
    {
        public DetailViewModel(INavService navService) : base(navService) { }

        TripLogEntry entry;
        public TripLogEntry Entry
        {
            get { return entry; }
            set
            {
                entry = value;
                OnPropertyChanged();
            }
        }

        public override async Task Init(TripLogEntry entry)
        {
            Entry = entry;
        }
    }
}