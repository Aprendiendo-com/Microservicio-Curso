using Capa.Aplication.Services.Base;
using Capa.Domain.DTO.ComentarioDTO;
using Capa.Domain.DTO.ComentarioDTOs;
using Capa.Domain.Entities;
using Capa.Domain.Queries;
using Capa.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Aplication.Services
{
    public class ComentarioService : GenericService, IComentarioService
    {
        private readonly IComentarioRepository repository;

        public ComentarioService(IComentarioRepository _repository) : base(_repository)
        {
            this.repository = _repository;
        }



        public ComentarioResponseDTO AddComentario(ComentarioDTO comentarioDTO)
        {
            var comentario = new Comentario()
            {
                Texto = comentarioDTO.Texto,
                ForoId = comentarioDTO.ForoId
            };


            this.Repository.Add(comentario);


            var comentarioRespuesta = new ComentarioResponseDTO()
            {
                ComentarioId = comentario.ComentarioId
            };

            return comentarioRespuesta;

        }
    }
}
