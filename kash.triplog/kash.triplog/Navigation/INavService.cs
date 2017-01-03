using kash.triplog.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kash.triplog.Navigation
{
    public interface INavService
    {
        bool CanGoBack { get; }
        Task GoBack();
        Task NavigateTo<TVM>()
        where TVM : ViewModelBase;
        Task NavigateTo<TVM, TParameter>(TParameter parameter)
        where TVM : ViewModelBase;
        Task RemoveLastView();
        Task ClearBackStack();
        Task NavigateToUri(Uri uri);
        event PropertyChangedEventHandler CanGoBackChanged;
    }
}
