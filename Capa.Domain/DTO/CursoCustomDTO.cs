using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.DTO
{
    public class CursoCustomDTO
    {
        public int CursoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Profesor { get; set; }
        public string Categoria { get; set; }
        public string Imagen { get; set; }
        public string link_intro { get; set; }
    }
}
