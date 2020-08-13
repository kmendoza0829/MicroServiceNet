using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.CarritoCompra.Modelo
{
    public class CarritoSesion
    {
        public int CarritoSesionId { set; get; }
        public DateTime? FechaCreacion { set; get; }

        public ICollection<CarritoSesionDetalle> ListaDetalle { set; get; }
    }
}
