using Capa.Domain.Command.BaseService;
using Capa.Domain.DTO;
using Capa.Domain.DTO.CuestionarioDTO;
using Capa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Domain.Services
{
     public interface IClaseService : IService
    {
        ClaseRespuestaDTO AddClase(ClaseDTO claseDTO);
        /*
        ClaseDTO GetById(int id);
        Task<ClaseConCuestionarioDTO> GetByIdConCuestionarios(int id);
        Task<List<ClaseConCuestionarioDTO>> GetClasesDeCurso(int idCurso);



        Task<CuestionarioTodoDTO> GetCuestionarioDeClase(int idClase);
        */
    }
}
