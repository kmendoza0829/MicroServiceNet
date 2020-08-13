﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor.Persistencia
{
    public class ContextoAutor:DbContext
    {
        public ContextoAutor(DbContextOptions<ContextoAutor> options):base(options) { }

        public DbSet<AutorLibro> AutorLibro { set; get; }
        public DbSet<GradoAcademico> GradoAcademico { set; get; }
    }
}
