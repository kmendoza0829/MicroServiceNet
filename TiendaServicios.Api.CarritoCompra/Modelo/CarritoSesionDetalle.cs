using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.CarritoCompra.Modelo
{
    public class CarritoSesionDetalle
    {
        public int CarritoSesionDetalleId { set; get; }
        public DateTime? FechaCreacion { set; get; }
        public string ProductoSeleccionado { set; get; }

        public int CarritoSesionId { set; get; }

        public CarritoSesion CarritoSesion { set; get; }
    }
}
