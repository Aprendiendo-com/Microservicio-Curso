using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.Entities
{
    public class Foro
    {
        public int ForoId { get; set; }
        public string Texto { get; set; }
        public int ClaseId { get; set; }
        public virtual Clase ClaseNavegation { get; set; }
        public virtual ICollection<Comentario> ComentariosNavegation { get; set; }
    }
}
