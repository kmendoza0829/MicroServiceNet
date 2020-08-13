using MediatR;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public DateTime FechaCreacionSesion { get; set; }
            public List<string> ProductoLista { set; get; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextoCarrito _context;

            public Manejador(ContextoCarrito context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var carritoSesion = new CarritoSesion()
                {
                    FechaCreacion = request.FechaCreacionSesion
                };

                _context.CarritoSesion.Add(carritoSesion);
                var value = await _context.SaveChangesAsync();

                if(value == 0)
                {
                    throw new Exception("Error en insert");
                }

                foreach (var item in request.ProductoLista)
                {
                    var carritoDetalle = new CarritoSesionDetalle()
                    {
                        CarritoSesionId = carritoSesion.CarritoSesionId,
                        ProductoSeleccionado = item,
                        FechaCreacion = DateTime.Now
                    };

                    _context.CarritoSesionDetalle.Add(carritoDetalle);                    
                }
                value = await _context.SaveChangesAsync();
                if(value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Error en insert");

            }
        }
    }
}
