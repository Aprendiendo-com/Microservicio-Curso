﻿using Capa.Domain.Command.BaseService;
using Capa.Domain.DTO;
using Capa.Domain.DTO.CuestionarioDTO;
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

    }
}