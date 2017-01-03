using kash.triplog.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kash.triplog.Infrastructure
{
    /// <summary>
    /// Base de todos los ViewModels de la aplicación
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public abstract Task Init();

        /// <summary>
        /// Servicio de navegación entre pantallas de la aplicación
        /// </summary>
        protected INavService NavService { get; private set; }

        /// <summary>
        /// Inicializa un instancia de <see cref="ViewModelBase"/>
        /// </summary>
        /// <param name="navService">Gestión de la navegación entre vistas</param>
        protected ViewModelBase(INavService navService)
        {
            NavService = navService;
        }

        /// <summary>
        /// Se dispara cuando una propiedad del ViewModel ha cambiado, y sirve para notificar a la vista esta circunstancia
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Provoca el disparo del evento <see cref="PropertyChanged"/> 
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad cuyo cambio ha provocado el disparo del evento</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public abstract class ViewModelBase<TParameter> : ViewModelBase
    {
        protected ViewModelBase(INavService navService) : base(navService) { }

        public override async Task Init()
        {
            await Init(default(TParameter));
        }

        public abstract Task Init(TParameter parameter);
    }
}
