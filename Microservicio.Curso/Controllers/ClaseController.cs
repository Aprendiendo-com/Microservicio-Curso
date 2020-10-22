using System;
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
    public class ClaseController : ControllerBase
    {

        private readonly IClaseService service;
        public ClaseController(IClaseService services)
        {

            service = services;
        }

        [HttpPost]
        public IActionResult Clase(ClaseDTO claseDTO)
        {
            try
            {
                return new JsonResult(this.service.AddClase(claseDTO)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        /*
        [HttpGet("GetById")]
        public IActionResult GetClaseById(int id)
        {
            try
            {
                return new JsonResult(service.GetById(id)) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
        /*
        [HttpGet("GetClaseById")]
        public async Task<IActionResult> GetClaseByIdConCuestionarios(int idClase)
        {
            try
            {
                return new JsonResult(await service.GetByIdConCuestionarios(idClase)) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        [HttpGet("GetClasesByCurso")]
        public async Task<IActionResult> GetClasesDeCurso(int idCurso)
        {
            try
            {
                return new JsonResult(await service.GetClasesDeCurso(idCurso)) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
    }
}