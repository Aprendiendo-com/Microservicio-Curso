using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.DTO.CuestionarioDTO
{
    public class CuestionarioTodoDTO
    {
        public string Descripcion { get; set; }
        public List<PreguntaConRespuestaDTO> Preguntas { get; set; }
    }
}
