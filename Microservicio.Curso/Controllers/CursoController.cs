using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capa.Domain.DTO;
using Capa.Domain.DTO.CuestionarioDTO;
using Capa.Domain.DTO.CursoResponseDTO;
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
        
        [HttpPatch("GetCursosByLista")]
        public async Task<IActionResult> GetCursosByLista(List<int> idCursos)
        {
            try
            {
                return new JsonResult(await service.GetCursoByIdLista(idCursos)) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return new JsonResult(service.GetAll()) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]

        public IActionResult CursosSimple()
        {
            try
            {
                return new JsonResult(service.CursoSimple()) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("ObtenerCategorias")]

        //public IActionResult ObtenerCategorias()
        //{
        //    try
        //    {
        //        return new JsonResult(service.ObtenerCategorias()) { StatusCode = 200 };
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpPut("RestarCupoById")]
        public IActionResult RestarCupoById(RequestIdCursoDTO idCursos)
        {
            try
            {
                return new JsonResult(service.RestarCupoById(idCursos)) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetClasesByIdClase")]
        public IActionResult GetClasesByIdClase(int idClase)
        {
            try
            {
                return new JsonResult(service.GetClasesByIdClase(idClase)) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}