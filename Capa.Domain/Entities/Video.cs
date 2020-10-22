using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.Entities
{
    public class Video
    {
        public int VideoId { get; set; }
        public string Descripcion { get; set; }
        public string Link { get; set; }
        public int ClaseId { get; set; }
        public virtual Clase ClaseNavegation { get; set; }
    }
}
