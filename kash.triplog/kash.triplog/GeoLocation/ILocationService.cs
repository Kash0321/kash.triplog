using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kash.triplog.GeoLocation
{
    /// <summary>
    /// Servicio de obtención del geoposicionamiento del dispositivo
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Obtiene las coordenadas en las que está localizado el dispositivo actualmente
        /// </summary>
        /// <returns>Coordenadas de geoposicionamiento global</returns>
        Task<GeoCoords> GetGeoCoordinatesAsync();
    }
}
