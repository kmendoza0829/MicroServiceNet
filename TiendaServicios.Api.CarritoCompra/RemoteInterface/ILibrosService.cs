﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.RemoteModel;

namespace TiendaServicios.Api.CarritoCompra.RemoteInterface
{
    public interface ILibrosService
    {
        Task<(bool resultado, LibroRemote libro, string errorMessage)> GetLibro(Guid LibroId);
    }
}
