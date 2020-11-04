using Capa.AccesoDatos.Command;
using Capa.AccesoDatos.Context;
using Capa.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.AccesoDatos.Queries
{
    public class ComentarioRepository : GenericRepository, IComentarioRepository
    {
        public ComentarioRepository(GenericContext contexto) : base(contexto)
        {

        }
    }
}
