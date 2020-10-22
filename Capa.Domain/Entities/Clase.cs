using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.Entities
{
    public class Clase
    {
        public int ClaseId { get; set; }
        public string Descripcion { get; set; }
        public string Tema { get; set; }
        public int CursoId { get; set; }
        public virtual Curso CursoNavegacion { get; set; }
        public virtual Video VideoNavegation { get; set; }
        public virtual Foro ForoNavegation { get; set; }

    }
}
