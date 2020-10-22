using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.Entities
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Curso> CursoNavegacion { get; set; }
    }
}
