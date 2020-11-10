using Capa.Domain.Command.BaseService;
using Capa.Domain.DTO;
using Capa.Domain.DTO.CuestionarioDTO;
using Capa.Domain.DTO.CursoResponseDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capa.Domain.Services
{
    public interface ICursoService: IService
    {
        CursoRespuestaDTO AddCurso(CursoDTO cursoDTO);

        Task<CursoCompletoDTO> GetCursoById(int idCurso);


        Task<List<CursoCompletoDTO>> GetCursoByIdLista(List<int> idCursos);



        List<CursoCustomDTO> GetAll();

        List<CategoriaDTOs> ObtenerCategorias();

    }
}
