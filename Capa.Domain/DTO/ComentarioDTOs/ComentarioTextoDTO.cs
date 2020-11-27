using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.DTO.ComentarioDTOs
{
    public class ComentarioTextoDTO
    {
        public int ComentarioId { get; set; }
        public string Texto { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rol { get; set; }

    }
}
