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
        //public abstract Task Init();

        public INavigation Navigation { get; protected set; }

        /// <summary>
        /// Inicializa un instancia de <see cref="ViewModelBase"/>
        /// </summary>
        /// <param name="navigation">Gestión de la navegación entre vistas</param>
        protected ViewModelBase(INavigation navigation)
        {
            Navigation = navigation;
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
}
