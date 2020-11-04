using Capa.Domain.DTO;
using Capa.Domain.DTO.ComentarioDTOs;
using Capa.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservicio.Curso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {

        private readonly IComentarioService service;
        public ComentarioController(IComentarioService services)
        {

            service = services;
        }

        [HttpPost]
        public IActionResult AddComentario(ComentarioDTO comentarioDTO)
        {
            try
            {
                return new JsonResult(this.service.AddComentario(comentarioDTO)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("GetByForoId")]
        public IActionResult GetBYForoId(int ForoId)
        {
            try
            {
                return new JsonResult(service.GetBYForoId(ForoId)) { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
