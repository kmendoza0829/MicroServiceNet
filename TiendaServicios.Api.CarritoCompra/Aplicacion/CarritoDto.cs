using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class CarritoDto
    {
        public int CarritoId { set; get; }

        public DateTime? FechaCreacionSesion { set; get; }
        public List<CarritoDetalleDto> ListaProductos { set; get; }
    }
}
