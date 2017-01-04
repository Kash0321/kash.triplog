using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kash.triplog.GeoLocation
{
    /// <summary>
    /// Representa unas coordenadas geográficas
    /// </summary>
    public class GeoCoords
    {
        /// <summary>
        /// Componente Latitud de las coordenadas
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Componente Longitud de las coordenadas
        /// </summary>
        public double Longitude { get; set; }
    }
}
