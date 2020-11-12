using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.DTO.ComentarioDTOs
{
    public class ComentarioDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Texto { get; set; }
        public int ForoId { get; set; }

    }
}
