using Capa.Domain.Command.BaseService;
using Capa.Domain.DTO.ComentarioDTO;
using Capa.Domain.DTO.ComentarioDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capa.Domain.Services
{
    public interface IComentarioService : IService
    {
        ComentarioResponseDTO AddComentario(ComentarioDTO comentarioDTO);
        List<ComentarioTextoDTO> GetBYForoId(int ForoId);

    }
}
