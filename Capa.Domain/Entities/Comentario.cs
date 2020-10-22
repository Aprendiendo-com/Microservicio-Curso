using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.Entities
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string Texto { get; set; }
        public int ForoId { get; set; }
        public virtual Foro ForoNavegation { get; set; }
    }
}
