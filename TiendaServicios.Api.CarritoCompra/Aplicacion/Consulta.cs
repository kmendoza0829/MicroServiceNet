using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Persistencia;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta : IRequest<CarritoDto>
        {
            public int CarritoSesionId { set; get; }
        }

        public class Manejador : IRequestHandler<Ejecuta, CarritoDto>
        {
            private readonly ContextoCarrito _context;
            private readonly ILibrosService _libro;

            public Manejador(ContextoCarrito context, ILibrosService libro)
            {
                _context = context;
                _libro = libro;
            }

            public async Task<CarritoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = await _context.CarritoSesion.FirstOrDefaultAsync(x => x.CarritoSesionId == request.CarritoSesionId);
                var carritoSesionDetalle = await _context.CarritoSesionDetalle.Where(a => a.CarritoSesionId == request.CarritoSesionId).ToListAsync();

                var lDto = new List<CarritoDetalleDto>();

                foreach (var item in carritoSesionDetalle)
                {
                    var (resultado, libro, errorMessage) = await _libro.GetLibro(new System.Guid(item.ProductoSeleccionado));
                    if (resultado)
                    {
                        var objetoLibro = libro;
                        var carritoDetalle = new CarritoDetalleDto()
                        {
                            TituloLibro = objetoLibro.Titulo,
                            FechaPublicacion = objetoLibro.FechaPublicacion,
                            LibroId = objetoLibro.LibreriaMaterialId
                        };
                        lDto.Add(carritoDetalle);
                    }
                }

                var cDto = new CarritoDto()
                {
                    ListaProductos = lDto,
                    CarritoId = carritoSesion.CarritoSesionId,
                    FechaCreacionSesion = carritoSesion.FechaCreacion
                };
                return cDto;
            }
        }
    }
}
