using kash.triplog.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;

[assembly: Dependency(typeof(kash.triplog.Navigation.XamarinFormsNavService))]
namespace kash.triplog.Navigation
{
    /// <summary>
    /// Servicio de navegación para aplicaciones basadas en Xamarin.Forms
    /// </summary>
    public class XamarinFormsNavService : INavService
    {
        public INavigation XamarinFormsNav { get; set; }

        readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();

        public void RegisterViewMapping(Type viewModel, Type view)
        {
            _map.Add(viewModel, view);
        }

        public bool CanGoBack
        {
            get
            {
                return XamarinFormsNav.NavigationStack != null && XamarinFormsNav.NavigationStack.Count > 0;
            }
        }

        public async Task GoBack()
        {
            if (CanGoBack)
            {
                await XamarinFormsNav.PopAsync(true);
            }
            OnCanGoBackChanged();
        }

        public async Task NavigateTo<TVM>()
        where TVM : ViewModelBase
        {
            await NavigateToView(typeof(TVM));

            if (XamarinFormsNav.NavigationStack.Last().BindingContext is ViewModelBase)
            {
                await ((ViewModelBase)(XamarinFormsNav.NavigationStack.Last().BindingContext)).Init();
            }
        }

        public async Task NavigateTo<TVM, TParameter>(TParameter parameter) where TVM : ViewModelBase
        {
            await NavigateToView(typeof(TVM));

            if (XamarinFormsNav.NavigationStack.Last().BindingContext is ViewModelBase<TParameter>)
            {
                await ((ViewModelBase<TParameter>)(XamarinFormsNav.NavigationStack.Last().BindingContext)).Init(parameter);
            }
        }

        async Task NavigateToView(Type viewModelType)
        {
            Type viewType;

            if (!_map.TryGetValue(viewModelType, out viewType))
            {
                throw new ArgumentException("No view found in View Mapping for " + viewModelType.FullName + ".");
            }

            var constructor = viewType.GetTypeInfo().DeclaredConstructors.FirstOrDefault(dc => dc.GetParameters().Count() <= 0);
            var view = constructor.Invoke(null) as Page;

            await XamarinFormsNav.PushAsync(view, true);
        }

        public async Task RemoveLastView()
        {
            if (XamarinFormsNav.NavigationStack.Any())
            {
                var lastView = XamarinFormsNav.NavigationStack[XamarinFormsNav.NavigationStack.Count - 2];
                XamarinFormsNav.RemovePage(lastView);
            }
        }

        public async Task ClearBackStack()
        {
            if (XamarinFormsNav.NavigationStack.Count <= 1)
            {
                return;
            }
            for (var i = 0; i < XamarinFormsNav.NavigationStack.Count - 1; i++)
            {
                XamarinFormsNav.RemovePage(XamarinFormsNav.NavigationStack[i]);
            }
        }

        public async Task NavigateToUri(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentException("Invalid URI");
            }
            Device.OpenUri(uri);
        }

        public event PropertyChangedEventHandler CanGoBackChanged;
        void OnCanGoBackChanged()
        {
            CanGoBackChanged?.Invoke(this, new PropertyChangedEventArgs("CanGoBack"));
        }
    }
}
