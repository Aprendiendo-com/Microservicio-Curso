using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.DTO
{
    public class CursoRespuestaDTO
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public int ProfesorId { get; set; }
        public int CategoriaId { get; set; }
    }
}
