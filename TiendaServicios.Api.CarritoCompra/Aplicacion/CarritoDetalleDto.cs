using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class CarritoDetalleDto
    {
        public Guid? LibroId { set; get; }
        public string TituloLibro { set; get; }
        public string AutorLibro { set; get; }
        public DateTime? FechaPublicacion { set; get; }
    }
}
