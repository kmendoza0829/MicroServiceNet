using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class ConsultaFiltro
    {
        public class AutorUnico : IRequest<AutorDto>
        {
            public string AutorGuid { set; get; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorDto>
        {

            public readonly ContextoAutor _context;
            private readonly IMapper _mapper;

            public Manejador(ContextoAutor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AutorDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await _context.AutorLibro.AsNoTracking().FirstOrDefaultAsync(a => a.AutorLibroGuid.Equals(request.AutorGuid));
                if(autor == null)
                {
                    throw new Exception("no se encontro");
                }
                var autoresDto = _mapper.Map<AutorLibro, AutorDto>(autor);
                return autoresDto;
            }
        }
    }
}
