using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.DTO.CuestionarioDTO
{
    public class PreguntaConRespuestaDTO
    {
        public string Descripcion { get; set; }
        public List<RespuestaDescripcionDTO> Respuestas { get; set; }
    }
}
