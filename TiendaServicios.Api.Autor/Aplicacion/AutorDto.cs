using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class AutorDto
    {
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public DateTime? FechaNacimiento { set; get; }
        public string AutorLibroGuid { set; get; }
    }
}
