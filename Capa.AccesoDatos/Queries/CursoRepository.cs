using Capa.AccesoDatos.Command;
using Capa.AccesoDatos.Context;
using Capa.Domain.DTO;
using Capa.Domain.DTO.CuestionarioDTO;
using Capa.Domain.Entities;
using Capa.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capa.AccesoDatos.Queries
{
    public class CursoRepository : GenericRepository, ICursoRepository
    {
        private readonly GenericContext context;

        public CursoRepository(GenericContext contexto) : base(contexto)
        {
            this.context = contexto;
        }


        public ClaseConCuestionarioDTO GetClaseByIdConCuestionarios(Clase claseOriginal)
        {
            var claseDTO = new ClaseConCuestionarioDTO()
            {
                ClaseId = claseOriginal.ClaseId,
                Descripcion = claseOriginal.Descripcion,
                Tema = claseOriginal.Tema,
                CursoId = claseOriginal.CursoId,
            };
            Video video = Context.Videos
                .ToList().FirstOrDefault(x => x.ClaseId == claseOriginal.ClaseId);

            var videoDTO = new VideoDTO()
            {
                Descripcion = video.Descripcion,
                Link = video.Link
            };
            claseDTO.Video = videoDTO;

            Foro foro = Context.Foros
                .ToList().FirstOrDefault(x => x.ClaseId == claseOriginal.ClaseId);

            var foroDTO = new ForoDTO()
            {
                ForoId = foro.ForoId,
                Texto = foro.Texto
            };
            claseDTO.Foro = foroDTO;
            return claseDTO;
        }

        public List<CursoCustomDTO> GetCursosConCategoria()
        {
            var cursos = this.Context.Cursos.ToList();
            var categoria = this.Context.Categorias.ToList();

            var query = from c in cursos
                        join cate in categoria on c.CategoriaId equals cate.CategoriaId
                        select new { curso = c.CursoId, nombre = c.Nombre, descripcion = c.Descripcion, cantidad = c.Cantidad, imagen = c.Imagen,
                        categoria = cate.Descripcion, profesor = c.ProfesorId.ToString()};

            var listCursos = new List<CursoCustomDTO>();

            foreach (var elem in query)
            {
                string link;
                var clase = Context.Clases.ToList().FirstOrDefault(x => x.CursoId == elem.curso);
                if (clase != null)
                {
                    link = Context.Videos.ToList().FirstOrDefault(x => x.ClaseId == clase.ClaseId).Link;
                }
                else
                {
                    link = "";
                }

                var curso = new CursoCustomDTO()
                {
                    CursoId = elem.curso,
                    Nombre = elem.nombre,
                    Descripcion = elem.descripcion,
                    Cantidad = elem.cantidad,
                    Profesor = elem.profesor,
                    Categoria = elem.categoria,
                    Imagen = elem.imagen,
                    link_intro = link
                };

                listCursos.Add(curso);
            }

            return listCursos;
        }

        public List<CategoriaDTOs> ObtenerCategorias()
        {
            var categoria = this.context.Categorias.ToList();

            var list = new List<CategoriaDTOs>();

            foreach (var c in categoria)
            {
                var cate = new CategoriaDTOs()
                {
                    Descripcion = c.Descripcion
                };

                list.Add(cate);
            }

            return list;
        }
    }
}
