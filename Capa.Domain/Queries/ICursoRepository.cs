using Capa.Domain.Command.BaseRepository;
using Capa.Domain.DTO.CuestionarioDTO;
using Capa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.Queries
{
    public interface ICursoRepository : IRepository
    {
        public ClaseConCuestionarioDTO GetClaseByIdConCuestionarios(Clase claseOriginal);

    }
}
