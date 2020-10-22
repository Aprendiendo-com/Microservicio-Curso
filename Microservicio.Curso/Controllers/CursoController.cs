﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capa.Domain.DTO;
using Capa.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservicio.Curso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {

        private readonly ICursoService service;
        public CursoController(ICursoService services)
        {

            service = services;
        }

        [HttpPost]
        public IActionResult Curso(CursoDTO cursoDTO)
        {
            try
            {
                return new JsonResult(this.service.AddCurso(cursoDTO)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //MODIFICADO
        [HttpGet("GetCursoById")]
        public async Task<IActionResult> GetCursoById(int idCurso)
        {
            try
            {
                return new JsonResult(await service.GetCursoById(idCurso)) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}