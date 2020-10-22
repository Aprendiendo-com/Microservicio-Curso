using Capa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.DTO
{
    public class ClaseDTO
    {
        public string Descripcion { get; set; }
        public string Tema { get; set; }
        public int CursoId { get; set; }
        public VideoDTO Video { get; set; }
        public ForoDTO Foro { get; set; }
    }
}
