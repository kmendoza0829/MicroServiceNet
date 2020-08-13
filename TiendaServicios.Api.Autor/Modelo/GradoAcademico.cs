using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Autor.Modelo
{
    public class GradoAcademico
    {
        public int GradoAcademicoId { set; get; }
        public string Nombre { set; get; }
        public string CentroAcademico { set; get; }
        public DateTime? FechaGrado { set; get; }

        public int AutorLibroId { set; get; }

        public AutorLibro AutorLibro { set; get; }
        public string GradoAcademicoGuid { set; get; }
    }
}
