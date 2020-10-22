using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.DTO.CuestionarioDTO
{
    public class CursoCompletoDTO
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int ProfesorId { get; set; }
        public int CategoriaId { get; set; }
        public ICollection<ClaseConCuestionarioDTO> ClasesNavegacion { get; set; }
    }
}
