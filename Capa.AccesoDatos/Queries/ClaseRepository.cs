﻿using Capa.AccesoDatos.Command;
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
    public class ClaseRepository : GenericRepository, IClaseRepository
    {
        public ClaseRepository(GenericContext contexto) : base(contexto)
        {

        }
        /*
        public ClaseDTO GetClaseById(Clase claseOriginal)
        {
            var claseDTO = new ClaseDTO()
            {
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
                Texto = foro.Texto
            };
            claseDTO.Foro = foroDTO;

            return claseDTO;
        }

        public ClaseConCuestionarioDTO GetClaseByIdConCuestionarios(Clase claseOriginal)
        {
            var claseDTO = new ClaseConCuestionarioDTO()
            {
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
                Texto = foro.Texto
            };
            claseDTO.Foro = foroDTO;



            return claseDTO;
        }

        */


    }
}
